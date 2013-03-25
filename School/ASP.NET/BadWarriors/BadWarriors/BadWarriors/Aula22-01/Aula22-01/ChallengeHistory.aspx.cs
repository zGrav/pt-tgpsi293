using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula22_01
{
    public partial class ChallengeHistory : System.Web.UI.Page
    {
        private string getCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int ownID;

        protected void Page_Load(object sender, EventArgs e)
        {
            FriendManagement fm = new FriendManagement();
            try
            {
                fm.grabIDParams("@username", Session["username"].ToString());
                int ownID = fm.grabID(getCon);

                Session["ownID"] = ownID;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }
    }
}