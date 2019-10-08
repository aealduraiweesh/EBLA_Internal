using Eblacorp_internal.Commands;
using Eblacorp_internal.DAL;
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
    public class DelegateViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Models.DeletgateModel> Delegate { set; get; }
        public DelegateDAL delegateDB = new DelegateDAL();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));

            }
        }

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
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

        private string civil;

        public string Civil
        {
            get { return civil; }
            set
            {
                civil = value;
                NotifyPropertyChanged("Civil");

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

        private string nationality;

        public string Nationality
        {
            get { return nationality; }
            set
            {
                nationality = value;
                NotifyPropertyChanged("Nationality");

            }
        }

        private Models.DeletgateModel selectedDelegate;

        public  Models.DeletgateModel SelectedDelegate
        {
            get { return selectedDelegate; }
            set
            {
                selectedDelegate = value;
                selectedItemHelper();
            }
        }

        private void selectedItemHelper()
        {
            if (SelectedDelegate!=null)
            { 
            ID = SelectedDelegate.ID;
            DelegateName = SelectedDelegate.delegate1;
            CompanyName = SelectedDelegate.companyName;
            Civil = SelectedDelegate.Civil;
            Nationality = SelectedDelegate.Nationality;
            }
        }

     

        //Relay Commands
        public RelayCommand addDelegate { get; private set; }
        public RelayCommand updateDelegate { get; private set; }
        public RelayCommand deleteDelegate { get; private set; }
        public RelayCommand resetDelegate { get; private set; }

        public void addDelegateCommand(object obj)
        {
            if (delegateDB.addDelegate(DelegateName, CompanyName, Nationality, Civil))
            {
                Delegate.Add(new Models.DeletgateModel
                {
                    delegate1 = DelegateName,
                    Civil = Civil,
                    Nationality = Nationality,
                    companyName = CompanyName


                }) ;
            }
        }

        public void updateDelegateCommand(object obj)
        {
            if(delegateDB.updateDelegate(ID, DelegateName, CompanyName, Nationality, Civil))
            {
                var found = Delegate.FirstOrDefault(x => x.ID == ID);
                Delegate.Remove(found);
                Delegate.Add(new Models.DeletgateModel
                {
                    ID=ID,
                    delegate1 = DelegateName,
                    Civil = Civil,
                    Nationality = Nationality,
                    companyName = CompanyName


                }) ;
            }
        }
        public void deleteDelegateCommand(object obj)
        {

            delegateDB.deleteDelegate(ID);


            for (int i = 0; i < Delegate.Count; i++)
            {
                var username = Delegate[i];

                if (username.ID == ID)
                {
                    Delegate.Remove(username);
                }
            }
        }



        public DelegateViewModel()
        {
            Delegate = delegateDB.selectAllDelegates();
            addDelegate = new RelayCommand(addDelegateCommand);
            updateDelegate = new RelayCommand(updateDelegateCommand);
            deleteDelegate = new RelayCommand(deleteDelegateCommand);
        }

    }
}
