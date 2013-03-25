using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Aula22_01
{
    public class FriendManagement
    {
        private SqlCommand sendRequestCmd = new SqlCommand("SendRequest");
        private SqlCommand receiveRequestCmd = new SqlCommand("ReceiveRequest");
        private SqlCommand grabUserIDCmd = new SqlCommand("GrabID");
        private SqlConnection con = new SqlConnection();

        public int grabID(string getCon)
        {
            con.ConnectionString = getCon;
            grabUserIDCmd.Connection = con;
            grabUserIDCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            string returnval = grabUserIDCmd.ExecuteScalar().ToString();
            con.Close();

            return Convert.ToInt32(returnval);
        }

        public void grabIDParams(string getName, string getData)
        {
            grabUserIDCmd.Parameters.AddWithValue(getName, getData);
        }

        public void sendRequest(string getCon)
        {
            con.ConnectionString = getCon;
            sendRequestCmd.Connection = con;
            sendRequestCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            sendRequestCmd.ExecuteNonQuery();
            con.Close();
        }

        public void sendRequestParams(string getName, int getData)
        {
            sendRequestCmd.Parameters.AddWithValue(getName, getData);
        }

        public int receiveRequest(string getCon)
        {
            con.ConnectionString = getCon;
            receiveRequestCmd.Connection = con;
            receiveRequestCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            string returnval = receiveRequestCmd.ExecuteScalar().ToString();
            con.Close();

            return Convert.ToInt32(returnval);
        }

        public void receiveRequestParams(string getName, int getData)
        {
            receiveRequestCmd.Parameters.AddWithValue(getName, getData);
        }
    }

}