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

public partial class Compose : System.Web.UI.Page
{
    #region "Variables"
    //Data related
    public string grabEmail;
    public string grabPassword;
    public string grabSMTPHost;
    public int grabSMTPPort;

    //client related
    public string checkLoggedIn;
    public z.smtpSession smtpClient;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { //gets if there's a user logged in
            checkLoggedIn = Session["loggedin"].ToString();

            if (checkLoggedIn.Equals("False"))
            {
                Response.Redirect("Default.aspx");
            }

            else
            {
                grabSMTPHost = Session["smtpsv"].ToString();
                grabSMTPPort = Convert.ToInt32(Session["smtpport"]);
                grabEmail = Session["email"].ToString();
                grabPassword = Session["pwd"].ToString();
            }
        }

        catch (Exception) { Response.Redirect("Default.aspx"); }

    }

    protected void sendBtn_Click(object sender, EventArgs e)
    {
        using (smtpClient = new z.smtpSession(grabSMTPHost, grabSMTPPort, grabEmail, grabPassword, true))
        {
            grabEmail = smtpClient.smtpMail;
            smtpClient.sendMsg(grabEmail, toTxt.Text, subTxt.Text, mesTxt.Text);

            if (smtpClient.isSent == true)
            {
                statusLbl.Text = "Email sent.";
            }

            else
            {
                statusLbl.Text = "Connection to SMTP Server timed out, please try again.";
            }
        }
    }
}
