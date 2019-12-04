
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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void On_UIReady(object sender, EventArgs e)
        {
            var width = Application.Current.MainWindow.ActualWidth;
            var height = Application.Current.MainWindow.ActualHeight;

            PersonName.Focus();

            myWebView2BrowserWrapper1 = new WebView2BrowserWrapper.WebView2BrowserWrapper(width, 
                                                                                          height/2,
                                                                                          "https://www.google.com/");
            ControlHostElement1.Child = myWebView2BrowserWrapper1;
            myWebView2BrowserWrapper1.MessageHook += OnWebView2BrowserWrapperMessageHook;
        }

        private IntPtr OnWebView2BrowserWrapperMessageHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            handled = false;
            return new IntPtr();
        }
    }
}
