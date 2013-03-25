using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Aula22_01
{
    public class GameManagement
    {
        private SqlCommand grabStatsCmd = new SqlCommand();
        private SqlCommand updateStatsCmd = new SqlCommand("UpdateStats");
        private SqlConnection con = new SqlConnection();

        public string grabStats(string getCon, string getCmd)
        {
            grabStatsCmd.CommandText = getCmd;
            con.ConnectionString = getCon;
            grabStatsCmd.Connection = con;
            grabStatsCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            string toreturn = grabStatsCmd.ExecuteScalar().ToString();
            con.Close();

            return toreturn;
        }

        public void grabStatsParams(string getName, string getData)
        {
            grabStatsCmd.Parameters.AddWithValue(getName, getData);
        }

        public void updateStats(string getCon)
        {
            con.ConnectionString = getCon;
            updateStatsCmd.Connection = con;
            updateStatsCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            updateStatsCmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateStatsParams(string getName, string getData)
        {
            updateStatsCmd.Parameters.AddWithValue(getName, getData);
        }
    }
}