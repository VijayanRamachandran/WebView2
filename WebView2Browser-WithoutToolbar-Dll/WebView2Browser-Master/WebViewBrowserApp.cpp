
// WebViewBrowserApp.cpp : Defines the entry point for the application.
//

#include "WebViewBrowserApp.h"
#include "BrowserWindow.h"

using namespace Microsoft::WRL;

void SetWindowSize();
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);
int GetDPIAwareBound(int bound);
HRESULT ResizeUIWebViews();

int m_minWindowWidth = 0;
int m_minWindowHeight = 0;
HWND m_hWnd = nullptr;
BrowserWindow* m_BrowserWindow;

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
					  _In_opt_ HINSTANCE hPrevInstance,
					  _In_ LPWSTR    lpCmdLine,
					  _In_ int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

	// Call SetProcessDPIAware() instead when using Windows 7 or any version
	// below 1703 (Windows 10).
	SetProcessDpiAwarenessContext(DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);

	WCHAR s_windowClass[MAX_LOADSTRING];
	LoadStringW(hInstance, IDC_WEBVIEWBROWSERAPP, s_windowClass, MAX_LOADSTRING);
	
	WNDCLASSEXW wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_WEBVIEWBROWSERAPP));
	wcex.hCursor = LoadCursor(nullptr, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = MAKEINTRESOURCEW(IDC_WEBVIEWBROWSERAPP);
	wcex.lpszClassName = s_windowClass;
	wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	if (!RegisterClassExW(&wcex))
	{
		return FALSE;
	}

	WCHAR s_title[MAX_LOADSTRING] = { 0 };
	LoadStringW(hInstance, IDS_APP_TITLE, s_title, MAX_LOADSTRING);

	//! Create Window
	m_hWnd = CreateWindowW(s_windowClass, s_title, WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

	if (!m_hWnd)
	{
		return FALSE;
	}

	//! Set Handle to Window
	//SetWindowLongPtr(m_hWnd, GWLP_USERDATA, reinterpret_cast<LONG_PTR>(this));

	SetWindowSize();
	ShowWindow(m_hWnd, nCmdShow);
	UpdateWindow(m_hWnd);

	m_BrowserWindow = new BrowserWindow();
	if (!m_BrowserWindow->InitInstance(m_hWnd))
	{
		delete m_BrowserWindow;
		return FALSE;
	}

	HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_WEBVIEWBROWSERAPP));

	MSG msg;
	while (GetMessage(&msg, nullptr, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int) msg.wParam;
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
		case WM_GETMINMAXINFO:
		{
			MINMAXINFO* minmax = reinterpret_cast<MINMAXINFO*>(lParam);
			minmax->ptMinTrackSize.x = m_minWindowWidth;
			minmax->ptMinTrackSize.y = m_minWindowHeight;
		}
		break;

		case WM_DPICHANGED:
		{
			SetWindowSize();
		}

		case WM_SIZE:
		{
			ResizeUIWebViews();

			if( m_BrowserWindow != NULL )
			{
				m_BrowserWindow->ResizeTabWebViews();
			}
		}
		break;

		case WM_CLOSE:
		{
			m_BrowserWindow->Close();
			DestroyWindow(m_hWnd);
		}
		break;

		case WM_NCDESTROY:
		{
			SetWindowLongPtr(hWnd, GWLP_USERDATA, NULL);
			PostQuitMessage(0);
		}
		break;

		case WM_PAINT:
		{
			PAINTSTRUCT ps;
			HDC hdc = BeginPaint(hWnd, &ps);
			EndPaint(hWnd, &ps);
		}
		break;

		default:
		{
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	}
	return 0;
}

void SetWindowSize()
{
	RECT clientRect;
	RECT windowRect;

	GetClientRect(m_hWnd, &clientRect);
	GetWindowRect(m_hWnd, &windowRect);

	int bordersWidth = (windowRect.right - windowRect.left) - clientRect.right;
	int bordersHeight = (windowRect.bottom - windowRect.top) - clientRect.bottom;

	m_minWindowWidth = GetDPIAwareBound(MIN_WINDOW_WIDTH) + bordersWidth;
	m_minWindowHeight = GetDPIAwareBound(MIN_WINDOW_HEIGHT) + bordersHeight;
}

int GetDPIAwareBound(int bound)
{
	// Remove the GetDpiForWindow call when using Windows 7 or any version
	// below 1607 (Windows 10). You will also have to make sure the build
	// directory is clean before building again.
	return (bound * GetDpiForWindow(m_hWnd) / DEFAULT_DPI);
}

HRESULT ResizeUIWebViews()
{
	// Workaround for black controls WebView issue in Windows 7
	HWND wvWindow = GetWindow(m_hWnd, GW_CHILD);
	while (wvWindow != nullptr)
	{
		UpdateWindow(wvWindow);
		wvWindow = GetWindow(wvWindow, GW_HWNDNEXT);
	}
	return S_OK;
}

