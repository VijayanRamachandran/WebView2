
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
            InitializeComponent();
        }

        private void On_UIReady(object sender, EventArgs e)
        {
            var width = Application.Current.MainWindow.ActualWidth;
            var height = Application.Current.MainWindow.ActualHeight;                        

            myWebView2BrowserWrapper1 = new WebView2BrowserWrapper.WebView2BrowserWrapper(width, 
                                                                                          height/2,
                                                                                          "https://www.google.com");            
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

            myWebView2BrowserWrapper1.OnTabNavigationCompleted -= OnTabNavigationCompleted;
        }

        private void Navigate_Click(object sender, RoutedEventArgs e)
        {
            myWebView2BrowserWrapper1.OnTabNavigationCompleted += OnTabNavigationCompleted;

            myStopWatch.Start();

            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)?.Replace("file:\\", "");
            myWebView2BrowserWrapper1.Navigate(path + "\\TableExample.html");
        }
    }
}
