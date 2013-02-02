using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Aula22_01
{
    public partial class Main1 : System.Web.UI.Page
    {
        private string getCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string getCmd;

            Label7.Text = Session["username"].ToString();

            GameManagement gm = new GameManagement();

            gm.grabStatsParams("@username", Label7.Text);

            getCmd = "GrabStatsHP";
            Label1.Text = gm.grabStats(getCon, getCmd).ToString();

            getCmd = "GrabStatsMoney";
            Label2.Text = gm.grabStats(getCon, getCmd).ToString();

            getCmd = "GrabStatsAttack";
            Label3.Text = gm.grabStats(getCon, getCmd).ToString();

            getCmd = "GrabStatsDefense";
            Label4.Text = gm.grabStats(getCon, getCmd).ToString();

            getCmd = "GrabStatsWins";
            Label5.Text = gm.grabStats(getCon, getCmd).ToString();

            getCmd = "GrabStatsLosses";
            Label6.Text = gm.grabStats(getCon, getCmd).ToString();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void btnStore_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Store.aspx");
        }

        protected void btnRanking_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Ranking.aspx");
        }

        protected void btnFriends_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Friends.aspx");
        }
    }
}