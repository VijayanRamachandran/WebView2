
#include "BrowserWindow.h"
#include "framework.h"
#include "shlobj.h"
#include <Urlmon.h>

#pragma comment (lib, "Urlmon.lib")

using namespace Microsoft::WRL;

std::map<int,Microsoft::WRL::ComPtr<IWebView2Environment>> m_UserEnvironments;
int BrowserWindow::m_UserDataEnvironmentCounter = 0;
BrowserWindow::TabNavigationCompletedCallback m_TabNavigationCompletedCallback = NULL;

BOOL BrowserWindow::InitInstance(HWND parentHandle, const wchar_t* url, TabNavigationCompletedCallback tabNavigationCompletedCallback)
{
	m_UserDataEnvironmentId = m_UserDataEnvironmentCounter++;
	m_TabNavigationCompletedCallback = tabNavigationCompletedCallback;

	TCHAR path[MAX_PATH];
	std::wstring dataDirectory;
	HRESULT folderPathHResult = SHGetFolderPath(nullptr, CSIDL_APPDATA, NULL, 0, path);
	if (SUCCEEDED(folderPathHResult))
	{
		dataDirectory = std::wstring(path);
		dataDirectory.append(L"\\Microsoft\\");
	}
	else
	{
		dataDirectory = std::wstring(L".\\");
	}

	dataDirectory.append(L"WebView2Browser");
	dataDirectory.append(L"\\User Data");	

	HRESULT hr = CreateWebView2EnvironmentWithDetails(nullptr, dataDirectory.c_str(),
		L"", Callback<IWebView2CreateWebView2EnvironmentCompletedHandler>(
			[this](HRESULT result, IWebView2Environment* env) -> HRESULT
	{
		RETURN_IF_FAILED(result);

		std::map<int,Microsoft::WRL::ComPtr<IWebView2Environment>>::iterator iterator = m_UserEnvironments.find(m_UserDataEnvironmentId);
        if (iterator == m_UserEnvironments.end())
        {
			m_UserEnvironments.insert(std::pair<int,Microsoft::WRL::ComPtr<IWebView2Environment>>(m_UserDataEnvironmentId, std::move(env)));
        }

		return TRUE;

	}).Get());

	if (!SUCCEEDED(hr))
	{
		OutputDebugString(L"Content WebViews environment creation failed\n");
		return FALSE;
	}

	m_tab = Tab::CreateNewTab(parentHandle,m_UserEnvironments.at(m_UserDataEnvironmentId).Get(), url);

	return TRUE;
}

void BrowserWindow::SetFocus()
{
	if( m_tab != NULL )
	{
		m_tab->SetFocus();
	}
}

void BrowserWindow::Reload()
{
	if( m_tab != NULL )
	{
		m_tab->SetFocus();
	}
}

LRESULT CALLBACK BrowserWindow::WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    switch (message)
    {
		case WM_SIZE:

			break;
		case WM_CLOSE:

			break;
		default:
		{
			return DefWindowProc(hWnd, message, wParam, lParam);
		}		
	}
	return 0;
}

HRESULT BrowserWindow::HandleTabNavCompleted(IWebView2WebView* webview, IWebView2NavigationCompletedEventArgs* args)
{
	BOOL navigationSucceeded = FALSE;
    args->get_IsSuccess(&navigationSucceeded);

    if (navigationSucceeded)
	{
		(m_TabNavigationCompletedCallback)();
	}
	return S_OK;
}

HRESULT BrowserWindow::ResizeTabWebViews()
{
	if( m_tab != NULL )
	{
		m_tab->ResizeWebView();
	}
	return S_OK;
}

HRESULT BrowserWindow::Close()
{
	if( m_tab != NULL )
	{
		m_tab->Close();
	}
	return S_OK;
}

void BrowserWindow::Navigate(const wchar_t* url)
{
	if( m_tab != NULL )
	{
		m_tab->Navigate(url);
	}
}
