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

public partial class _Default : System.Web.UI.Page
{
    public string checkLoggedIn;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        { //gets if there's a user logged in
            checkLoggedIn = Session["loggedin"].ToString();

            if (checkLoggedIn.Equals("True"))
            {
                Response.Redirect("Welcome.aspx");
            }
        }

        catch (Exception) { }

    }

    protected void expBtn_Click(object sender, EventArgs e)
    {
        if (Panel1.Visible == true)
        {
            Panel1.Visible = false;
            expBtn.Text = "Expand for more options";
        }

        else
        {
            Panel1.Visible = true;
            expBtn.Text = "De-expand more options";
        }

        setServers();
    }

    protected void loginBtn_Click(object sender, EventArgs e)
    {
        setServers();

        Session["email"] = emailTxt.Text; //passes email to current Session
        Session["pwd"] = pwdTxt.Text; //passes pwd to current Session
        Response.Redirect("Welcome.aspx");
    }

    bool isPOP = false;
    bool isIMAP = false;

    public void setServers() {


          if (emailTxt.Text.Contains("@gmail"))
        {
            switch (DropDownList1.SelectedIndex)
            {
                case 0: //passes gmail pop info to current Session
                    if (emailTxt.Text.Contains("@gmail"))
                    {
                        popsvTxt.Text = "pop.gmail.com";
                        Session["popsv"] = popsvTxt.Text;

                        popportTxt.Text = "995";
                        Session["popPort"] = popportTxt.Text;

                        smtpsvTxt.Text = "smtp.gmail.com";
                        Session["smtpsv"] = smtpsvTxt.Text;

                        smtpportTxt.Text = "587";
                        Session["smtpport"] = smtpportTxt.Text;

                        isPOP = true;
                        Session["isPOP"] = isPOP;
                    }
                    break;
                case 1: //passes gmail imap info to current Session
                    if (emailTxt.Text.Contains("@gmail"))
                    {
                        popsvTxt.Text = "imap.gmail.com";
                        Session["imapsv"] = popsvTxt.Text;

                        popportTxt.Text = "993";
                        Session["imapport"] = popportTxt.Text;

                        smtpsvTxt.Text = "smtp.gmail.com";
                        Session["smtpsv"] = smtpsvTxt.Text;

                        smtpportTxt.Text = "587";
                        Session["smtpport"] = smtpportTxt.Text;

                        isIMAP = true;
                        Session["isIMAP"] = isIMAP;
                    }
                    break;
                default: Response.Redirect("Default.aspx");
                    break;
            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        setServers();
    }

}
