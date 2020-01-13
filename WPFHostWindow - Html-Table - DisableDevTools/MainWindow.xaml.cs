
using System;
using System.IO;
using System.Diagnostics;
using System.Windows;

namespace WPFHostWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WebView2BrowserWrapper.WebView2BrowserWrapper myWebView2BrowserWrapper1;
        private Stopwatch myStopWatch = new Stopwatch();
        public MainWindow()
        {
            myStopWatch.Start();

            InitializeComponent();
        }

        private void On_UIReady(object sender, EventArgs e)
        {
            var width = Application.Current.MainWindow.ActualWidth;
            var height = Application.Current.MainWindow.ActualHeight;            

            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)?.Replace("file:\\", "");

            myWebView2BrowserWrapper1 = new WebView2BrowserWrapper.WebView2BrowserWrapper(width, 
                                                                                          height/2,
                                                                                          path + "\\TableExample.html");
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

            string message = "HTML - Table - OnTabNavigationCompleted; Duration In MilliSeconds - " + difference;
            EventLog.WriteEntry(source, message, EventLogEntryType.Warning);
        }

        private void OnPostScriptClick(object sender, RoutedEventArgs e)
        {
            var script1 = "var canvas = document.getElementById(\"ImageCanvas1\");" + 
                         "var ctx = canvas.getContext(\"2d\");" +
                         "var img = document.getElementById(\"source1\");" + 
                         "ctx.drawImage(img, 0, 0);";

            var script2 = "var canvas = document.getElementById(\"ImageCanvas2\");" +
                            "var ctx = canvas.getContext(\"2d\");" +
                            "var img = document.getElementById(\"source2\");" +
                            "ctx.drawImage(img, 0, 0);";

            myWebView2BrowserWrapper1.PostScript(script1);
            myWebView2BrowserWrapper1.PostScript(script2);
        }
    }
}
