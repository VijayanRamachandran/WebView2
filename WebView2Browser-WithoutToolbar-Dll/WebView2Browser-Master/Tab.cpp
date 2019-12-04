
#include "framework.h"
#include "BrowserWindow.h"
#include "Tab.h"
#include "TabState.h"


using namespace Microsoft::WRL;
std::map<int,TabState*> m_TabStates;
int Tab::m_ContentWebViewCounter = 0;

Tab* Tab::CreateNewTab(HWND parentHWnd, IWebView2Environment* webView2Environment, LPCWSTR url)
{
	Tab* tab = new Tab();
	tab->m_ContentWebViewId = m_ContentWebViewCounter++;
	tab->m_parentHWnd = parentHWnd;
	tab->Init(webView2Environment, true, url);

	return tab;
}

HRESULT Tab::ShowHideTab(BOOL showTab)
{
	m_TabStates.at(m_ContentWebViewId)->m_contentWebView->put_IsVisible(showTab);
	return S_OK;
}

HRESULT Tab::Close()
{
	ShowHideTab(FALSE);
	m_TabStates.at(m_ContentWebViewId)->m_contentWebView->Close();
	return S_OK;
}

HRESULT Tab::ResizeWebView()
{
	if(m_TabStates.size() > 0)
	{
		RECT bounds;
		GetClientRect(m_parentHWnd, &bounds);
		m_TabStates.at(m_ContentWebViewId)->m_contentWebView->put_Bounds(bounds);
	}
	return S_OK;
}

void Tab::SetFocus()
{
	m_TabStates.at(m_ContentWebViewId)->m_contentWebView->MoveFocus(WEBVIEW2_MOVE_FOCUS_REASON_PROGRAMMATIC);
}

void Tab::Reload()
{
	m_TabStates.at(m_ContentWebViewId)->m_contentWebView->Reload();
}

HRESULT Tab::Init(IWebView2Environment* webView2Environment, bool shouldBeActive, LPCWSTR url)
{
	HRESULT hr = webView2Environment->CreateWebView(m_parentHWnd, Callback<IWebView2CreateWebViewCompletedHandler>(
		[this, shouldBeActive, url](HRESULT result, IWebView2WebView* webview) -> HRESULT {
		if (!SUCCEEDED(result))
		{
			OutputDebugString(L"Tab WebView creation failed\n");
			return result;
		}

		std::map<int,TabState*>::iterator iterator = m_TabStates.find(m_ContentWebViewId);
        if (iterator == m_TabStates.end())
        {
			TabState* tabState = new TabState();
			tabState->m_contentWebView = webview;

            m_TabStates.insert(std::pair<int,TabState*>(m_ContentWebViewId, std::move(tabState)));
        }

		BrowserWindow* browserWindow = reinterpret_cast<BrowserWindow*>(GetWindowLongPtr(m_parentHWnd, GWLP_USERDATA));
		RETURN_IF_FAILED(m_TabStates.at(m_ContentWebViewId)->m_contentWebView->add_WebMessageReceived(m_TabStates.at(m_ContentWebViewId)->m_messageBroker.Get(), &(m_TabStates.at(m_ContentWebViewId)->m_messageBrokerToken)));
	  
		RETURN_IF_FAILED(m_TabStates.at(m_ContentWebViewId)->m_contentWebView->add_NavigationStarting(Callback<IWebView2NavigationStartingEventHandler>(
			[this, browserWindow](IWebView2WebView* webview, IWebView2NavigationStartingEventArgs* args) -> HRESULT
		{
			return S_OK;

		}).Get(), &(m_TabStates.at(m_ContentWebViewId)->m_navStartingToken)));

		RETURN_IF_FAILED(m_TabStates.at(m_ContentWebViewId)->m_contentWebView->add_NavigationCompleted(Callback<IWebView2NavigationCompletedEventHandler>(
			[this, browserWindow](IWebView2WebView* webview, IWebView2NavigationCompletedEventArgs* args) -> HRESULT
		{
			browserWindow->HandleTabNavCompleted(webview, args);
			return S_OK;

		}).Get(), &(m_TabStates.at(m_ContentWebViewId)->m_navCompletedToken)));        

		m_TabStates.at(m_ContentWebViewId)->m_contentWebView->Navigate(url);
		m_TabStates.at(m_ContentWebViewId)->m_contentWebView->put_IsVisible(TRUE);

		RECT bounds;
		GetClientRect(m_parentHWnd, &bounds);
		m_TabStates.at(m_ContentWebViewId)->m_contentWebView->put_Bounds(bounds);

		return S_OK;

	}).Get());

	return S_OK;
}


void Tab::Navigate(LPCWSTR url)
{
	m_TabStates.at(m_ContentWebViewId)->m_contentWebView.Get()->Navigate(url);
}

