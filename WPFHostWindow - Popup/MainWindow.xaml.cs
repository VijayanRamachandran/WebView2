﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFHostWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnModalDialogButtonClick(object sender, RoutedEventArgs e)
        {
            var modalDialog = new ModalDialog();
            modalDialog.ShowDialog();
        }
        private void OnModalessDialogButtonClick(object sender, RoutedEventArgs e)
        {
            var modalDialog = new ModalDialog();
            modalDialog.Show();
        }
    }
}
