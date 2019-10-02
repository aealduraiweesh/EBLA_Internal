﻿using Eblacorp_internal.Commands;
using Eblacorp_internal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Eblacorp_internal.ViewModel
{
    class PAFMReportViewModel
    {
        //print button
        public RelayCommand printButton { set; private get; }

        public void printCommand(object obj)
        {
            PAFMPReportView PAFMPView = new PAFMPReportView();
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(PAFMPView.PAFMGrid, "Printing in process");
            }
        }

        public PAFMReportViewModel()
        {
            printButton = new RelayCommand(printCommand);
        }
    }
}