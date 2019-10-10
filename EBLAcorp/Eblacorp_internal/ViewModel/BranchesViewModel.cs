using Eblacorp_internal.Commands;
using Eblacorp_internal.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eblacorp_internal.ViewModel
{
    class BranchesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Models.BranchesModel> Branches { set; get; }
        public BranchesDAL branchDB = new BranchesDAL();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));

            }
        }

        private int branches_id;

        public int Branches_id
        {
            get { return branches_id; }
            set
            {
                branches_id = value;
                NotifyPropertyChanged("Branches_id");
            }
        }

        private string lisenceNum;

        public string LisenceNum
        {
            get { return lisenceNum; }
            set
            {
                lisenceNum = value;
                NotifyPropertyChanged("LisenceNum");

            }
        }


        private string fileNum;
        public string FileNum
        {
            get { return fileNum; }
            set
            {
                fileNum = value;
                NotifyPropertyChanged("FileNum");

            }
        }

        private string companyName;

        public string CompanyName
        {
            get
            {
                return companyName;

            }
            set
            {
                companyName = value;
                NotifyPropertyChanged("CompanyName");

            }
        }
        private string branchName;

        public string BranchName
        {
            get { return branchName; }
            set
            {
                branchName = value;
                NotifyPropertyChanged("BranchName");

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
            get
            {
                return referenceNumber;
            }
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

        private string block;

        public string Block
        {
            get { return block; }
            set
            {
                block = value;
                NotifyPropertyChanged("Block");

            }
        }
        private string street;

        public string Street
        {
            get { return street; }
            set
            {
                street = value;
                NotifyPropertyChanged("Street"); 

            }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                NotifyPropertyChanged("Phone");

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

        private string searchByBranch;

        public string SearchByBranch
        {
            get { return searchByBranch; }
            set
            {
                searchByBranch = value;
                Branches = branchDB.searchByBranchName(searchByBranch);
            }
        }
        private string searchByCompany;

        public string SearchByCompany
        {
            get { return searchByCompany; }
            set
            {
                searchByCompany = value;
                Branches = branchDB.searchByCompanyName(searchByCompany);
            }
        }









        //Relay Commands
        public RelayCommand addBranch { get; private set; }
        public RelayCommand updateBranch { get; private set; }
        public RelayCommand deleteBranch { get; private set; }
        public RelayCommand resetBranch { get; private set; }


        private Models.BranchesModel selectedBranch;
        public Models.BranchesModel SelectedBranch
        {
            get { return selectedBranch; }
            set
            {
                selectedBranch = value;
                selectedItemHelper();
            }
        }

        private void selectedItemHelper()
        {
            if (SelectedBranch != null)
            {
                  Branches_id       = SelectedBranch.Branches_id;
                  LisenceNum        = SelectedBranch.LisenceNum;
                  FileNum           = SelectedBranch.FileNum;
                  CompanyName       = SelectedBranch.CompanyName;
                  BranchName        = SelectedBranch.BranchName;
                  ContractNumber    = SelectedBranch.ContractNumber;
                  ReferenceNumber   = SelectedBranch.ReferenceNumber;
                  AutomatedNumber   = SelectedBranch.AutomatedNumber;
                  Area              = SelectedBranch.Area;
                  Block             = SelectedBranch.block;
                  Street            = SelectedBranch.street;
                  Phone             = SelectedBranch.phone;
                  Governate         = SelectedBranch.Governate;
                  BusinessField     = SelectedBranch.BusinessField;
                  CivilNumber       = SelectedBranch.CivilNumber;
            }
        }


        public void addBranchCommand(object obj)
        {
            if (branchDB.addBranches( LisenceNum, FileNum,  CompanyName,  BranchName,  ContractNumber,
                                 ReferenceNumber,  AutomatedNumber,  Area,  block,  street,
                                 phone,  Governate,  BusinessField,  CivilNumber))
            {
                Branches.Add(new Models.BranchesModel
                {
                  LisenceNum        = LisenceNum,
                  FileNum           = FileNum,
                  CompanyName       = CompanyName,
                  BranchName        = BranchName,
                  ContractNumber    = ContractNumber,
                  ReferenceNumber   = ReferenceNumber,
                  AutomatedNumber   = AutomatedNumber,
                  Area              = Area,
                  block             = block,
                  street            = street,
                  phone             = phone,
                  Governate         = Governate,
                  BusinessField     = BusinessField,
                  CivilNumber       = CivilNumber,



                });
            }
        }

        public void updateBranchCommand(object obj)
        {
            if (branchDB.updateBranch(Branches_id, LisenceNum, FileNum, CompanyName, BranchName, ContractNumber,
                                 ReferenceNumber, AutomatedNumber, Area, block, street,
                                 phone, Governate, BusinessField, CivilNumber))
            {
                var found = Branches.FirstOrDefault(x => x.Branches_id == Branches_id);
                Branches.Remove(found);
                Branches.Add(new Models.BranchesModel
                {
                    LisenceNum = LisenceNum,
                    FileNum = FileNum,
                    CompanyName = CompanyName,
                    BranchName = BranchName,
                    ContractNumber = ContractNumber,
                    ReferenceNumber = ReferenceNumber,
                    AutomatedNumber = AutomatedNumber,
                    Area = Area,
                    block = block,
                    street = street,
                    phone = phone,
                    Governate = Governate,
                    BusinessField = BusinessField,
                    CivilNumber = CivilNumber,

                });
            }
        }
        public void deleteBranchCommand(object obj)
        {

            branchDB.deleteBranch(Branches_id);


            for (int i = 0; i < Branches.Count; i++)
            {
                var username = Branches[i];

                if (username.Branches_id == Branches_id)
                {
                    Branches.Remove(username);
                }
            }
        }



        public BranchesViewModel ()
        {
            Branches = branchDB.selectAllBranches();
            addBranch = new RelayCommand(addBranchCommand);
            deleteBranch = new RelayCommand(deleteBranchCommand);
            updateBranch = new RelayCommand(updateBranchCommand);
            //resetBranch = new RelayCommand();
        }
    }
}
