using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eblacorp_internal.DAL
{
    public class EmployeeDal
    {
        //SQL Connection
        static string myconnection = ConfigurationManager.ConnectionStrings["Ebla"].ConnectionString;

        //DataTable to store the database tables we are using
        public DataTable dt { get; set; } = new DataTable();

        //collection of the UserTable information
        public ObservableCollection<Models.EmployeeModel> employeeCollection { get; set; } = new ObservableCollection<Models.EmployeeModel>();



        /// <summary>
        /// Returns an observable collection with all whats in the Empoloyee table
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Models.EmployeeModel> selectAllEmployees()
        {

            //cleans employee collection
            employeeCollection.Clear();
            dt.Clear();
            //Connects to our database
            SqlConnection con = new SqlConnection(myconnection);
            //Saves the command to SqlCommand cmd
            SqlCommand cmd = new SqlCommand("Select*From Employee;", con);
            //Opens Connection
            con.Open();
            //Stores the table for this session
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            // Users_datatable = new DataTable(); //references the object
            //Filles data Table
            adp.Fill(dt);
            //Closes connection
            con.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                employeeCollection.Add(new Models.EmployeeModel
                {
                    ID = (int)dt.Rows[i]["ID"],
                    FirstName = dt.Rows[i]["FirstName"].ToString(),
                    SecondName = dt.Rows[i]["SecondName"].ToString(),
                    ThirdName = dt.Rows[i]["ThirdName"].ToString(),
                    FourthName = dt.Rows[i]["FourthName"].ToString(),
                    FamilyName = dt.Rows[i]["FamilyName"].ToString(),
                    LatinName = dt.Rows[i]["LatinName"].ToString(),
                    CivilNum = (long)dt.Rows[i]["CivilNum"],
                    BirthPlace = dt.Rows[i]["BirthPlace"].ToString(),
                    DOB = (DateTime)dt.Rows[i]["DOB"],
                    Gender = dt.Rows[i]["Gender"].ToString(),
                    Religion = dt.Rows[i]["Religion"].ToString(),
                    Nationality = dt.Rows[i]["Nationality"].ToString(),
                    Career = dt.Rows[i]["Career"].ToString(),
                    PassportNum = (long)dt.Rows[i]["PassportNum"],
                    PassportEndDate = (DateTime)dt.Rows[i]["PassportEndDate"],
                    PassportType = dt.Rows[i]["PassportType"].ToString(),
                    Education = dt.Rows[i]["Education"].ToString(),
                    MaritalStatus = dt.Rows[i]["MaritalStatus"].ToString(),
                    salary = (short)dt.Rows[i]["salary"],
                    declration = (long)dt.Rows[i]["declration"],
                    ResidencyNum = (long)dt.Rows[i]["ResidencyNum"],
                    ResidencyEndDate = (DateTime)dt.Rows[i]["ResidencyEndDate"],
                    StartDate = (DateTime)dt.Rows[i]["StartDate"],
                    Duration = (long)dt.Rows[i]["Duration"],
                    DurationEng = (long)dt.Rows[i]["DurationEng"],
                    NationalityEng = dt.Rows[i]["NationalityEng"].ToString(),
                    CareerEng = dt.Rows[i]["CareerEng"].ToString(),
                    Note = dt.Rows[i]["Note"].ToString(),
                    PassportIssueDate = (DateTime)dt.Rows[i]["PassPortIssueDate"],
                    LicenseNumber = dt.Rows[i]["LicenseNumber"].ToString(),
                    LicenseEndDate = (DateTime)dt.Rows[i]["LicenseEndDate"],

    



                });

            }

            return employeeCollection;
        }
    }
}
