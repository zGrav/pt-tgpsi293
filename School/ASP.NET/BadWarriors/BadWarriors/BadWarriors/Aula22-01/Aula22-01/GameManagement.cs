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
        private SqlCommand minushpCmd = new SqlCommand("minus15hp");
        private SqlCommand addWinCmd = new SqlCommand("addWin");
        private SqlCommand addLossCmd = new SqlCommand("addLoss");
        private SqlCommand logChallengeCmd = new SqlCommand("challenge");
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

        public void minushp(string getCon)
        {
            con.ConnectionString = getCon;
            minushpCmd.Connection = con;
            minushpCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            minushpCmd.ExecuteNonQuery();
            con.Close();
        }

        public void minushpParams(string getName, string getData)
        {
            minushpCmd.Parameters.AddWithValue(getName, getData);
        }

        public void addWin(string getCon)
        {
            con.ConnectionString = getCon;
            addWinCmd.Connection = con;
            addWinCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            addWinCmd.ExecuteNonQuery();
            con.Close();
        }

        public void addWinParams(string getName, string getData) 
        {
            addWinCmd.Parameters.AddWithValue(getName, getData);
        }

        public void addLoss(string getCon)
        {
            con.ConnectionString = getCon;
            addLossCmd.Connection = con;
            addLossCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            addLossCmd.ExecuteNonQuery();
            con.Close();
        }

        public void addLossParams(string getName, string getData)
        {
            addLossCmd.Parameters.AddWithValue(getName, getData);
        }

        public void logChallenge(string getCon)
        {
            con.ConnectionString = getCon;
            logChallengeCmd.Connection = con;
            logChallengeCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            logChallengeCmd.ExecuteNonQuery();
            con.Close();
        }

        public void logChallengeParams(string getName, int getData)
        {
            logChallengeCmd.Parameters.AddWithValue(getName, getData);
        }

        public void logChallengeParamsTime(string getName, string getData)
        {
            logChallengeCmd.Parameters.AddWithValue(getName, getData);
        }
    }
}