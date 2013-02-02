using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using z;

public partial class Welcome : System.Web.UI.Page
{
    #region "Variables"
    //POP related
    public string grabPOP;
    public string grabPOPHost;
    public int grabPOPPort;

    //IMAP related (not implemented)
    public string grabIMAP;
    public string grabIMAPHost;
    public int grabIMAPPort;

    //Data related
    public string grabEmail;
    public string grabPassword;
    public bool isLoggedIn = false;

    //Clients
    public z.popSession popClient;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            grabPOP = Session["isPOP"].ToString();

            if (grabPOP.Equals("True"))
            {

                try
                {
                    grabPOPHost = Session["popsv"].ToString();
                    grabPOPPort = Convert.ToInt32(Session["popPort"]);
                    grabEmail = Session["email"].ToString();
                    grabPassword = Session["pwd"].ToString();

                }
                catch (Exception) { Response.Redirect("Default.aspx"); }

                using (popClient = new z.popSession(grabPOPHost, grabPOPPort, grabEmail, grabPassword, true))
                {
                    grabEmail = popClient.popMail;
                    popClient.doConnect();
                    welcomeLbl.Text = "Welcome " + popClient.popMail + " !";
                }

                isLoggedIn = true;
                Session["loggedin"] = isLoggedIn;
                
            }

            else
            {
                grabIMAP = Session["isIMAP"].ToString();

                if (grabIMAP.Equals("True"))
                {
                    //toimplement
                }
            }
        }
        catch (Exception) { Response.Redirect("Default.aspx"); }
    }

    protected void logoutBtn_Click(object sender, EventArgs e)
    {
        string checkLoggedIn;

        try
        {
            checkLoggedIn = Session["loggedin"].ToString();

            if (checkLoggedIn.Equals("True"))
            {

                grabPOP = Session["isPOP"].ToString();

                if (grabPOP.Equals("True"))
                {
                    using (popClient = new z.popSession(grabPOPHost, grabPOPPort, grabEmail, grabPassword, true))
                    {
                        grabEmail = popClient.popMail;
                        popClient.doConnect(); //calls a new client so it can logout successfully.


                        popClient.Dispose();

                        isLoggedIn = false;
                        Session["loggedin"] = isLoggedIn;

                    }
                }
                Response.Redirect("Default.aspx", false);
            }
        }

        catch (Exception) { }
    }
}