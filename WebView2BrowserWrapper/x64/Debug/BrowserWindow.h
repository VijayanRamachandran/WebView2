
#pragma once

#include "Tab.h"

class __declspec( dllexport ) BrowserWindow
{
public:	

	typedef void (CALLBACK __stdcall * TabNavigationCompletedCallback)();

	HRESULT ResizeTabWebViews();
	HRESULT Close();
	BOOL InitInstance(HWND parentHandle, const wchar_t* url, TabNavigationCompletedCallback tabNavigationCompletedCallback);
	void Navigate(const wchar_t* url);
	void SetFocus();
	void Reload();
	HRESULT HandleTabNavCompleted(IWebView2WebView* webview, IWebView2NavigationCompletedEventArgs* args);
	LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam);

protected:

	Tab* m_tab = NULL;	
	int m_UserDataEnvironmentId;
	static int m_UserDataEnvironmentCounter;
};
