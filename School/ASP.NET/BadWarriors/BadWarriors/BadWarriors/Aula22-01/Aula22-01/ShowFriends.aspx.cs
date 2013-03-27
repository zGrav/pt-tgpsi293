using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula22_01
{
    public partial class ShowFriends : System.Web.UI.Page
    {
        private string getCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        int ownID;
        FriendManagement fm = new FriendManagement();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                fm.grabIDParams("@username", Session["username"].ToString());
                int ownID = fm.grabID(getCon);

                Session["ownID"] = ownID;

                if (GridView1.Rows.Count <= 0)
                {
                    Label1.Visible = true;
                    Label1.Text = "No data to show";
                }
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text.Length > 0)
                {
                    fm.deleteFriendParams("@requestid", Convert.ToInt32(TextBox1.Text));

                    fm.deleteFriend(getCon);
                }

                Response.Redirect("~/ShowFriends.aspx");

            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = "An error has occured.";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
        }
    }
}