using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Aula22_01
{
    public partial class Friends : System.Web.UI.Page
    {
        private string getCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        FriendManagement fm = new FriendManagement();

        string getusername;

        protected void Page_Load(object sender, EventArgs e)
        {
            try {
            getusername = Session["username"].ToString();

            fm.grabIDParams("@username", getusername);

            int userID = fm.grabID(getCon);

            Session["ownID"] = userID;

            }
            catch (Exception) {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Length != 0)
            {
                fm.grabIDParams("@username", getusername);

                int senderID = fm.grabID(getCon);

                fm.sendRequestParams("@senderid", senderID);

                fm.grabIDParams("@username", TextBox1.Text);

                int receiverID = fm.grabID(getCon);

                fm.sendRequestParams("@receiverid", receiverID);

                int timestamp = GetUnixTimestamp();

                fm.sendRequestParams("@timerequest", timestamp);
            }
        }

        internal static int GetUnixTimestamp()
        {
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            double unixTime = ts.TotalSeconds;
            return (int)unixTime;
        }
    }
}