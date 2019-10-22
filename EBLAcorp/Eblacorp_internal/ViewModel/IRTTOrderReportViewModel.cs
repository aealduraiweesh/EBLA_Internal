using Eblacorp_internal.Commands;
using Eblacorp_internal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Eblacorp_internal.ViewModel
{
    public class IRTTOrderReportViewModel
    {
        //print button
        public RelayCommand printButton { set; private get; }

        public void printCommand(object obj)
        {
            IRTTOrderReportView IRTTView = new IRTTOrderReportView();
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {


                // printDialog.PrintVisual(PAFMPView.PAFMGridPage1, "Printing in process");
                printDialog.PrintVisual(IRTTView.Report, "Printing in process");

            }
        }

        public IRTTOrderReportViewModel()
        {
            printButton = new RelayCommand(printCommand);
        }


    }
}
