using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eblacorp_internal.DAL
{
    public class EmployeeDAL
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

     /// <summary>
     /// Adds Employee Form data into DB. returns true if succeeds and false it fails.
     /// </summary>
     /// <param name="FirstName"></param>
     /// <param name="SecondName"></param>
     /// <param name="ThirdName"></param>
     /// <param name="FourthName"></param>
     /// <param name="FamilyName"></param>
     /// <param name="LatinName"></param>
     /// <param name="CivilNum"></param>
     /// <param name="BirthPlace"></param>
     /// <param name="DOB"></param>
     /// <param name="Gender"></param>
     /// <param name="Religion"></param>
     /// <param name="Nationality"></param>
     /// <param name="Career"></param>
     /// <param name="PassportNum"></param>
     /// <param name="PassportEndDate"></param>
     /// <param name="PassportType"></param>
     /// <param name="Education"></param>
     /// <param name="MaritalStatus"></param>
     /// <param name="salary"></param>
     /// <param name="declration"></param>
     /// <param name="ResidencyNum"></param>
     /// <param name="ResidencyEndDate"></param>
     /// <param name="StartDate"></param>
     /// <param name="Duration"></param>
     /// <param name="DurationEng"></param>
     /// <param name="NationalityEng"></param>
     /// <param name="CareerEng"></param>
     /// <param name="Note"></param>
     /// <param name="PassportIssueDate"></param>
     /// <param name="LicenseNumber"></param>
     /// <param name="LicenseEndDate"></param>
     /// <returns></returns>
        public bool addEmployee(string FirstName, string SecondName, string ThirdName, string FourthName, String FamilyName, string LatinName,
                                long CivilNum, string BirthPlace, DateTime DOB, string Gender, string Religion , string Nationality, string Career,
                                long PassportNum , DateTime PassportEndDate, string PassportType, string Education, string MaritalStatus, short salary, 
                                long declration, long ResidencyNum, DateTime ResidencyEndDate, DateTime StartDate, long Duration, long DurationEng, 
                                string NationalityEng, string CareerEng, string Note, DateTime PassportIssueDate, string LicenseNumber, DateTime LicenseEndDate) 
        {

            //Connects to our database
            SqlConnection con = new SqlConnection(myconnection);

            bool isSuccess = false;

            try
            {
                //Saves the command to SqlCommand cmd
                SqlCommand cmd = new SqlCommand("dbo.spAddEmployee", con);

                //Create the Parameter to pass get the value from UI and pass it on SQL above
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar)).Value = FirstName;
                cmd.Parameters.Add(new SqlParameter("@SecondName", SqlDbType.VarChar)).Value = SecondName;
                cmd.Parameters.Add(new SqlParameter("@ThirdName", SqlDbType.VarChar)).Value = ThirdName;
                cmd.Parameters.Add(new SqlParameter("@FourthName", SqlDbType.VarChar)).Value = FourthName;
                cmd.Parameters.Add(new SqlParameter("@FamilyName", SqlDbType.VarChar)).Value = FamilyName;
                cmd.Parameters.Add(new SqlParameter("@LatinName", SqlDbType.VarChar)).Value = LatinName;
                cmd.Parameters.Add(new SqlParameter("@CivilNum", SqlDbType.BigInt)).Value = CivilNum;
                cmd.Parameters.Add(new SqlParameter("@BirthPlace", SqlDbType.VarChar)).Value = BirthPlace;
                cmd.Parameters.Add(new SqlParameter("@DOB", SqlDbType.Date)).Value = DOB;
                cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.VarChar)).Value = Gender;
                cmd.Parameters.Add(new SqlParameter("@Religion", SqlDbType.VarChar)).Value = Religion;
                cmd.Parameters.Add(new SqlParameter("@Nationality", SqlDbType.VarChar)).Value = Nationality;
                cmd.Parameters.Add(new SqlParameter("@Career", SqlDbType.VarChar)).Value = Career;
                cmd.Parameters.Add(new SqlParameter("@PassportNum", SqlDbType.BigInt)).Value = PassportNum;
                cmd.Parameters.Add(new SqlParameter("@PassportEndDate", SqlDbType.Date)).Value = PassportEndDate;
                cmd.Parameters.Add(new SqlParameter("@PassportType", SqlDbType.VarChar)).Value = PassportType;
                cmd.Parameters.Add(new SqlParameter("@Education", SqlDbType.VarChar)).Value = Education;
                cmd.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.VarChar)).Value = MaritalStatus;
                cmd.Parameters.Add(new SqlParameter("@salary", SqlDbType.SmallInt)).Value = salary;
                cmd.Parameters.Add(new SqlParameter("@declration", SqlDbType.BigInt)).Value = declration;
                cmd.Parameters.Add(new SqlParameter("@ResidencyNum", SqlDbType.BigInt)).Value = ResidencyNum;
                cmd.Parameters.Add(new SqlParameter("@ResidencyEndDate", SqlDbType.Date)).Value = ResidencyEndDate;
                cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.Date)).Value = StartDate;
                cmd.Parameters.Add(new SqlParameter("@Duration", SqlDbType.BigInt)).Value = Duration;
                cmd.Parameters.Add(new SqlParameter("@DurationEng", SqlDbType.BigInt)).Value = DurationEng;
                cmd.Parameters.Add(new SqlParameter("@NationalityEng", SqlDbType.VarChar)).Value = NationalityEng;
                cmd.Parameters.Add(new SqlParameter("@CareerEng", SqlDbType.VarChar)).Value = CareerEng;
                cmd.Parameters.Add(new SqlParameter("@Note", SqlDbType.VarChar)).Value = Note;
                cmd.Parameters.Add(new SqlParameter("@PassportIssueDate", SqlDbType.Date)).Value = PassportIssueDate;
                cmd.Parameters.Add(new SqlParameter("@LicenseNumber", SqlDbType.VarChar)).Value = LicenseNumber;
                cmd.Parameters.Add(new SqlParameter("@LicenseEndDate", SqlDbType.DateTime)).Value = LicenseEndDate;


                //Opens Connection
                con.Open();
                //Stores the table for this session
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //Create an integer variable to hold the value after the query is executed
                int rows = cmd.ExecuteNonQuery();

                //The value of rows will be bigger than 0 if the query was succesfully
                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }



        /// <summary>
        /// Deletes selected employee from DB
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public bool deleteEmplotee(int UserID)
        {
            SqlConnection con = new SqlConnection(myconnection);

            bool isSuccess = false;

            try
            {
                //Saves the command to SqlCommand cmd
                SqlCommand cmd = new SqlCommand("dbo.spDeleteEmployeeRow", con);

                //Create the Parameter to pass get the value from UI and pass it on SQL above
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.BigInt)).Value = UserID;


                //Opens Connection
                con.Open();
                //Stores the table for this session
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //Create an integer variable to hold the value after the query is executed
                int rows = cmd.ExecuteNonQuery();

                //The value of rows will be bigger than 0 if the query was succesfully
                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }

        public bool updateEmployee(int ID, string FirstName, string SecondName, string ThirdName, string FourthName, String FamilyName, string LatinName,
                                long CivilNum, string BirthPlace, DateTime DOB, string Gender, string Religion, string Nationality, string Career,
                                long PassportNum, DateTime PassportEndDate, string PassportType, string Education, string MaritalStatus, short salary,
                                long declration, long ResidencyNum, DateTime ResidencyEndDate, DateTime StartDate, long Duration, long DurationEng,
                                string NationalityEng, string CareerEng, string Note, DateTime PassportIssueDate, string LicenseNumber, DateTime LicenseEndDate)
        {
            SqlConnection con = new SqlConnection(myconnection);

            bool isSuccess = false;

            try
            {
                //Saves the command to SqlCommand cmd
                SqlCommand cmd = new SqlCommand("dbo.spUpdateEmployee", con);

                //Create the Parameter to pass get the value from UI and pass it on SQL above
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt)).Value = ID;
                cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar)).Value = FirstName;
                cmd.Parameters.Add(new SqlParameter("@SecondName", SqlDbType.VarChar)).Value = SecondName;
                cmd.Parameters.Add(new SqlParameter("@ThirdName", SqlDbType.VarChar)).Value = ThirdName;
                cmd.Parameters.Add(new SqlParameter("@FourthName", SqlDbType.VarChar)).Value = FourthName;
                cmd.Parameters.Add(new SqlParameter("@FamilyName", SqlDbType.VarChar)).Value = FamilyName;
                cmd.Parameters.Add(new SqlParameter("@LatinName", SqlDbType.VarChar)).Value = LatinName;
                cmd.Parameters.Add(new SqlParameter("@CivilNum", SqlDbType.BigInt)).Value = CivilNum;
                cmd.Parameters.Add(new SqlParameter("@BirthPlace", SqlDbType.VarChar)).Value = BirthPlace;
                cmd.Parameters.Add(new SqlParameter("@DOB", SqlDbType.Date)).Value = DOB;
                cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.VarChar)).Value = Gender;
                cmd.Parameters.Add(new SqlParameter("@Religion", SqlDbType.VarChar)).Value = Religion;
                cmd.Parameters.Add(new SqlParameter("@Nationality", SqlDbType.VarChar)).Value = Nationality;
                cmd.Parameters.Add(new SqlParameter("@Career", SqlDbType.VarChar)).Value = Career;
                cmd.Parameters.Add(new SqlParameter("@PassportNum", SqlDbType.BigInt)).Value = PassportNum;
                cmd.Parameters.Add(new SqlParameter("@PassportEndDate", SqlDbType.Date)).Value = PassportEndDate;
                cmd.Parameters.Add(new SqlParameter("@PassportType", SqlDbType.VarChar)).Value = PassportType;
                cmd.Parameters.Add(new SqlParameter("@Education", SqlDbType.VarChar)).Value = Education;
                cmd.Parameters.Add(new SqlParameter("@MaritalStatus", SqlDbType.VarChar)).Value = MaritalStatus;
                cmd.Parameters.Add(new SqlParameter("@salary", SqlDbType.SmallInt)).Value = salary;
                cmd.Parameters.Add(new SqlParameter("@declration", SqlDbType.BigInt)).Value = declration;
                cmd.Parameters.Add(new SqlParameter("@ResidencyNum", SqlDbType.BigInt)).Value = ResidencyNum;
                cmd.Parameters.Add(new SqlParameter("@ResidencyEndDate", SqlDbType.Date)).Value = ResidencyEndDate;
                cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.Date)).Value = StartDate;
                cmd.Parameters.Add(new SqlParameter("@Duration", SqlDbType.BigInt)).Value = Duration;
                cmd.Parameters.Add(new SqlParameter("@DurationEng", SqlDbType.BigInt)).Value = DurationEng;
                cmd.Parameters.Add(new SqlParameter("@NationalityEng", SqlDbType.VarChar)).Value = NationalityEng;
                cmd.Parameters.Add(new SqlParameter("@CareerEng", SqlDbType.VarChar)).Value = CareerEng;
                cmd.Parameters.Add(new SqlParameter("@Note", SqlDbType.VarChar)).Value = Note;
                cmd.Parameters.Add(new SqlParameter("@PassportIssueDate", SqlDbType.Date)).Value = PassportIssueDate;
                cmd.Parameters.Add(new SqlParameter("@LicenseNumber", SqlDbType.VarChar)).Value = LicenseNumber;
                cmd.Parameters.Add(new SqlParameter("@LicenseEndDate", SqlDbType.DateTime)).Value = LicenseEndDate;

                //Opens Connection
                con.Open();
                //Stores the table for this session
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //Create an integer variable to hold the value after the query is executed
                int rows = cmd.ExecuteNonQuery();

                //The value of rows will be bigger than 0 if the query was succesfully
                if (rows > 0)
                {
                    isSuccess = true;

                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }
            return isSuccess;
        }
    }

  
}
