using Eblacorp_internal.Commands;
using Eblacorp_internal.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eblacorp_internal.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        //INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));

            }
        }

        //instance of the employee DAL
        EmployeeDAL employeeDB = new EmployeeDAL();

        //collection of the Employee table information
        public ObservableCollection<Models.EmployeeModel> Employee { get; set; } = new ObservableCollection<Models.EmployeeModel>();


        #region View to ViewModel
        //This holds the values selected bt the data grid
        private Models.EmployeeModel selectedEmployeeDataGrid { set; get; }
        public Models.EmployeeModel SelectedEmployeeDataGrid
        {
            get { return selectedEmployeeDataGrid; }

            set
            {
                selectedEmployeeDataGrid = value;
                selectedEmployeeHelper();
            }
        }

        public void selectedEmployeeHelper()
        {
            if (SelectedEmployeeDataGrid != null) //This is required to avoic null reference after deleting
            { 
                //We load our fields from the selection
                ID = selectedEmployeeDataGrid.ID;
                FirstName = selectedEmployeeDataGrid.FirstName;
                SecondName = selectedEmployeeDataGrid.SecondName;
                ThirdName = selectedEmployeeDataGrid.ThirdName;
                FourthName = selectedEmployeeDataGrid.FourthName;
                FamilyName = selectedEmployeeDataGrid.FamilyName;
                LatinName = selectedEmployeeDataGrid.LatinName;
                CivilNum = selectedEmployeeDataGrid.CivilNum;
                BirthPlace = selectedEmployeeDataGrid.BirthPlace;
                DOB = selectedEmployeeDataGrid.DOB;
                Gender = selectedEmployeeDataGrid.Gender;
                Religion = selectedEmployeeDataGrid.Religion;
                Nationality = selectedEmployeeDataGrid.Nationality;
                Career = selectedEmployeeDataGrid.Career;
                PassportNum = selectedEmployeeDataGrid.PassportNum;
                PassportEndDate = selectedEmployeeDataGrid.PassportEndDate;
                PassportType = selectedEmployeeDataGrid.PassportType;
                Education = selectedEmployeeDataGrid.Education;
                MaritalStatus = selectedEmployeeDataGrid.MaritalStatus;
                Salary = selectedEmployeeDataGrid.salary;
                Declration = selectedEmployeeDataGrid.declration;
                ResidencyNum = selectedEmployeeDataGrid.ResidencyNum;
                ResidencyEndDate = selectedEmployeeDataGrid.ResidencyEndDate;
                StartDate = selectedEmployeeDataGrid.StartDate;
                Duration = selectedEmployeeDataGrid.Duration;
                DurationEng = selectedEmployeeDataGrid.DurationEng;
                NationalityEng = selectedEmployeeDataGrid.NationalityEng;
                CareerEng = selectedEmployeeDataGrid.CareerEng;
                Note = selectedEmployeeDataGrid.Note;
                PassportIssueDate = selectedEmployeeDataGrid.PassportIssueDate;
                LicenseNumber = selectedEmployeeDataGrid.LicenseNumber;
                LicenseEndDate = selectedEmployeeDataGrid.LicenseEndDate;

            }

        }

        private string firstNameSearch;

        public string FirstNameSearch
        {
            get { return firstNameSearch; }
            set
            {
                firstNameSearch = value;
                Employee = employeeDB.searchByFirstName(FirstNameSearch);
            }
        }

        private string secondNameSearch;

        public string SecondNameSearch
        {
            get { return secondNameSearch; }
            set
            {
                secondNameSearch = value;
                Employee = employeeDB.searchBySecondName(secondNameSearch);
            }
        }
        private string thirdNameSearch;

        public string ThirdNameSearch
        {
            get { return thirdNameSearch; }
            set
            {
                thirdNameSearch = value;
                Employee = employeeDB.searchByThirdName(thirdNameSearch);
            }
        }
        private string fourthNameSearch;

        public string FourthNameSearch
        {
            get { return fourthNameSearch; }
            set
            {
                fourthNameSearch = value;
                Employee = employeeDB.searchByFourthName(fourthNameSearch);
            }
        }
        private string familyNameSearch;

        public string FamilyNameSearch
        {
            get { return familyNameSearch; }
            set
            {
                familyNameSearch = value;
                Employee = employeeDB.searchByFamilyName(FamilyNameSearch);
            }
        }

       

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        private string secondName;

        public string SecondName
        {
            get { return secondName; }
            set
            {
                secondName = value;
                NotifyPropertyChanged("SecondName");

            }
        }

        private string thirdName;

        public string ThirdName
        {
            get { return thirdName; }
            set
            {
                thirdName = value;
                NotifyPropertyChanged("ThirdName");

            }
        }

        private string fourthName;

        public string FourthName
        {
            get { return fourthName; }
            set
            {
                fourthName = value;
                NotifyPropertyChanged("FourthName");

            }
        }

        private string familyName;

        public string FamilyName
        {
            get { return familyName; }
            set
            {
                familyName = value;
                NotifyPropertyChanged("FamilyName");

            }
        }

        private string latinName;

        public string LatinName
        {
            get { return latinName; }
            set
            {
                latinName = value;
                NotifyPropertyChanged("LatinName");

            }
        }

        private long civilNum;

        public long CivilNum
        {
            get { return civilNum; }
            set
            {
                civilNum = value;
                NotifyPropertyChanged("CivilNum");

            }
        }

        private string birthPlace;

        public string BirthPlace
        {
            get { return birthPlace; }
            set
            {
                birthPlace = value;
                NotifyPropertyChanged("BirthPlace");

            }
        }

        private DateTime dOB;       

        public DateTime DOB
        {
            get { return dOB; }
            set
            {
                dOB = value;
                NotifyPropertyChanged("DOB");

            }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                NotifyPropertyChanged("Gender");
            }
        }

        private string religion;

        public string Religion
        {
            get { return religion; }
            set
            {
                religion = value;
                NotifyPropertyChanged("Religion");

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

        private string career;

        public string Career
        {
            get { return career; }
            set
            {
                career = value;
                NotifyPropertyChanged("Career");

            }
        }

        private long passportNum;

        public long PassportNum
        {
            get { return passportNum; }
            set
            {
                passportNum = value;
                NotifyPropertyChanged("PassportNum");

            }
        }

        private DateTime passportEndDate;

        public DateTime PassportEndDate
        {
            get { return passportEndDate; }
            set
            {
                passportEndDate = value;
                NotifyPropertyChanged("PassportEndDate");

            }
        }

        private string passportType;

        public string PassportType
        {
            get { return passportType; }
            set
            {
                passportType = value;
                NotifyPropertyChanged("PassportType");

            }
        }

        private string education;

        public string Education
        {
            get { return education; }
            set
            {
                education = value;
                NotifyPropertyChanged("Education");

            }
        }

        private string maritalStatus;

        public string MaritalStatus
        {
            get { return maritalStatus; }
            set
            {
                maritalStatus = value;
                NotifyPropertyChanged("MaritalStatus");

            }
        }

        private short salary;

        public short Salary
        {
            get { return salary; }
            set
            {
                salary = value;
                NotifyPropertyChanged("Salary");

            }
        }

        private long declration;

        public long Declration
        {
            get { return declration; }
            set
            {
                declration = value;
                NotifyPropertyChanged("Declration");

            }
        }

        private long residencyNum;

        public long ResidencyNum
        {
            get { return residencyNum; }
            set
            {
                residencyNum = value;
                NotifyPropertyChanged("ResidencyNum");

            }
        }

        private DateTime residencyEndDate;

        public DateTime ResidencyEndDate
        {
            get { return residencyEndDate; }
            set
            {
                residencyEndDate = value;
                NotifyPropertyChanged("ResidencyEndDate");

            }
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                NotifyPropertyChanged("StartDate");

            }
        }

        private long duration;

        public long Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                NotifyPropertyChanged("Duration");

            }
        }

        private long durationEng;

        public long DurationEng
        {
            get { return durationEng; }
            set { durationEng = value; }
        }


        private string nationalityEng;

        public string NationalityEng
        {
            get { return nationalityEng; }
            set
            {
                nationalityEng = value;
                NotifyPropertyChanged("NationalityEng");

            }
        }

        private string careerEng;

        public string CareerEng
        {
            get { return careerEng; }
            set
            {
                careerEng = value;
                NotifyPropertyChanged("CareerEng");

            }
        }

        private string note;

        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                NotifyPropertyChanged("Note");

            }
        }

        private DateTime passportIssueDate;

        public DateTime PassportIssueDate
        {
            get { return passportIssueDate; }
            set
            {
                passportIssueDate = value;
                NotifyPropertyChanged("PassportIssueDate");

            }
        }

        private string licenseNumber;

        public string LicenseNumber
        {
            get { return licenseNumber; }
            set
            {
                licenseNumber = value;
                NotifyPropertyChanged("LicenseNumber");

            }
        }

        private DateTime licenseEndDate;

        public DateTime LicenseEndDate
        {
            get { return licenseEndDate; }
            set
            {
                licenseEndDate = value;
                NotifyPropertyChanged("LicenseEndDate");

            }
        }




        #endregion


        #region Relay Commands
        //Adds Employee to Database
        public RelayCommand addEmployeeButton { get; private set; }
        //Deletes Employee from DB
        public RelayCommand deleteEmployeeButton { get; private set; }
        //Update selected Datagrid employee
        public RelayCommand updateEmployeeButton { get; private set; }

        //Reset fields
        public RelayCommand resetButton { get; private set; }


        public void addEmployeeCommand(object obj)
        {
          if(  employeeDB.addEmployee(FirstName, SecondName, ThirdName, FourthName, FamilyName, LatinName, CivilNum, BirthPlace, DOB, Gender, Religion, Nationality,
                                    Career, PassportNum, PassportEndDate, PassportType, Education, MaritalStatus, Salary, declration, ResidencyNum, ResidencyEndDate, StartDate,
                                    Duration, DurationEng, NationalityEng, CareerEng, Note, PassportIssueDate, LicenseNumber, LicenseEndDate))
            {
                Employee.Add(new Models.EmployeeModel
                {
                    ID = ID,
                    FirstName = FirstName,
                    SecondName = SecondName,
                    ThirdName = ThirdName,
                    FourthName = FourthName,
                    FamilyName = FamilyName,
                    LatinName = LatinName,
                    CivilNum = CivilNum,
                    BirthPlace = BirthPlace,
                    DOB = DOB,
                    Gender = Gender,
                    Religion = Religion,
                    Nationality = Nationality,
                    Career = Career,
                    PassportNum = PassportNum,
                    PassportEndDate = PassportEndDate,
                    PassportType = PassportType,
                    Education = Education,
                    MaritalStatus = MaritalStatus,
                    salary = salary,
                    declration = declration,
                    ResidencyNum = ResidencyNum,
                    ResidencyEndDate = ResidencyEndDate,
                    StartDate = StartDate,
                    Duration = Duration,
                    DurationEng = DurationEng,
                    NationalityEng = NationalityEng,
                    CareerEng = CareerEng,
                    Note = Note,
                    PassportIssueDate = PassportIssueDate,
                    LicenseNumber = LicenseNumber,
                    LicenseEndDate = LicenseEndDate
                });
            }


        }

        /// <summary>
        /// Updates the database and the collection depending on selection, we remove and add from the Observable collection to trigger the propertyChanged so it can update teh view.
        /// </summary>
        /// <param name="obj"></param>
        public void updateEmployeeCommand(object obj)
        {
           if( employeeDB.updateEmployee(ID, FirstName, SecondName, ThirdName, FourthName, FamilyName, LatinName, CivilNum, BirthPlace, DOB, Gender, Religion, Nationality,
                                    Career, PassportNum, PassportEndDate, PassportType, Education, MaritalStatus, Salary, declration, ResidencyNum, ResidencyEndDate, StartDate,
                                    Duration, DurationEng, NationalityEng, CareerEng, Note, PassportIssueDate, LicenseNumber, LicenseEndDate))
            {

           
                var found = Employee.FirstOrDefault(x => x.ID == ID);
                Employee.Remove(found);
                Employee.Add(new Models.EmployeeModel
                {
                    ID = ID,
                    FirstName = FirstName,
                    SecondName = SecondName,
                    ThirdName = ThirdName,
                    FourthName = FourthName,
                    FamilyName = FamilyName,
                    LatinName = LatinName,
                    CivilNum = CivilNum,
                    BirthPlace = BirthPlace,
                    DOB = DOB,
                    Gender = Gender,
                    Religion = Religion,
                    Nationality = Nationality,
                    Career = Career,
                    PassportNum = PassportNum,
                    PassportEndDate = PassportEndDate,
                    PassportType = PassportType,
                    Education = Education,
                    MaritalStatus = MaritalStatus,
                    salary = salary,
                    declration = declration,
                    ResidencyNum = ResidencyNum,
                    ResidencyEndDate = ResidencyEndDate,
                    StartDate = StartDate,
                    Duration = Duration,
                    DurationEng = DurationEng,
                    NationalityEng = NationalityEng,
                    CareerEng = CareerEng,
                    Note = Note,
                    PassportIssueDate = PassportIssueDate,
                    LicenseNumber = LicenseNumber,
                    LicenseEndDate = LicenseEndDate
                });

            }
        }


        /// <summary>
        /// deletes the whole row of the ID selected
        /// </summary>
        /// <param name="obj"></param>
        public void deleteEmployeeCommand(object obj)
        {
            employeeDB.deleteEmplotee(ID);



            for (int i = 0; i < Employee.Count; i++)
            {
                var username = Employee[i];

                if (username.ID == ID)
                {
                    Employee.Remove(username);
                }
            }
        }

        /// <summary>
        /// Reset employeee fields
        /// </summary>
        /// <param name="obj"></param>
        public void resetEmployeeCommand(object obj)
        {

        }
        #endregion



        public EmployeeViewModel()
        {
            Employee = employeeDB.selectAllEmployees();

            addEmployeeButton = new RelayCommand(addEmployeeCommand);
            deleteEmployeeButton = new RelayCommand(deleteEmployeeCommand);
            updateEmployeeButton = new RelayCommand(updateEmployeeCommand);
        }


    }
}
