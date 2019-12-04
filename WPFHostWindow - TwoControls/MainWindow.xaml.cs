
using System;
using System.Windows;

namespace WPFHostWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WebView2BrowserWrapper.WebView2BrowserWrapper myWebView2BrowserWrapper1;
        private WebView2BrowserWrapper.WebView2BrowserWrapper myWebView2BrowserWrapper2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void On_UIReady(object sender, EventArgs e)
        {
            var width = Application.Current.MainWindow.ActualWidth;
            var height = Application.Current.MainWindow.ActualHeight;

            myWebView2BrowserWrapper1 = new WebView2BrowserWrapper.WebView2BrowserWrapper(width, height/2,"https://www.google.com/");
            ControlHostElement1.Child = myWebView2BrowserWrapper1;
            myWebView2BrowserWrapper1.MessageHook += OnWebView2BrowserWrapperMessageHook;


            myWebView2BrowserWrapper2 = new WebView2BrowserWrapper.WebView2BrowserWrapper(width, height / 2,"https://www.bing.com/");
            ControlHostElement2.Child = myWebView2BrowserWrapper2;
            myWebView2BrowserWrapper2.MessageHook += OnWebView2BrowserWrapperMessageHook;
        }

        private IntPtr OnWebView2BrowserWrapperMessageHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            handled = false;
            return new IntPtr();
        }

        private void OnHost1Click(object sender, RoutedEventArgs e)
        {
            myWebView2BrowserWrapper1.Navigate("https://www.gmail.com/");
        }

        private void OnHost2Click(object sender, RoutedEventArgs e)
        {
            myWebView2BrowserWrapper2.Navigate("https://www.hotmail.com/");
        }
    }
}
