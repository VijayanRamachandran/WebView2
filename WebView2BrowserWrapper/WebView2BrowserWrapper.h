#pragma once

#include <windows.h>
#include <BrowserWindow.h>
#include <atlstr.h>

#define LOWORD(l) ((WORD)(l))
#define HIWORD(l) ((WORD)(((DWORD)(l) >> 16) & 0xFFFF)) 

using namespace System;
using namespace System::Windows;
using namespace System::Windows::Interop;
using namespace System::Windows::Input;
using namespace System::Windows::Media;
using namespace System::Runtime::InteropServices;


namespace WebView2BrowserWrapper
{
	public delegate void TabNavigationCompleted();	

	public ref class WebView2BrowserWrapper : public HwndHost, IKeyboardInputSink
	{
		System::IntPtr myWin32Window;
		BrowserWindow* myBrowserWindow = nullptr;
		const int HOST_ID = 0x00000002;
		double myHostWindowWidth;
		double myHostWindowHeight;
		System::String^ myInitialUrl;	
		
	public:

		event TabNavigationCompleted^ OnTabNavigationCompleted;

		[System::Runtime::InteropServices::UnmanagedFunctionPointer(CallingConvention::StdCall)]
		delegate void TabNavigationCompletedCallback();		

		[System::Runtime::InteropServices::DllImport("user32.dll", EntryPoint = "CreateWindowEx", CallingConvention = CallingConvention::StdCall)]
		static System::IntPtr CreateWindowEx(int dwExStyle,
											System::String^ lpszClassName,
											System::String^ lpszWindowName,
											int style,
											int x, int y,
											int width, int height,
											System::IntPtr hwndParent,
											System::IntPtr hMenu,
											System::IntPtr hInst,
											[System::Runtime::InteropServices::MarshalAs(UnmanagedType::AsAny)] System::Object^ pvParam);

	[System::Runtime::InteropServices::DllImport("WebView2Browser.dll", EntryPoint = "InitInstance", CharSet = CharSet::Unicode, CallingConvention = CallingConvention::StdCall)]
	static BOOL InitInstance(HWND parentHandle,
							 CString url,
							 [System::Runtime::InteropServices::MarshalAs(UnmanagedType::FunctionPtr)]BrowserWindow::TabNavigationCompletedCallback tabNavigationCompletedCallbackPointer);


	[System::Runtime::InteropServices::DllImport("WebView2Browser.dll", EntryPoint = "Navigate", CharSet = CharSet::Unicode, CallingConvention = CallingConvention::StdCall)]
	static void Navigate(CString url);

	[System::Runtime::InteropServices::DllImport("WebView2Browser.dll", EntryPoint = "SetFocus", CharSet = CharSet::Unicode, CallingConvention = CallingConvention::StdCall)]
	static void SetFocus();

	WebView2BrowserWrapper(double width,
		double height,
		System::String^ url)
	{
		myHostWindowWidth = width;
		myHostWindowHeight = height;
		myInitialUrl = url;

		myBrowserWindow = new BrowserWindow();
	}

	~WebView2BrowserWrapper()
	{
		if (myBrowserWindow != NULL)
		{
			myBrowserWindow->Close();
			delete myBrowserWindow;
			myBrowserWindow = NULL;
		}
	}

	System::Void Navigate(System::String^ url)
	{
		if (myBrowserWindow != NULL)
		{
			pin_ptr<const wchar_t> convertedValue = PtrToStringChars(url);
			const wchar_t *constValue = convertedValue;
			myBrowserWindow->Navigate(constValue);
		}
	}

	System::Void OnTabNavigationCompletedCallback()
	{
		OnTabNavigationCompleted();
	}

	#undef TranslateAccelerator

	virtual bool TranslateAccelerator(System::Windows::Interop::MSG% msg, System::Windows::Input::ModifierKeys modifiers) override
	{
		::MSG m = ConvertMessage(msg);
		/*if (msg.message == WM_SYSKEYDOWN || msg.message == WM_KEYDOWN)
		{
			switch (m.wParam)
			{
				case VK_ESCAPE:
					myBrowserWindow->Reload();
					return true;
				case VK_F1:
					myBrowserWindow->Reload();
					return true;
			}
		}*/

		return false;
	}

	virtual bool TabInto(TraversalRequest^ request) override
	{
		if (request->FocusNavigationDirection == FocusNavigationDirection::First)
		{
			myBrowserWindow->SetFocus();
		}

		return true;
	}

	protected:

		System::Runtime::InteropServices::HandleRef WebView2BrowserWrapper::BuildWindowCore(System::Runtime::InteropServices::HandleRef parentHwnd) override
		{
			myWin32Window = CreateWindowEx(0,
				"static",
				"",
				WS_CHILD | WS_VISIBLE,
				0, 0, myHostWindowWidth, myHostWindowHeight,
				parentHwnd.Handle,
				System::IntPtr::Zero,
				System::IntPtr::Zero, NULL);

			pin_ptr<const wchar_t> convertedValue = PtrToStringChars(myInitialUrl);
			const wchar_t *constValue = convertedValue;			

			TabNavigationCompletedCallback^ tabNavigationCompletedCallback = gcnew TabNavigationCompletedCallback(this, &WebView2BrowserWrapper::OnTabNavigationCompletedCallback);
			pin_ptr<TabNavigationCompletedCallback^> tmp = &tabNavigationCompletedCallback;
			System::IntPtr funcPtr = Marshal::GetFunctionPointerForDelegate(tabNavigationCompletedCallback);
			myBrowserWindow->InitInstance((HWND)myWin32Window.ToPointer(), constValue, (BrowserWindow::TabNavigationCompletedCallback)funcPtr.ToPointer());

			return HandleRef(this, System::IntPtr(myWin32Window));
		}

		System::IntPtr WndProc(System::IntPtr hwnd, int msg, System::IntPtr wParam, System::IntPtr lParam, bool% handled) override
		{
			handled = false;
			switch (msg)
			{
				case WM_SIZE:
				{
					if (myBrowserWindow != nullptr)
					{
						RECT bounds;
						GetClientRect((HWND)hwnd.ToPointer(), &bounds);
						int newWidth = LOWORD((DWORD)lParam.ToPointer());
						int newHeight = HIWORD((DWORD)lParam.ToPointer());
						MoveWindow((HWND)myWin32Window.ToPointer(), bounds.left + 5,bounds.top + 5, newWidth, newHeight, TRUE);
						myBrowserWindow->ResizeTabWebViews();
					}
				}
				break;
			}
			return System::IntPtr::Zero;
		}
				
		System::Void WebView2BrowserWrapper::DestroyWindowCore(System::Runtime::InteropServices::HandleRef hwnd) override
		{
			DestroyWindow((HWND)hwnd.Handle.ToPointer());
		}

	private:

		::MSG ConvertMessage(System::Windows::Interop::MSG% msg) 
		{
			::MSG m;
			m.hwnd = (HWND)msg.hwnd.ToPointer();
			m.lParam = (LPARAM)msg.lParam.ToPointer();
			m.message = msg.message;
			m.wParam = (WPARAM)msg.wParam.ToPointer();

			m.time = msg.time;

			POINT pt;
			pt.x = msg.pt_x;
			pt.y = msg.pt_y;
			m.pt = pt;

			return m;
		}
	};
}
