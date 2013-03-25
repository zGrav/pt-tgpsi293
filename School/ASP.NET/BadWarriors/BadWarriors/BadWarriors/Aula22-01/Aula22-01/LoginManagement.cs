using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Aula22_01
{
    public class LoginManagement
    {

        private SqlCommand doLoginCmd = new SqlCommand("Login");
        private SqlCommand doRegisterCmd = new SqlCommand("Register");
        private SqlCommand add50HPCmd = new SqlCommand("add50HP");
        private SqlConnection con = new SqlConnection();

        public bool doLogin(string getCon)
        {
            try
            {
                con.ConnectionString = getCon;
                doLoginCmd.Connection = con;
                doLoginCmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                doLoginCmd.ExecuteNonQuery();
                con.Close();

                return true;
            }

            catch (Exception)
            {
                return false;
            }

            }

        public void getLoginParams(string getName, string getData)
        {
            doLoginCmd.Parameters.AddWithValue(getName, getData);
        }

        public bool doRegister(string getCon)
        {
            try
            {
                con.ConnectionString = getCon;
                doRegisterCmd.Connection = con;
                doRegisterCmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                doRegisterCmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void getRegisterParams(string getName, string getData)
        {
            doRegisterCmd.Parameters.AddWithValue(getName, getData);
        }

        public void add50HP(string getCon)
        {
            con.ConnectionString = getCon;
            add50HPCmd.Connection = con;
            add50HPCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            add50HPCmd.ExecuteNonQuery();
            con.Close();
        }

        public void add50HPParams(string getName, string getData)
        {
            add50HPCmd.Parameters.AddWithValue(getName, getData);
        }
    }
}