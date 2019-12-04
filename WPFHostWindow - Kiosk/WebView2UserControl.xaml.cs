
using System;
using System.Windows.Controls;
using System.Diagnostics;
using System.IO;

namespace WPFHostWindow.UserControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WebView2UserControl : UserControl
    {
        private WebView2BrowserWrapper.WebView2BrowserWrapper myWebView2BrowserWrapper1;
        private Stopwatch myStopWatch = new Stopwatch();
        private String myUrl;

        public String Url
        {
            set
            {
                myUrl = value;
            }
            get
            {
                return myUrl;
            }
        }

        public WebView2UserControl()
        {
            myStopWatch.Start();

            InitializeComponent();
        }

        private void On_UIReady(object sender, EventArgs e)
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)?.Replace("file:\\", "");

            myWebView2BrowserWrapper1 = new WebView2BrowserWrapper.WebView2BrowserWrapper(ControlHostElement1.ActualWidth,
                                                                                          ControlHostElement1.ActualHeight,
                                                                                          path + "\\SamplePdf.pdf");

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
