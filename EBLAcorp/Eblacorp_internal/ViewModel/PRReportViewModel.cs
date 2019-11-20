using Eblacorp_internal.Commands;
using Eblacorp_internal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Eblacorp_internal.ViewModel
{
    class PRReportViewModel
    {
        //print button
        public RelayCommand printButton { set; private get; }

        public void printCommand(object obj)
        {
            PRReportView PAFMReportView = new PRReportView();

            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() != true) return;

            PAFMReportView.PRRFlowDocument.PageHeight = pd.PrintableAreaHeight;
            PAFMReportView.PRRFlowDocument.PageWidth = pd.PrintableAreaWidth;
            PAFMReportView.PRRFlowDocument.ColumnWidth = pd.PrintableAreaWidth;
            PAFMReportView.PRRFlowDocument.ColumnGap = 0;

            IDocumentPaginatorSource idocument = PAFMReportView.PRRFlowDocument as IDocumentPaginatorSource;

            pd.PrintDocument(idocument.DocumentPaginator, "Printing Flow Document...");
        }

        public PRReportViewModel()
        {
            printButton = new RelayCommand(printCommand);
        }


    }
}
