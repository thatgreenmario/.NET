using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBLayer
    {
        
        public static List<User> getAll()
        {
            List<User> Userlist = new List<User>();

            string cmdText = "SELECT * FROM UserTable";//query String
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\LabExam\LabExam\App_Data\UserList.mdf;Integrated Security=True";//connection String
            System.Data.IDbConnection con = new SqlConnection();
            con.ConnectionString = conString;
            IDbCommand cmd = new SqlCommand(cmdText, con as SqlConnection);

            try
            {
                con.Open();
                IDataReader reader = cmd.ExecuteReader(); // Fire  Command
                while (reader.Read())
                {
                    User emp = new User();
                    emp.UserId = int.Parse(reader["Id"].ToString());
                    emp.UserEmail = reader["useremail"].ToString();
                    emp.UserPassword = reader["userpassword"].ToString();
                   Userlist.Add(emp);
                }

                reader.Close();

            }
            catch (SqlException exp)
            {
                throw exp;  //throw generated exception to next layer to handle
            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

            return Userlist;
        }

        public static List<Pizza> getPizza()
        {
            List<Pizza> pizzalist = new List<Pizza>();
            string cmdText = "SELECT * FROM PizzaTable";//query String
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\LabExam\LabExam\App_Data\UserList.mdf;Integrated Security=True";//connection String
            System.Data.IDbConnection con = new SqlConnection();
            con.ConnectionString = conString;
            IDbCommand cmd = new SqlCommand(cmdText, con as SqlConnection);

            try
            {
                con.Open();
                IDataReader reader = cmd.ExecuteReader(); // Fire  Command
                while (reader.Read())
                {
                    Pizza emp = new Pizza();
                    emp.PizzaId = int.Parse(reader["Id"].ToString());
                    emp.Pname = reader["Pname"].ToString();
                    emp.Pdis = reader["Pdescription"].ToString();
                    emp.Pprice = reader.GetInt32(3);
                    pizzalist.Add(emp);
                }

                reader.Close();

            }
            catch (SqlException exp)
            {
                throw exp;  //throw generated exception to next layer to handle
            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

            return pizzalist;

        }

        public static Pizza getPizzabyid(int id)
        {
            Pizza emp = new Pizza();
            string cmdText = "SELECT * FROM PizzaTable WHERE Id="+ id;//query String
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\LabExam\LabExam\App_Data\UserList.mdf;Integrated Security=True";//connection String
            System.Data.IDbConnection con = new SqlConnection();
            con.ConnectionString = conString;
            IDbCommand cmd = new SqlCommand(cmdText, con as SqlConnection);

            try
            {
                con.Open();
                IDataReader reader = cmd.ExecuteReader(); // Fire  Command
                while (reader.Read())
                {
                    
                    emp.PizzaId = int.Parse(reader["Id"].ToString());
                    emp.Pname = reader["Pname"].ToString();
                    emp.Pdis = reader["Pdescription"].ToString();
                    emp.Pprice = reader.GetInt32(3);
                }

                reader.Close();

            }
            catch (SqlException exp)
            {
                throw exp;  //throw generated exception to next layer to handle
            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

            return emp;

        }
        public static void insertPizza(Pizza a)
        {

            string cmdText = "INSERT INTO CartTable VALUES('"+a.PizzaId+"','"+a.Pname+"','"+ a.Pdis+"','"+a.Pprice+"')";
            //string cmdText = "INSERT INTO CartTable (PizzaId, Pname, Pdis,Pprice)VALUES(1, 'Vishal','kasat', 20); ";
            string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\LabExam\LabExam\App_Data\UserList.mdf;Integrated Security=True";//connection String
            System.Data.IDbConnection con = new SqlConnection();
            con.ConnectionString = conString;
            IDbCommand cmd = new SqlCommand(cmdText, con as SqlConnection);

            try
            {
                con.Open();
                cmd.ExecuteReader(); // Fire  Command

            }
            catch (SqlException exp)
            {
                throw exp;  //throw generated exception to next layer to handle
            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }

            

        }



    }
    }

