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
        FriendManagement fm2 = new FriendManagement();

        string getusername;
        int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            try {
            getusername = Session["username"].ToString();

            fm.grabIDParams("@username", getusername);

            userID = fm.grabID(getCon);

            Session["ownID"] = userID;

            }
            catch (Exception) {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (TextBox1.Text.Length != 0)
                {

                    if (getusername.Equals(TextBox1.Text))
                    {
                        Label2.Visible = true;
                        Label2.Text = "You cannot add yourself.";
                        return;
                    }

                    fm.sendRequestParams("@senderid", userID);

                    fm2.grabIDParams("@username", TextBox1.Text);

                    int receiverID = fm2.grabID(getCon);

                    fm.sendRequestParams("@receiverid", receiverID);

                    int timestamp = GetUnixTimestamp();

                    fm.sendRequestParams("@timerequest", timestamp);

                    fm.sendRequest(getCon);

                    Label2.Visible = true;
                    Label2.Text = "Friend added successfully.";
                }
            }
            catch (Exception ex)
            {
                Label2.Visible = true;
                Label2.Text = "An error has occured.";
            }
        }

        internal static int GetUnixTimestamp()
        {
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            double unixTime = ts.TotalSeconds;
            return (int)unixTime;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ShowFriends.aspx");
        }
    }
}