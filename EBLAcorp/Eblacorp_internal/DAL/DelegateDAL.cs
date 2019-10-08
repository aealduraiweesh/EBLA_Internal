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
    public class DelegateDAL
    {
        //SQL Connection
        static string myconnection = ConfigurationManager.ConnectionStrings["Ebla"].ConnectionString;

        //DataTable to store the database tables we are using
        public DataTable dt { get; set; } = new DataTable();

        //collection of the UserTable information
        public ObservableCollection<Models.DeletgateModel> delegateCollection { get; set; } = new ObservableCollection<Models.DeletgateModel>();

        public ObservableCollection<Models.DeletgateModel> searchByDelegateName(string DelegateName)
        {
            delegateCollection.Clear();
            dt.Clear();

            SqlConnection con = new SqlConnection(myconnection);
            SqlCommand cmd = new SqlCommand("dbo.spGetDelegateByDelegateName", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("@delegate1", SqlDbType.VarChar)).Value = DelegateName;
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                delegateCollection.Add(new Models.DeletgateModel
                {


                    ID = (int)dt.Rows[i]["ID"],
                    delegate1 = dt.Rows[i]["delegate1"].ToString(),
                    Civil = dt.Rows[i]["Civil"].ToString(),
                    companyName = dt.Rows[i]["companyName"].ToString(),
                    Nationality = dt.Rows[i]["Nationality"].ToString(),




                });

            }
            return delegateCollection;
        }
        public ObservableCollection<Models.DeletgateModel> searchByCompanyName(string CompanyName)
        {
            delegateCollection.Clear();
            dt.Clear();

            SqlConnection con = new SqlConnection(myconnection);
            SqlCommand cmd = new SqlCommand("dbo.spGetDelegateByCompanyName", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("@companyName", SqlDbType.VarChar)).Value = CompanyName;
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                delegateCollection.Add(new Models.DeletgateModel
                {


                    ID = (int)dt.Rows[i]["ID"],
                    delegate1 = dt.Rows[i]["delegate1"].ToString(),
                    Civil = dt.Rows[i]["Civil"].ToString(),
                    companyName = dt.Rows[i]["companyName"].ToString(),
                    Nationality = dt.Rows[i]["Nationality"].ToString(),




                });

            }
            return delegateCollection;
        }



        public ObservableCollection<Models.DeletgateModel> selectAllDelegates()
        {

            //cleans employee collection
            delegateCollection.Clear();
            dt.Clear();
            //Connects to our database
            SqlConnection con = new SqlConnection(myconnection);
            //Saves the command to SqlCommand cmd
            SqlCommand cmd = new SqlCommand("Select*From Delegates;", con);
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
                delegateCollection.Add(new Models.DeletgateModel
                {


                    ID = (int)dt.Rows[i]["ID"],
                    delegate1 = dt.Rows[i]["delegate1"].ToString(),
                    Civil = dt.Rows[i]["Civil"].ToString(),
                    companyName = dt.Rows[i]["companyName"].ToString(),
                    Nationality = dt.Rows[i]["Nationality"].ToString(),




                });

            }

            return delegateCollection;
        }

        public bool addDelegate (string DelegateName, string CompanyName, string Nationality, string Civil)
        {

            //Connects to our database
            SqlConnection con = new SqlConnection(myconnection);

            bool isSuccess = false;

            try
            {
                //Saves the command to SqlCommand cmd
                SqlCommand cmd = new SqlCommand("dbo.spAddDelegate", con);

                //Create the Parameter to pass get the value from UI and pass it on SQL above
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@DelegateName", SqlDbType.NVarChar)).Value = DelegateName;
                cmd.Parameters.Add(new SqlParameter("@Civil", SqlDbType.NVarChar)).Value = Civil;
                cmd.Parameters.Add(new SqlParameter("@Nationality", SqlDbType.NVarChar)).Value = Nationality;
                cmd.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar)).Value = CompanyName;
         



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

        public bool updateDelegate(int ID, string DelegateName, string CompanyName, string Nationality, string Civil)
        {
            SqlConnection con = new SqlConnection(myconnection);

            bool isSuccess = false;

            try
            {
                //Saves the command to SqlCommand cmd
                SqlCommand cmd = new SqlCommand("dbo.spUpdateDelegate", con);

                //Create the Parameter to pass get the value from UI and pass it on SQL above
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = ID;
                cmd.Parameters.Add(new SqlParameter("@DelegateName", SqlDbType.NVarChar)).Value = DelegateName;
                cmd.Parameters.Add(new SqlParameter("@Civil", SqlDbType.NVarChar)).Value = Civil;
                cmd.Parameters.Add(new SqlParameter("@Nationality", SqlDbType.NVarChar)).Value = Nationality;
                cmd.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar)).Value = CompanyName;



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

        public bool deleteDelegate(int ID)
        {
            SqlConnection con = new SqlConnection(myconnection);

            bool isSuccess = false;

            try
            {
                //Saves the command to SqlCommand cmd
                SqlCommand cmd = new SqlCommand("dbo.spDeleteDelegateRow", con);

                //Create the Parameter to pass get the value from UI and pass it on SQL above
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.BigInt)).Value = ID;


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
