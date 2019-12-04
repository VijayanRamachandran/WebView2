
#pragma once

#include "WebView2.h"

class Tab
{
public:
	
	static Tab* CreateNewTab(HWND parentHWnd, IWebView2Environment* webView2Environment, LPCWSTR url);
	HRESULT ResizeWebView();
	HRESULT ShowHideTab(BOOL showTab);
	HRESULT Close();
	void SetFocus();
	void Reload();
	void Navigate(LPCWSTR url);

protected:

	HWND m_parentHWnd = nullptr;
	void* m_BrowserWindow;
	HRESULT Init(IWebView2Environment* webView2Environment, bool shouldBeActive, LPCWSTR url);

	int m_ContentWebViewId;
	static int m_ContentWebViewCounter;
};
