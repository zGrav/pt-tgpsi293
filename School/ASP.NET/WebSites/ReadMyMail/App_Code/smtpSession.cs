using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for smtpSession
/// </summary>

namespace z {

public class smtpSession : IDisposable
{

#region "Variables"
        public string smtpServer { get; protected set; }
        public int smtpPort { get; protected set; }
        public string smtpMail { get; protected set; }
        public string smtpPwd { get; protected set; }
        public bool isSecure { get; protected set; }
        public SmtpClient SMTP { get; protected set; }
        private bool isDisposed = false;
        public bool isSent = false;
        public smtpSession(string getserver, int getport, string getemail, string getpass) : this(getserver, getport, getemail, getpass, false) { } //gets values from Default
#endregion

        public smtpSession(string getserver, int getport, string getemail, string getpass, bool besecure)
        {
            smtpServer = getserver;
            smtpPort = getport;
            smtpMail = getemail;
            smtpPwd = getpass;
            isSecure = besecure; //gets from Inbox.aspx.cs

     
        }

        public void sendMsg(string from, string recpt, string subject, string mailbody)
        {

            isSent = false;

            try
            {
                MailMessage newMail = new MailMessage();

                newMail.From = new MailAddress(from);
                newMail.To.Add(recpt);
                newMail.Subject = subject;
                newMail.Body = mailbody + "\n \n" + "Sent using ReadMyMail alpha 1.";

                SMTP = new SmtpClient(smtpServer, smtpPort);

                SMTP.Credentials = new NetworkCredential(smtpMail, smtpPwd);
                SMTP.EnableSsl = isSecure;
                SMTP.Send(newMail);

                isDisposed = true;
            }

            catch (Exception) { throw new Exception("Connection to SMTP Server timed out."); }

            isSent = true;
            Dispose();
        }

        public void Dispose()
        { //disposes client
            if (!isDisposed)
                SMTP.Dispose();
        }

        }

        }