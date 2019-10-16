using Eblacorp_internal.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Eblacorp_internal.ViewModel
{
    class PRReportViewModel
    {
        //print button
        public RelayCommand printButton { set; private get; }

        public void printCommand(object obj)
        {
            PRReportViewModel PRReportview = new PRReportViewModel();
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {


                // printDialog.PrintVisual(PAFMPView.PAFMGridPage1, "Printing in process");
             //   printDialog.PrintVisual(PRReportview.PRReportGrid, "Printing in process");

            }
        }

        public PRReportViewModel()
        {
            printButton = new RelayCommand(printCommand);
        }


    }
}
