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
    class PAFMReportViewModel
    {
        //print button
        public RelayCommand printButton { set; private get; }

        public void printCommand(object obj)
        {
            PAFMPReportView PAFMReportView = new PAFMPReportView();

            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() != true) return;

            PAFMReportView.PAFMFlowDocument.PageHeight = pd.PrintableAreaHeight;
            PAFMReportView.PAFMFlowDocument.PageWidth = pd.PrintableAreaWidth;
            PAFMReportView.PAFMFlowDocument.ColumnWidth = pd.PrintableAreaWidth;
            PAFMReportView.PAFMFlowDocument.ColumnGap = 0;

            IDocumentPaginatorSource idocument = PAFMReportView.PAFMFlowDocument as IDocumentPaginatorSource;

            pd.PrintDocument(idocument.DocumentPaginator, "Printing Flow Document...");
        }

        public PAFMReportViewModel()
        {
            printButton = new RelayCommand(printCommand);
        }
    }
}
