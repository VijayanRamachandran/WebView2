
using System;
using System.IO;
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

            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)?.Replace("file:\\", "");

            myWebView2BrowserWrapper1 = new WebView2BrowserWrapper.WebView2BrowserWrapper(width, 
                                                                                          height/2,
                                                                                          path + "\\SamplePdf.pdf");
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
