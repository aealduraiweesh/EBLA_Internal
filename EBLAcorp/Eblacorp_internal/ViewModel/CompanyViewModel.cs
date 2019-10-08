using Eblacorp_internal.Commands;
using Eblacorp_internal.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Eblacorp_internal.ViewModel
{
    public class CompanyViewModel : INotifyPropertyChanged
    {
        //Observable collection to hold all the company table values and update the view automatically 
        public ObservableCollection<Models.CompanyModel> Company { get; set; }

        //Instance of the companyModel class
        DAL.CompanyDAL companyDB = new DAL.CompanyDAL();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));

            }
        }

        #region RelayCommands
        //Add Company to DB
        public RelayCommand addCompanyButton { get; private set; }
        public RelayCommand deleteCompanyButton { get; private set; }
        public RelayCommand resetCompanyButton { get; private set; }
        public RelayCommand updateCompanyButton { get; private set; }


        public void updateCompanyCommand(object obj)
        {
          
          if(companyDB.updateCompany(Comp_ID,ManagerName, CivilNumber, DelegateName, CompanyName, ContractNumber, ReferenceNumber, AutomatedNumber,
                                    Area, block, street, phone, Governate, BusinessField, ManagerNameEng, CompanyNameEng, BusinessFieldEng))
            {
                var found = Company.FirstOrDefault(x => x.Comp_ID == Comp_ID);
                Company.Remove(found);
                Company.Add(new Models.CompanyModel
                {
                    Comp_ID = Comp_ID,
                    ManagerName = ManagerName,
                    CivilNumber = CivilNumber,
                    CompanyName = CompanyName,
                    ContractNumber = ContractNumber,
                    ReferenceNumber = ReferenceNumber,
                    AutomatedNumber = AutomatedNumber,
                    Area = Area,
                    block = block,
                    street = street,
                    phone = phone,
                    Governate = Governate,
                    BusinessField = BusinessField,
                    ManagerNameeng = ManagerNameEng,
                    CompanyNameeng = CompanyNameEng,
                    BusinessFieldEng = BusinessFieldEng
                }) ;
            }
        }
        public void resetCompanyCommand(object obj)
        {
            CompanyView companyV = new CompanyView();
            PrintDialog printDialog = new PrintDialog();
            if(printDialog.ShowDialog()==true)
            {
                printDialog.PrintVisual(companyV.myGrid, "Printing in process");
            }
        }

        public void deleteCompanyCommand(object obj)
        {
            companyDB.deleteCompany(Comp_ID);


            for (int i = 0; i < Company.Count; i++)
            {
                var username = Company[i];

                if (username.Comp_ID == Comp_ID)
                {
                    Company.Remove(username);
                }
            }
        }
        public void addCompanyCommand(object obj)
        {
            if(companyDB.addCompany(ManagerName, CivilNumber, DelegateName, CompanyName, ContractNumber, ReferenceNumber, AutomatedNumber, 
                                 Area, block, street, phone, Governate, BusinessField, ManagerNameEng, CompanyNameEng, BusinessFieldEng))
            {
                Company.Add(new Models.CompanyModel
                {
                    ManagerName = ManagerName,
                    CivilNumber = CivilNumber,
                    CompanyName = CompanyName,
                    ContractNumber =ContractNumber,
                    ReferenceNumber = ReferenceNumber,
                    AutomatedNumber =AutomatedNumber,
                    Area = Area,
                    block = block,
                    street = street,
                    phone = phone,
                    Governate = Governate,
                    BusinessField = BusinessField,
                    ManagerNameeng =ManagerNameEng,
                    CompanyNameeng =CompanyNameEng,
                    BusinessFieldEng =BusinessFieldEng
                });
                    
                    
            }
        }
        #endregion

        #region View to ViewModel
        //This holds the values selected bt the data grid
        private Models.CompanyModel selectedCompanyDataGrid { set; get; }
        public Models.CompanyModel SelectedCompanyDataGrid
        {
            get { return selectedCompanyDataGrid; }

            set
            {
                selectedCompanyDataGrid = value;
                selectedEmployeeHelper();

            }
        }

        public void selectedEmployeeHelper()
        {
            if (SelectedCompanyDataGrid != null) //This is required to avoic null reference after deleting
            {
                //We load our fields from the selection
                Comp_ID = selectedCompanyDataGrid.Comp_ID;
                ManagerName = selectedCompanyDataGrid.ManagerName;
                CivilNumber = selectedCompanyDataGrid.CivilNumber;
                CompanyName = selectedCompanyDataGrid.CompanyName;
                ContractNumber = selectedCompanyDataGrid.ContractNumber;
                ReferenceNumber = selectedCompanyDataGrid.ReferenceNumber;
                AutomatedNumber = selectedCompanyDataGrid.AutomatedNumber;
                Area = selectedCompanyDataGrid.Area;
                block = selectedCompanyDataGrid.block;
                street = selectedCompanyDataGrid.street;
                phone = selectedCompanyDataGrid.phone;
                Governate = selectedCompanyDataGrid.Governate;
                BusinessField = selectedCompanyDataGrid.BusinessFieldEng;
                ManagerNameEng = selectedCompanyDataGrid.ManagerNameeng;
                CompanyNameEng = selectedCompanyDataGrid.CompanyNameeng;
                BusinessFieldEng = selectedCompanyDataGrid.BusinessFieldEng;

            }

        }

        private string companyNameSearch;

        public string CompanyNameSearch
        {
            get
            {
                return companyNameSearch;
            }
            set
            {

                companyNameSearch = value;
                Company = companyDB.searchByCompanyName(companyNameSearch);
            }
        }


        private string delegateNameSearch;
        public string DelegateNameSearch
        {
            get
            {
                return delegateNameSearch;
            }
            set
            {
                delegateNameSearch = value;
                Company = companyDB.searchByDelegateName(delegateNameSearch);
            }
        }



        private int comp_id;
        public int Comp_ID
        {
            get { return comp_id; }
            set
            {
                comp_id = value;
                NotifyPropertyChanged("Comp_ID");
            }
        }
        private string managerName;

        public string ManagerName
        {
            get { return managerName; }
            set
            {
                managerName = value;
                NotifyPropertyChanged("ManagerName");

            }
        }

        private string civilNumber;

        public string CivilNumber
        {
            get { return civilNumber; }
            set
            {
                civilNumber = value;
                NotifyPropertyChanged("CivilNumber");

            }
        }
        private string delegateName;

        public string DelegateName
        {
            get { return delegateName; }
            set
            {
                delegateName = value;
                NotifyPropertyChanged("DelegateName");

            }
        }
        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set
            {
                companyName = value;
                NotifyPropertyChanged("CompanyName");

            }
        }
        private string contractNumber;

        public string ContractNumber
        {
            get { return contractNumber; }
            set
            {
                contractNumber = value;
                NotifyPropertyChanged("ContractNumber");

            }
        }
        private string referenceNumber;

        public string ReferenceNumber
        {
            get { return referenceNumber; }
            set
            {
                referenceNumber = value;
                NotifyPropertyChanged("ReferenceNumber");

            }
        }
        private string automatedNumber;

        public string AutomatedNumber
        {
            get { return automatedNumber; }
            set
            {
                automatedNumber = value;
                NotifyPropertyChanged("AutomatedNumber");

            }
        }

        private string area;
        public string Area
        {
            get { return area; }
            set
            {
                area = value;
                NotifyPropertyChanged("Area");

            }
        }
        private string Block;

        public string block
        {
            get { return Block; }
            set
            {
                Block = value;
                NotifyPropertyChanged("block");

            }
        }
        private string Street;

        public string street
        {
            get { return Street; }
            set
            {
                Street = value;
                NotifyPropertyChanged("street");

            }
        }
        private string Phone;

        public string phone
        {
            get { return Phone; }
            set
            {
                Phone = value;
                NotifyPropertyChanged("phone");

            }
        }
        private string governate;

        public string Governate
        {
            get { return governate; }
            set
            {
                governate = value;
                NotifyPropertyChanged("Governate");

            }
        }
        private string businessField;

        public string BusinessField
        {
            get { return businessField; }
            set
            {
                businessField = value;
                NotifyPropertyChanged("BusinessField");

            }
        }
        private string managerNameEng;

        public string ManagerNameEng
        {
            get { return managerNameEng; }
            set
            {
                managerNameEng = value;
                NotifyPropertyChanged("ManagerNameEng");

            }
        }
        private string companyNameEng;

        public string CompanyNameEng
        {
            get { return companyNameEng; }
            set
            {
                companyNameEng = value;
                NotifyPropertyChanged("CompanyNameEng");

            }
        }
        private string businessFieldEng;

        public string BusinessFieldEng
        {
            get { return businessFieldEng; }
            set
            {
                businessFieldEng = value;
                NotifyPropertyChanged("BusinessFieldEng");

            }
        }













        #endregion

        public CompanyViewModel()
        {
            Company = companyDB.selectAllEmployees();


            //Buttons
            addCompanyButton = new RelayCommand(addCompanyCommand);
            deleteCompanyButton = new RelayCommand(deleteCompanyCommand);
            resetCompanyButton = new RelayCommand(resetCompanyCommand);
            updateCompanyButton = new RelayCommand(updateCompanyCommand);
        }
    }
}
