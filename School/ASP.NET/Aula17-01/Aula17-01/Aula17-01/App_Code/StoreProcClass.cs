using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace Aula17_01
{
    public class StoreProcClass
    {
        private SqlCommand InsertCmd = new SqlCommand("InsertCMD");
        private SqlCommand DeleteCmd = new SqlCommand("DeleteCMD");
        //private SqlCommand ListCmd = new SqlCommand("ListData"); // does not work?
        private SqlCommand EditCmd = new SqlCommand("EditCMD");

        //public DataTable ListData(string getCon)
        //{
        //    DataTable dt = new DataTable();

        //    SqlConnection con = new SqlConnection(getCon);
        //    ListCmd.Connection = con;
        //    ListCmd.CommandType = CommandType.StoredProcedure;

        //    con.Open();

        //    using (SqlDataAdapter da = new SqlDataAdapter(ListCmd))
        //    {
        //        da.Fill(dt); //returning empty
        //    }

        //    con.Close();

        //    return dt;
        //}

        public void EditData(string getCon)
        {
            SqlConnection con = new SqlConnection(getCon);
            EditCmd.Connection = con;
            EditCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            EditCmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteData(string getCon)
        {
            SqlConnection con = new SqlConnection(getCon);
            DeleteCmd.Connection = con;
            DeleteCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            DeleteCmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertData(string getCon)
        {

            SqlConnection con = new SqlConnection(getCon);
            InsertCmd.Connection = con;
            InsertCmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            InsertCmd.ExecuteNonQuery();
            con.Close();
        }

        public void storeInsertParams(string getName, string getData)
        {
            InsertCmd.Parameters.AddWithValue(getName, getData);
        }

        public void storeDeleteParams(string getName, int getData)
        {
            DeleteCmd.Parameters.AddWithValue(getName, getData);
        }

        public void storeEditParamsID(string getName, int getData)
        {
            EditCmd.Parameters.AddWithValue(getName, getData);
        }

        public void storeEditParams(string getName, string getData)
        {
            EditCmd.Parameters.AddWithValue(getName, getData);
        }

    }

}