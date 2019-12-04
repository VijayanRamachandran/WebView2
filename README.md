
#  WebView2Browser

In 2019 Microsoft announced Win32 preview of WebViewControl powered by the Chromium-based Microsoft Edge. To demonstrate the new WebView’s capabilities, Microsoft built a sample browser app using the WebView2 APIs. The intent was to develop a rich sample that benefits other developers building on top of WebView2, and to provide direct feedback to the rest of the WebView2 team from first-hand app-building experience. The sample features an array of functionalities, such as navigation, searching from the address bar, tabs, favorites, history, and verifying a secure connection. Below are some of links which provide information about the demonstration.

[https://blogs.windows.com/msedgedev/2019/08/15/webview2browse-sample-for-webview2/#6fXwIcMTc0ODCKuG.97](https://blogs.windows.com/msedgedev/2019/08/15/webview2browse-sample-for-webview2/#6fXwIcMTc0ODCKuG.97)

[https://docs.microsoft.com/en-us/microsoft-edge/hosting/webview2](https://docs.microsoft.com/en-us/microsoft-edge/hosting/webview2)

#  WebView2Browser in WPF

We have done prototype to host the WebView2Control in WPF. Below are the requisites and Steps to run the WPF prototype.

##  Requisites

-   [Microsoft Edge (Chromium) Dev Channel - Latest](https://www.microsoftedgeinsider.com/en-us/download/)  installed on a supported OS.
-   [Visual Studio - 2019](https://visualstudio.microsoft.com/vs/)  with C++ support installed.
-   [Microsoft.Web.WebView2 - Latest](https://www.nuget.org/packages/Microsoft.Web.WebView2) SDK ( Nuget Package )
-   [Microsoft.Windows.ImplementationLibrary - Latest](https://www.nuget.org/packages/Microsoft.Windows.ImplementationLibrary) SDK ( Nuget Package )

##  Steps To Execute Prototype

1. After performing all prerequisites clone all Prototypes from https://github.com/VijayanRamachandran/WebView2.git
2. Execute WPFHostWindow.exe available in respective bin folder.

##  Respository Information

| Folder| Information |
|--|--|
| WebView2Browser-WithoutToolbar-Dll|  C++ DLL which wraps call to WebView2 API's |	
| WebView2BrowserWrapper |  C# Wrapper |	
| WPFHostWindow - Html - Table - Angular | WPF Exe which hosts WebView2 and Renders Angular 9 Material Table |
| WPFHostWindow - Html - Table | WPF Exe which hosts WebView2 and Renders Html Table with Hardcoded Data |
| WPFHostWindow - KeyBoard-Interaction | WPF Exe which hosts some WPF Controls and WebView2 Control to check the TAB Key Interaction ( Focus ) |
| WPFHostWindow - Popup | WPF Exe which hosts Modal WPF Window which renders PDF in WebView2 Control |
| WPFHostWindow - Pdf | WPF Exe which hosts WebView2 and PDF is loaded to WebView2. |
| WPFHostWindow - TwoControls | WPF Exe which hosts Multiple WebView2. |
