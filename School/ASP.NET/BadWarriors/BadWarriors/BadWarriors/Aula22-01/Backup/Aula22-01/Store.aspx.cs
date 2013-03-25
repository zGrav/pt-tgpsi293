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
            GameManagement gm = new GameManagement();
            gm.updateStatsParams("@username", Session["username"].ToString());

            gm.updateStatsParams("@getattack", TextBox2.Text);
            gm.updateStatsParams("@getdefense", TextBox3.Text);
            gm.updateStatsParams("@getprice", TextBox4.Text);
           // gm.updateStatsParams("@getitemid", GridView1.SelectedRow.Cells[1].Text);

            gm.updateStats(getCon);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }
    }
}