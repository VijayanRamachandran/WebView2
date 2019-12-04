#pragma once

#include <wrl.h>

using namespace Microsoft::WRL;

class TabState
{
public:

	Microsoft::WRL::ComPtr<IWebView2WebView> m_contentWebView;
	Microsoft::WRL::ComPtr<IWebView2WebMessageReceivedEventHandler> m_messageBroker;
	
	EventRegistrationToken m_navStartingToken = {};
	EventRegistrationToken m_navCompletedToken = {};
	EventRegistrationToken m_messageBrokerToken = {};
};