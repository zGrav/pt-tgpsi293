using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aula22_01
{
    public partial class ChallengePractice : System.Web.UI.Page
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

            catch (Exception)
            {
                Response.Redirect("~/Login.aspx");
            }

            try
            {
                gm.grabStatsParams("@username", getuser);

                string getCmd = "GrabStatsHP";
                string ohp = gm.grabStats(getCon, getCmd).ToString();
                int ownhp;
                int.TryParse(ohp, out ownhp);

                if (ownhp <= 0)
                {
                    Label1.Visible = true;
                    Label1.Text = "This battle cannot continue.";
                }

                GameManagement gm2 = new GameManagement();

                gm2.grabStatsParams("@username", getuser);

                string getCmd3 = "GrabStatsAttack";
                string atk = gm2.grabStats(getCon, getCmd3).ToString();

                int convatk;
                int.TryParse(atk, out convatk);

                Random rnd = new Random();

                int convdef = rnd.Next(10, convatk + 100);

                if (convatk > convdef)
                {
                    Label1.Visible = true;
                    Label1.Text = "You win vs CPU practice!";

                    FriendManagement fm = new FriendManagement();

                    fm.grabIDParams("@username", getuser);

                    int ownID = fm.grabID(getCon);

                    gm.logChallengeParams("@challenger", ownID);

                    gm.logChallengeParams("@challenged", -1); //cpu

                    string timestamp = GetUnixTimestamp().ToString();

                    gm.logChallengeParamsTime("@timestamp", timestamp);

                    gm.logChallengeParams("@iswin", 1);

                    gm.logChallengeParams("@isloss", 0);

                    gm.logChallenge(getCon);
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "You lose vs CPU practice!";

                    FriendManagement fm = new FriendManagement();

                    fm.grabIDParams("@username", getuser);

                    int ownID = fm.grabID(getCon);

                    gm.logChallengeParams("@challenger", ownID);

                    gm.logChallengeParams("@challenged", -1); //cpu

                    string timestamp = GetUnixTimestamp().ToString();

                    gm.logChallengeParamsTime("@timestamp", timestamp);

                    gm.logChallengeParams("@iswin", 0);

                    gm.logChallengeParams("@isloss", 1);

                    gm.logChallenge(getCon);
                }
            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = "An error has occurred";
            }
        }

        internal static int GetUnixTimestamp()
        {
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            double unixTime = ts.TotalSeconds;
            return (int)unixTime;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main.aspx");
        }
    }
}