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
using System.Text.RegularExpressions;
using System.Text;

public partial class showmail : System.Web.UI.Page
{
    #region "Variables"
    //Session data
    public string checkLoggedIn;
    public string popHost;
    public int popPort;
    public string getMail;
    public string getPW;

    //Regex expressions
    protected static Regex charRegex = new Regex("charset=\"?(?<charset>[^\\s\"]+)\"?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    protected static Regex quotedRegex = new Regex("=(?<hexchars>[0-9a-fA-F]{2,2})", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    protected static Regex uriRegex = new Regex("(?<url>https?://[^\\s\"]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    protected static Regex fileRegex = new Regex("filename=\"?(?<filename>[^\\s\"]+)\"?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    protected static Regex nameRegex = new Regex("name=\"?(?<filename>[^\\s\"]+)\"?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        int mailID = -1; //loads without ID to prevent errors.

        if (Request.QueryString["mailID"] == null)
        {
            Response.Redirect("Inbox.aspx", false);
        }

        else
        {
            popHost = Session["popsv"].ToString();
            popPort = Convert.ToInt32(Session["popPort"]);
            getMail = Session["email"].ToString();
            getPW = Session["pwd"].ToString();
	        mailID = Convert.ToInt32(Request.QueryString["mailID"]); //gets ID from Inbox.aspx

		z.getMail mail = null;
		List<z.getMessage> fetchParts = null;

		using (popSession client = new popSession(popHost, popPort, getMail, getPW, true))
		{
			client.doConnect();
			mail = client.grab(mailID); //grabs message
			fetchParts = client.getParts(mailID); //grabs message body
		}

		if (mail == null || fetchParts == null)
		{
			Response.Redirect("Inbox.aspx", false);
		}

		z.getMessage preferredPart = findPart(fetchParts, "text/html"); //finds text

		if (preferredPart == null)
        {
            preferredPart = findPart(fetchParts, "text/plain");
        }

		else if (preferredPart == null && fetchParts.Count > 0)
        {
			preferredPart = fetchParts[0];
        }

		string contentType, charset, contentTransferEncoding, body = null;

		if (preferredPart != null)
		{
			contentType = preferredPart.getHeaders["Content-Type"];
			charset = "us-ascii";
			contentTransferEncoding =preferredPart.getHeaders["Content-Transfer-Encoding"];
			Match m = charRegex.Match(contentType);

			if (m.Success)
            {
				charset = m.Groups["charset"].Value; //gets charset type of message
            }

            //parses message content-type and encoding
			Headers.Text = contentType != null ? "Content-Type: " +contentType + "<br />" : string.Empty;
			Headers.Text += contentTransferEncoding != null ?"Content-Transfer-Encoding: " +contentTransferEncoding : string.Empty;

			if (contentTransferEncoding != null) //decodes message
			{
				if (contentTransferEncoding.ToLower() == "base64")
                {
					body = decodeB64(charset,preferredPart.getMessageText);
                }

				else if (contentTransferEncoding.ToLower() =="quoted-printable")
                {
					body = decodequoteString(preferredPart.getMessageText);
                }

				else
                {
					body = preferredPart.getMessageText;
                }
			}

			else
            {
				body = preferredPart.getMessageText;
            }
		}

		mailIDL.Text = Convert.ToString(mailID);
		Date.Text = mail.getDateTime.ToString(); ;
		From.Text = mail.getFrom;
		Subject.Text = mail.getSubject;
		Body.Text = preferredPart != null ? (preferredPart.getHeaders["Content-Type"].IndexOf("text/plain") != -1 ?"<pre>" + uriFormat(body) + "</pre>" : body) : null; //parses message body text
		getAttach(fetchParts); //gets attachments if any
	}
    }

    protected Decoder doDecoding(string charset) //decodes
    {
        Decoder decode;
        switch (charset.ToLower())
        {
            case "utf-7":
                decode = Encoding.UTF7.GetDecoder();
                break;
            case "utf-8":
                decode = Encoding.UTF8.GetDecoder();
                break;
            case "us-ascii":
                decode = Encoding.ASCII.GetDecoder();
                break;
            case "iso-8859-1":
                decode = Encoding.ASCII.GetDecoder();
                break;
            default:
                decode = Encoding.ASCII.GetDecoder();
                break;
        }
        return decode;
    }

    protected string decodeB64(string chars, string encoded) //decodes if b64
    {
        Decoder decode = doDecoding(chars);
        byte[] buff = Convert.FromBase64String(encoded);
        char[] arr = new char[decode.GetCharCount(buff,0, buff.Length)];
        decode.GetChars(buff, 0, buff.Length, arr, 0);
        return new string(arr);
    }

    protected string decodequoteString(string encoded) //decodes quoted strings
    {
        StringBuilder build = new StringBuilder();
        int start = 0;
        MatchCollection getMatch = quotedRegex.Matches(encoded);
        for (int i = 0; i < getMatch.Count; i++)
        {
            Match getM = getMatch[i];
            string hexchars = getM.Groups["hexchars"].Value;
            int code = Convert.ToInt32(hexchars, 16);
            char getChar = (char)code;

            if (getM.Index > 0)
            {
                build.Append(encoded.Substring(start, (getM.Index - start)));
            }

            build.Append(getChar);
            start = getM.Index + 3;
        }

        if (start < encoded.Length)
        {
            build.Append(encoded.Substring(start));
        }

        return Regex.Replace(build.ToString(), "=\r\n", "");
    }

    protected void getAttach(List<getMessage> fetchParts) //gets attachments
    {
        bool isFound= false;
        StringBuilder build = new StringBuilder();
        build.Append("<ol>");

        foreach (getMessage part in fetchParts)
        {
            string getContentType = part.getHeaders["Content-Type"];
            string getContentDisposition = part.getHeaders["Content-Disposition"];
            Match getMatch;

            if (getContentDisposition != null)
            {
                getMatch = fileRegex.Match(getContentDisposition);

                if (getMatch.Success)
                {
                    isFound = true;
                    build.Append("<li>").Append(getMatch.Groups["filename"].Value).Append("</li>");
                }
            }

            else if (getContentType != null)
            {
                getMatch = nameRegex.Match(getContentType);

                if (getMatch.Success)
                {
                    isFound = true;
                    build.Append("<li>").Append(getMatch.Groups["filename"].Value).Append("</li>");
                }
            }
        }

        build.Append("</ol>");

        if (isFound)
        {
            Attachments.Text = build.ToString();
        }

        else
        {
            attachementSection.Visible = false;
        }
    }

    protected getMessage findPart(List<getMessage> fetchParts,string getContentType) //gets message parts
    {
        foreach (getMessage part in fetchParts)
        {
            if (part.getContentType != null && part.getContentType.IndexOf(getContentType) != -1)
            {
                return part;
            }
        }
            return null;
    }

    protected string uriFormat(string getText) //formats urls to proper type
    {
        string replace = "<a href=\"${url}\">${url}</a>";
        return uriRegex.Replace(getText, replace);
    }
}
