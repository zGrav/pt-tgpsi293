using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula22_01
{
    public partial class Challenge : System.Web.UI.Page
    {
        private string getCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        GameManagement gm = new GameManagement();
        string getuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                getuser = Session["username"].ToString();
            }

            catch (Exception) {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try {
            if (getuser.Equals(TextBox1.Text))
            {
                Label2.Visible = true;
                Label2.Text = "You cannot fight yourself.";
                return;
            }

            gm.grabStatsParams("@username", getuser);

            string getCmd = "GrabStatsHP";
            string ohp = gm.grabStats(getCon, getCmd).ToString();
            int ownhp;
            int.TryParse(ohp, out ownhp);

            if (ownhp <= 0)
            {
                Label2.Visible = true;
                Label2.Text = "This battle cannot continue.";
            }

            if (TextBox1.Text.Length != 0)
            {
                GameManagement gm2 = new GameManagement();
                gm2.grabStatsParams("@username", TextBox1.Text);

                string getCmd2 = "GrabStatsHP";
                string ehp = gm2.grabStats(getCon, getCmd2).ToString();
                int enemyhp;
                int.TryParse(ehp, out enemyhp);

                if (enemyhp <= 0)
                {
                    Label2.Visible = true;
                    Label2.Text = "This battle cannot continue.";
                    return;
                }

                GameManagement gm3 = new GameManagement();

                gm3.grabStatsParams("@username", getuser);

                string getCmd3 = "GrabStatsAttack";
                string atk = gm3.grabStats(getCon, getCmd3).ToString();
                int convatk;
                int.TryParse(atk, out convatk);

                GameManagement gm4 = new GameManagement();

                gm4.grabStatsParams("@username", TextBox1.Text);

                string getCmd4 = "GrabStatsDefense";
                string def = gm4.grabStats(getCon, getCmd4).ToString();
                int convdef;
                int.TryParse(def, out convdef);

                if (convatk == convdef)
                {
                    Label2.Visible = true;
                    Label2.Text = "Draw match, routine not executed.";
                    return;
                }

                if (convatk > convdef)
                {
                    Label2.Visible = true;
                    Label2.Text = "You win! -15hp to enemy";

                    gm.minushpParams("@username", TextBox1.Text);

                    gm.minushp(getCon);

                    gm.addWinParams("@username", getuser);

                    gm.addWin(getCon);

                    gm.addLossParams("@username", TextBox1.Text);

                    gm.addLoss(getCon);

                    FriendManagement fm = new FriendManagement();

                    fm.grabIDParams("@username", getuser);

                    int ownID = fm.grabID(getCon);

                    FriendManagement fm2 = new FriendManagement();

                    fm2.grabIDParams("@username", TextBox1.Text);

                    int enemyID = fm2.grabID(getCon);

                    gm.logChallengeParams("@challenger", ownID);

                    gm.logChallengeParams("@challenged", enemyID);

                    string timestamp = GetUnixTimestamp().ToString();

                    gm.logChallengeParamsTime("@timestamp", timestamp);

                    gm.logChallengeParams("@iswin", 1);

                    gm.logChallengeParams("@isloss", 0);

                    gm.logChallenge(getCon);
                }
                else
                {
                    Label2.Visible = true;
                    Label2.Text = "You lose! -15 hp to you";

                    gm.minushpParams("@username", getuser);

                    gm.minushp(getCon);

                    gm.addWinParams("@username", TextBox1.Text);

                    gm.addWin(getCon);

                    gm.addLossParams("@username", getuser);

                    gm.addLoss(getCon);

                    FriendManagement fm = new FriendManagement();

                    fm.grabIDParams("@username", getuser);

                    int ownID = fm.grabID(getCon);

                    FriendManagement fm2 = new FriendManagement();

                    fm2.grabIDParams("@username", TextBox1.Text);

                    int enemyID = fm2.grabID(getCon);

                    gm.logChallengeParams("@challenger", ownID);

                    gm.logChallengeParams("@challenged", enemyID);

                    string timestamp = GetUnixTimestamp().ToString();

                    gm.logChallengeParamsTime("@timestamp", timestamp);

                    gm.logChallengeParams("@iswin", 0);

                    gm.logChallengeParams("@isloss", 1);

                    gm.logChallenge(getCon);
                } 
            }
            }
            catch (Exception ex) {
            
            Label2.Visible = true;
            Label2.Text = "An error has occurred";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChallengeHistory.aspx");
        }

        internal static int GetUnixTimestamp()
        {
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            double unixTime = ts.TotalSeconds;
            return (int)unixTime;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChallengePractice.aspx");
        }
    }
}