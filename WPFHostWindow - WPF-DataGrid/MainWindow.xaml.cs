
using System;
using System.Windows;
using System.Diagnostics;

namespace WPFHostWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch myStopWatch = new Stopwatch();

        public MainWindow()
        {
            myStopWatch.Start();

            InitializeComponent();

            WPFParentMainWindow.Loaded += OnMainWindowLoaded;

            dataGrid.ItemsSource = Company.GetCompanies();
        }

        private void OnMainWindowLoaded(object sender, EventArgs e)
        {
            string source = "WebView2UserControl";
            string log = "Application";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }

            myStopWatch.Stop();

            var difference = myStopWatch.ElapsedMilliseconds;

            string message = "WPF DataGrid - OnMainWindowLoaded; Duration In MilliSeconds - " + difference;
            EventLog.WriteEntry(source, message, EventLogEntryType.Warning);
        }
    }
}
