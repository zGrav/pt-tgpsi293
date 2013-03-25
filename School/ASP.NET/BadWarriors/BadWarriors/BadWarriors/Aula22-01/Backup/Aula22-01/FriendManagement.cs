using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Aula22_01
{
    public class FriendManagement
    {
        private SqlCommand sendRequestCmd = new SqlCommand("SendRequest");
        private SqlCommand receiveRequestCmd = new SqlCommand("ReceiveRequest");
        private SqlConnection con = new SqlConnection();

        public void sendRequest(string getCon)
        {

        }

        public void sendRequestParams(string getName, string getData)
        {

        }

        public void receiveRequest(string getCon)
        {

        }

        public void receiveRequestParams(string getName, string getData)
        {

        }
    }

}