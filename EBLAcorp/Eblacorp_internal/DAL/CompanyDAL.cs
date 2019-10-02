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
    class CompanyDAL
    {
        //SQL Connection
        static string myconnection = ConfigurationManager.ConnectionStrings["Ebla"].ConnectionString;

        //DataTable to store the database tables we are using
        public DataTable dt { get; set; } = new DataTable();

        //collection of the UserTable information
        public ObservableCollection<Models.CompanyModel> companyCollection { get; set; } = new ObservableCollection<Models.CompanyModel>();


        public ObservableCollection<Models.CompanyModel> selectAllEmployees()
        {

            //cleans employee collection
            companyCollection.Clear();
            dt.Clear();
            //Connects to our database
            SqlConnection con = new SqlConnection(myconnection);
            //Saves the command to SqlCommand cmd
            SqlCommand cmd = new SqlCommand("Select*From company;", con);
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
                companyCollection.Add(new Models.CompanyModel
                {


                    Comp_ID = (int)dt.Rows[i]["Comp_ID"],
                    ManagerName = dt.Rows[i]["ManagerName"].ToString(),
                    CivilNumber = dt.Rows[i]["CivilNumber"].ToString(),
                    DelegateName = dt.Rows[i]["DelegateName"].ToString(),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    ContractNumber = dt.Rows[i]["ContractNumber"].ToString(),
                    ReferenceNumber = dt.Rows[i]["ReferenceNumber"].ToString(),
                    AutomatedNumber = dt.Rows[i]["AutomatedNumber"].ToString(),
                    Area = dt.Rows[i]["Area"].ToString(),
                    block = dt.Rows[i]["block"].ToString(),
                    street = dt.Rows[i]["street"].ToString(),
                    phone = dt.Rows[i]["phone"].ToString(),
                    Governate = dt.Rows[i]["Governate"].ToString(),
                    BusinessField = dt.Rows[i]["BusinessField"].ToString(),
                    ManagerNameeng = dt.Rows[i]["ManagerNameeng"].ToString(),
                    CompanyNameeng = dt.Rows[i]["CompanyNameeng"].ToString(),
                    BusinessFieldEng = dt.Rows[i]["BusinessFieldEng"].ToString(),

                });

            }

            return companyCollection;
        }


        public bool addCompany(string ManagerName, string CivilNumber, string DelegateName, string CompanyName,
                               string ContractNumber, string ReferenceNumber, string AutomatedNumber, string Area,
                               string block, string street, string phone, string Governate, string BusinessField, 
                               string ManagerNameeng, string CompanyNameeng, string BusinessFieldEng)
        {

            //Connects to our database
            SqlConnection con = new SqlConnection(myconnection);

            bool isSuccess = false;

            try
            {
                //Saves the command to SqlCommand cmd
                SqlCommand cmd = new SqlCommand("dbo.spAddCompany", con);

                //Create the Parameter to pass get the value from UI and pass it on SQL above
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@ManagerName", SqlDbType.NVarChar)).Value = ManagerName;
                cmd.Parameters.Add(new SqlParameter("@CivilNumber", SqlDbType.NChar)).Value = CivilNumber;
                cmd.Parameters.Add(new SqlParameter("@DelegateName", SqlDbType.NVarChar)).Value = DelegateName;
                cmd.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar)).Value = CompanyName;
                cmd.Parameters.Add(new SqlParameter("@ContractNumber", SqlDbType.NVarChar)).Value = ContractNumber;
                cmd.Parameters.Add(new SqlParameter("@ReferenceNumber", SqlDbType.NChar)).Value = ReferenceNumber;
                cmd.Parameters.Add(new SqlParameter("@AutomatedNumber", SqlDbType.NChar)).Value = AutomatedNumber;
                cmd.Parameters.Add(new SqlParameter("@Area", SqlDbType.NChar)).Value = Area;
                cmd.Parameters.Add(new SqlParameter("@block", SqlDbType.NChar)).Value = block;
                cmd.Parameters.Add(new SqlParameter("@street", SqlDbType.NChar)).Value = street;
                cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.NChar)).Value = phone;
                cmd.Parameters.Add(new SqlParameter("@Governate", SqlDbType.NChar)).Value = Governate;
                cmd.Parameters.Add(new SqlParameter("@BusinessField", SqlDbType.NChar)).Value = BusinessField;
                cmd.Parameters.Add(new SqlParameter("@ManagerNameeng", SqlDbType.VarChar)).Value = ManagerNameeng;
                cmd.Parameters.Add(new SqlParameter("@CompanyNameeng", SqlDbType.NChar)).Value = CompanyNameeng;
                cmd.Parameters.Add(new SqlParameter("@BusinessFieldEng", SqlDbType.NChar)).Value = BusinessFieldEng;
                



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

        public bool updateCompany(int Comp_ID, string ManagerName, string CivilNumber, string DelegateName, string CompanyName,
                               string ContractNumber, string ReferenceNumber, string AutomatedNumber, string Area,
                               string block, string street, string phone, string Governate, string BusinessField,
                               string ManagerNameeng, string CompanyNameeng, string BusinessFieldEng)
        {
            SqlConnection con = new SqlConnection(myconnection);

            bool isSuccess = false;

            try
            {
                //Saves the command to SqlCommand cmd
                SqlCommand cmd = new SqlCommand("dbo.spUpdateCompany", con);

                //Create the Parameter to pass get the value from UI and pass it on SQL above
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@COMP_ID", SqlDbType.BigInt)).Value = Comp_ID;
                cmd.Parameters.Add(new SqlParameter("@ManagerName", SqlDbType.NVarChar)).Value = ManagerName;
                cmd.Parameters.Add(new SqlParameter("@CivilNumber", SqlDbType.NChar)).Value = CivilNumber;
                cmd.Parameters.Add(new SqlParameter("@DelegateName", SqlDbType.NVarChar)).Value = DelegateName;
                cmd.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar)).Value = CompanyName;
                cmd.Parameters.Add(new SqlParameter("@ContractNumber", SqlDbType.NVarChar)).Value = ContractNumber;
                cmd.Parameters.Add(new SqlParameter("@ReferenceNumber", SqlDbType.NChar)).Value = ReferenceNumber;
                cmd.Parameters.Add(new SqlParameter("@AutomatedNumber", SqlDbType.NChar)).Value = AutomatedNumber;
                cmd.Parameters.Add(new SqlParameter("@Area", SqlDbType.NChar)).Value = Area;
                cmd.Parameters.Add(new SqlParameter("@block", SqlDbType.NChar)).Value = block;
                cmd.Parameters.Add(new SqlParameter("@street", SqlDbType.NChar)).Value = street;
                cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.NChar)).Value = phone;
                cmd.Parameters.Add(new SqlParameter("@Governate", SqlDbType.NChar)).Value = Governate;
                cmd.Parameters.Add(new SqlParameter("@BusinessField", SqlDbType.NChar)).Value = BusinessField;
                cmd.Parameters.Add(new SqlParameter("@ManagerNameeng", SqlDbType.VarChar)).Value = ManagerNameeng;
                cmd.Parameters.Add(new SqlParameter("@CompanyNameeng", SqlDbType.NChar)).Value = CompanyNameeng;
                cmd.Parameters.Add(new SqlParameter("@BusinessFieldEng", SqlDbType.NChar)).Value = BusinessFieldEng;



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

        public bool deleteCompany(int Comp_ID)
        {
            SqlConnection con = new SqlConnection(myconnection);

            bool isSuccess = false;

            try
            {
                //Saves the command to SqlCommand cmd
                SqlCommand cmd = new SqlCommand("dbo.spDeleteCompanyRow", con);

                //Create the Parameter to pass get the value from UI and pass it on SQL above
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@Comp_ID", SqlDbType.BigInt)).Value = Comp_ID;


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
