
using System;
using System.Windows.Controls;
using System.Diagnostics;

namespace WPFHostWindow.UserControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WebView2UserControl : UserControl
    {
        private WebView2BrowserWrapper.WebView2BrowserWrapper myWebView2BrowserWrapper1;
        private Stopwatch myStopWatch = new Stopwatch();        

        public WebView2UserControl()
        {
            myStopWatch.Start();

            InitializeComponent();
        }

        private void On_UIReady(object sender, EventArgs e)
        {
            myWebView2BrowserWrapper1 = new WebView2BrowserWrapper.WebView2BrowserWrapper(ControlHostElement1.ActualWidth,
                                                                                          ControlHostElement1.ActualHeight,
                                                                                          "http://localhost:3000");
            myWebView2BrowserWrapper1.OnTabNavigationCompleted += OnTabNavigationCompleted;
            ControlHostElement1.Child = myWebView2BrowserWrapper1;
        }

        private void OnTabNavigationCompleted()
        {
            string source = "WebView2UserControl";
            string log = "Application";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }

            myStopWatch.Stop();

            var difference = myStopWatch.ElapsedMilliseconds;

            string message = "HTML - Table - Angular9 - OnTabNavigationCompleted; Duration In MilliSeconds - " + difference;
            EventLog.WriteEntry(source, message, EventLogEntryType.Warning);
        }
    }
}
