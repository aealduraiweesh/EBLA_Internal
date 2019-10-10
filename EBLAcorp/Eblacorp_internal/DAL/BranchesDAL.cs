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
    class BranchesDAL
    {
        //SQL Connection
        static string myconnection = ConfigurationManager.ConnectionStrings["Ebla"].ConnectionString;

        //DataTable to store the database tables we are using
        public DataTable dt { get; set; } = new DataTable();

        //collection of the UserTable information
        public ObservableCollection<Models.BranchesModel> branchesCollection { get; set; } = new ObservableCollection<Models.BranchesModel>();

        public ObservableCollection<Models.BranchesModel> searchByBranchName(string BranchName)
        {
            branchesCollection.Clear();
            dt.Clear();

            SqlConnection con = new SqlConnection(myconnection);
            SqlCommand cmd = new SqlCommand("dbo.spGetBranchByBranchName", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("@BranchName", SqlDbType.VarChar)).Value = BranchName;
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                branchesCollection.Add(new Models.BranchesModel
                {


                    Branches_id = (int)dt.Rows[i]["Branches_id"],
                    LisenceNum = dt.Rows[i]["LisenceNum"].ToString(),
                    FileNum = dt.Rows[i]["FileNum"].ToString(),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    BranchName = dt.Rows[i]["BranchName"].ToString(),
                    ContractNumber = dt.Rows[i]["ContractNumber"].ToString(),
                    ReferenceNumber = dt.Rows[i]["ReferenceNumber"].ToString(),
                    AutomatedNumber = dt.Rows[i]["AutomatedNumber"].ToString(),
                    Area = dt.Rows[i]["Area"].ToString(),
                    block = dt.Rows[i]["block"].ToString(),
                    street = dt.Rows[i]["street"].ToString(),
                    phone = dt.Rows[i]["phone"].ToString(),
                    Governate = dt.Rows[i]["Governate"].ToString(),
                    BusinessField = dt.Rows[i]["BusinessField"].ToString(),
                    CivilNumber = dt.Rows[i]["CivilNumber"].ToString(),


                });

            }
            return branchesCollection;
        }


        public ObservableCollection<Models.BranchesModel> searchByCompanyName(string CompanyName)
        {
            branchesCollection.Clear();
            dt.Clear();

            SqlConnection con = new SqlConnection(myconnection);
            SqlCommand cmd = new SqlCommand("dbo.spGetBranchByCompanyName", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.VarChar)).Value = CompanyName;
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            con.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                branchesCollection.Add(new Models.BranchesModel
                {



                    Branches_id = (int)dt.Rows[i]["Branches_id"],
                    LisenceNum = dt.Rows[i]["LisenceNum"].ToString(),
                    FileNum = dt.Rows[i]["FileNum"].ToString(),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    BranchName = dt.Rows[i]["BranchName"].ToString(),
                    ContractNumber = dt.Rows[i]["ContractNumber"].ToString(),
                    ReferenceNumber = dt.Rows[i]["ReferenceNumber"].ToString(),
                    AutomatedNumber = dt.Rows[i]["AutomatedNumber"].ToString(),
                    Area = dt.Rows[i]["Area"].ToString(),
                    block = dt.Rows[i]["block"].ToString(),
                    street = dt.Rows[i]["street"].ToString(),
                    phone = dt.Rows[i]["phone"].ToString(),
                    Governate = dt.Rows[i]["Governate"].ToString(),
                    BusinessField = dt.Rows[i]["BusinessField"].ToString(),
                    CivilNumber = dt.Rows[i]["CivilNumber"].ToString(),






                });

            }
            return branchesCollection;
        }



        public ObservableCollection<Models.BranchesModel> selectAllBranches()
        {

            //cleans employee collection
            branchesCollection.Clear();
            dt.Clear();
            //Connects to our database
            SqlConnection con = new SqlConnection(myconnection);
            //Saves the command to SqlCommand cmd
            SqlCommand cmd = new SqlCommand("Select*From Branches;", con);
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
                branchesCollection.Add(new Models.BranchesModel
                {


                    Branches_id = (int)dt.Rows[i]["Branches_id"],
                    LisenceNum = dt.Rows[i]["LisenceNum"].ToString(),
                    FileNum = dt.Rows[i]["FileNum"].ToString(),
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    BranchName = dt.Rows[i]["BranchName"].ToString(),
                    ContractNumber = dt.Rows[i]["ContractNumber"].ToString(),
                    ReferenceNumber = dt.Rows[i]["ReferenceNumber"].ToString(),
                    AutomatedNumber = dt.Rows[i]["AutomatedNumber"].ToString(),
                    Area = dt.Rows[i]["Area"].ToString(),
                    block = dt.Rows[i]["block"].ToString(),
                    street = dt.Rows[i]["street"].ToString(),
                    phone = dt.Rows[i]["phone"].ToString(),
                    Governate = dt.Rows[i]["Governate"].ToString(),
                    BusinessField = dt.Rows[i]["BusinessField"].ToString(),
                    CivilNumber = dt.Rows[i]["CivilNumber"].ToString(),




                });

            }

            return branchesCollection;
        }

        public bool addBranches(string LisenceNum, string FileNum, string CompanyName, string BranchName, string ContractNumber,
                                string ReferenceNumber, string AutomatedNumber, string Area, string block, string street,
                                string phone, string Governate, string BusinessField, string CivilNumber)
        {

            //Connects to our database
            SqlConnection con = new SqlConnection(myconnection);

            bool isSuccess = false;

            try
            {
                //Saves the command to SqlCommand cmd
                SqlCommand cmd = new SqlCommand("dbo.spAddBranch", con);

                //Create the Parameter to pass get the value from UI and pass it on SQL above
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@LisenceNum", SqlDbType.NVarChar)).Value = LisenceNum;
                cmd.Parameters.Add(new SqlParameter("@FileNum", SqlDbType.NVarChar)).Value = FileNum;
                cmd.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar)).Value = CompanyName;
                cmd.Parameters.Add(new SqlParameter("@BranchName", SqlDbType.NVarChar)).Value = BranchName;
                cmd.Parameters.Add(new SqlParameter("@ContractNumber", SqlDbType.NVarChar)).Value = ContractNumber;
                cmd.Parameters.Add(new SqlParameter("@ReferenceNumber", SqlDbType.NVarChar)).Value = ReferenceNumber;
                cmd.Parameters.Add(new SqlParameter("@AutomatedNumber", SqlDbType.NVarChar)).Value = AutomatedNumber;
                cmd.Parameters.Add(new SqlParameter("@Area", SqlDbType.NVarChar)).Value = Area;
                cmd.Parameters.Add(new SqlParameter("@block", SqlDbType.NVarChar)).Value = block;
                cmd.Parameters.Add(new SqlParameter("@street", SqlDbType.NVarChar)).Value = street;
                cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.NVarChar)).Value = phone;
                cmd.Parameters.Add(new SqlParameter("@Governate", SqlDbType.NVarChar)).Value = Governate;
                cmd.Parameters.Add(new SqlParameter("@BusinessField", SqlDbType.NVarChar)).Value = BusinessField;
                cmd.Parameters.Add(new SqlParameter("@CivilNumber", SqlDbType.NVarChar)).Value = CivilNumber;




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

        public bool updateBranch(int Branches_id, string LisenceNum, string FileNum, string CompanyName, string BranchName, string ContractNumber,
                                string ReferenceNumber, string AutomatedNumber, string Area, string block, string street,
                                string phone, string Governate, string BusinessField, string CivilNumber)
        {
            SqlConnection con = new SqlConnection(myconnection);

            bool isSuccess = false;

            try
            {
                //Saves the command to SqlCommand cmd
                SqlCommand cmd = new SqlCommand("dbo.spUpdateBranch", con);

                //Create the Parameter to pass get the value from UI and pass it on SQL above
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Branches_id", SqlDbType.Int)).Value = Branches_id;
                cmd.Parameters.Add(new SqlParameter("@LisenceNum", SqlDbType.NVarChar)).Value = LisenceNum;
                cmd.Parameters.Add(new SqlParameter("@FileNum", SqlDbType.NVarChar)).Value = FileNum;
                cmd.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.NVarChar)).Value = CompanyName;
                cmd.Parameters.Add(new SqlParameter("@BranchName", SqlDbType.NVarChar)).Value = BranchName;
                cmd.Parameters.Add(new SqlParameter("@ContractNumber", SqlDbType.NVarChar)).Value = ContractNumber;
                cmd.Parameters.Add(new SqlParameter("@ReferenceNumber", SqlDbType.NVarChar)).Value = ReferenceNumber;
                cmd.Parameters.Add(new SqlParameter("@AutomatedNumber", SqlDbType.NVarChar)).Value = AutomatedNumber;
                cmd.Parameters.Add(new SqlParameter("@Area", SqlDbType.NVarChar)).Value = Area;
                cmd.Parameters.Add(new SqlParameter("@block", SqlDbType.NVarChar)).Value = block;
                cmd.Parameters.Add(new SqlParameter("@street", SqlDbType.NVarChar)).Value = street;
                cmd.Parameters.Add(new SqlParameter("@phone", SqlDbType.NVarChar)).Value = phone;
                cmd.Parameters.Add(new SqlParameter("@Governate", SqlDbType.NVarChar)).Value = Governate;
                cmd.Parameters.Add(new SqlParameter("@BusinessField", SqlDbType.NVarChar)).Value = BusinessField;
                cmd.Parameters.Add(new SqlParameter("@CivilNumber", SqlDbType.NVarChar)).Value = CivilNumber;


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

        public bool deleteBranch(int Branches_id)
        {
            SqlConnection con = new SqlConnection(myconnection);

            bool isSuccess = false;

            try
            {
                //Saves the command to SqlCommand cmd
                SqlCommand cmd = new SqlCommand("dbo.spDeleteBranchRow", con);

                //Create the Parameter to pass get the value from UI and pass it on SQL above
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new SqlParameter("@Branches_id", SqlDbType.BigInt)).Value = Branches_id;


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
