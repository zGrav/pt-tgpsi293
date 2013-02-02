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

public partial class Inbox : System.Web.UI.Page
{
    #region "Variables"
    //Session data
    public string checkLoggedIn;
    public string popHost;
    public int popPort;
    public string getMail;
    public string getPW;

    //Inbox related data
    public const int perPage = 5; //shows 5 emails per page
    public int page = 1; // page number
    public const string fixLink = "<a href=\"Inbox.aspx?page={0}\">{1}</a>"; //works as forward and previous receiving page number accordingly
    public const string displayMailLink = "<a href=\"showmail.aspx?mailID={0}\">{1}</a>"; //gets mail ID and shows the proper message
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
                if (Request.QueryString["page"] == null)
                {
                    Response.Redirect("Inbox.aspx?page=1", false);
                }

                else
                {
                    page = Convert.ToInt32(Request.QueryString["page"]);
                }

                try
                {
                    popHost = Session["popsv"].ToString();
                    popPort = Convert.ToInt32(Session["popPort"]);
                    getMail = Session["email"].ToString();
                    getPW = Session["pwd"].ToString();
                }

                catch (Exception)
                {
                    Response.Redirect("Welcome.aspx");
                }


            }

        }

        catch (Exception) { Response.Redirect("Default.aspx"); }

        int totalMail;
        List<z.getMail> mails; //creates mail list
        string mailAddress;

        using (popSession client = new popSession(popHost, popPort, getMail, getPW, true))
        {
            mailAddress = client.popMail;
            client.doConnect();

            totalMail = client.countMail();

            mails = client.grabList(((page - 1) * perPage) + 1, perPage);
        }

        int getTotal; //total messages inbox
        int doMod = totalMail % perPage; //so we can order mail per page

        if (doMod == 0)
        {
            getTotal = totalMail / perPage;
        }

        else
        {
            getTotal = ((totalMail - doMod) / perPage) + 1;
        }

        for (int i = 0; i < mails.Count; i++) //organizes emails in a array
        {
            z.getMail mail = mails[i];

            int mailID = ((page - 1) * perPage) + i + 1;

            TableCell noCell = new TableCell();
            noCell.CssClass = "mail-table-cell";
            noCell.Text = Convert.ToString(mailID);

            TableCell fromCell = new TableCell();
            fromCell.CssClass = noCell.CssClass;
            fromCell.Text = mail.getFrom;

            TableCell subjectCell = new TableCell();
            subjectCell.CssClass = noCell.CssClass;
            subjectCell.Style["width"] = "300px";
            subjectCell.Text = String.Format(displayMailLink, mailID, mail.getSubject);

            TableCell datetimeCell = new TableCell();
            datetimeCell.CssClass = noCell.CssClass;
            if (mail.getDateTime != DateTime.MinValue)
            {
                datetimeCell.Text = mail.getDateTime.ToString();
            }

            TableRow mailRow = new TableRow();
            mailRow.Cells.Add(noCell);
            mailRow.Cells.Add(fromCell);
            mailRow.Cells.Add(subjectCell);
            mailRow.Cells.Add(datetimeCell);
            mailTable.Rows.AddAt(2 + i, mailRow);
        }

        if (totalMail > 1) //page navigation
        {
            if (page > 1)
            {
                previousPage.Text = String.Format(fixLink, page - 1, "Previous Page");
            }

            if (page > 0 && page < totalMail)
            {
                nextPage.Text = String.Format(fixLink, page + 1, "Next Page");
            }
        }

        mailFrom.Text = Convert.ToString(((page - 1) * perPage) + 1);
        mailTo.Text = Convert.ToString(page * perPage);
        mailTotal.Text = Convert.ToString(totalMail);
        getownMail.Text = mailAddress;
    }
}