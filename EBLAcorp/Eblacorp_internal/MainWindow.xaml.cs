﻿using Eblacorp_internal.ViewModel;
using Eblacorp_internal.Views;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eblacorp_internal
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

        private void EmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EmployeeViewModel();
        }

        private void CompanyButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CompanyViewModel();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BranchButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new BranchesView();
        }

        private void EmployeeReport_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new PAFMPReportView();
        }

        private void DelegateButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DelegateView();
        }

        private void IRTTOrderReport_Click(object sender, RoutedEventArgs e)
        {
           DataContext = new IRTTOrderReportView();
        }

        private void PRReport_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new PRReportView();
        }
    }
}
