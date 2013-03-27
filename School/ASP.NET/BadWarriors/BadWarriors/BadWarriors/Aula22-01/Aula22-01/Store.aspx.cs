using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Aula22_01
{
    public partial class Store : System.Web.UI.Page
    {
        private string getCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string dowehaveaUser = Session["username"].ToString();

                if (dowehaveaUser == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox2.Text = GridView1.SelectedRow.Cells[4].Text;
            TextBox3.Text = GridView1.SelectedRow.Cells[5].Text;
            TextBox4.Text = GridView1.SelectedRow.Cells[3].Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GameManagement gm = new GameManagement();

                gm.grabStatsParams("@username", Session["username"].ToString());

                string getCmd = "GrabStatsMoney";
                string omoney = gm.grabStats(getCon, getCmd).ToString();
                int ownmoney;
                int.TryParse(omoney, out ownmoney);

                if (ownmoney < Convert.ToInt32(GridView1.SelectedRow.Cells[3].Text))
                {
                    Label5.Visible = true;
                    Label5.Text = "This purchase cannot continue.";

                    return;
                }

                gm.updateStatsParams("@username", Session["username"].ToString());

                gm.updateStatsParams("@getattack", TextBox2.Text);
                gm.updateStatsParams("@getdefense", TextBox3.Text);
                gm.updateStatsParams("@getprice", TextBox4.Text);
                // gm.updateStatsParams("@getitemid", GridView1.SelectedRow.Cells[1].Text);

                gm.updateStats(getCon);

                Label5.Visible = true;
                Label5.Text = "Purchase complete.";

            }
            catch (Exception ex)
            {
                Label5.Visible = true;
                Label5.Text = "An error occurred.";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }
    }
}