using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for imapSession
/// </summary>

namespace z //todo
{
    public class imapSession : IDisposable
    {
        public string imapServer { get; protected set; }
        public int imapPort { get; protected set; }
        public string popMail { get; protected set; }
        public string popPwd { get; protected set; }
        public bool isSecure { get; protected set; }
        public TcpClient TCP { get; protected set; }
        public Stream popStream { get; protected set; }
        public StreamReader popRead { get; protected set; }
        public StreamWriter popWrite { get; protected set; }
        private bool isDisposed = false;
        public imapSession(string getserver, int getport, string getemail, string getpass) : this(getserver, getport, getemail, getpass, false) { } //gets values from Default


        public imapSession(string getserver, int getport, string getemail, string getpass, bool besecure)
        {
            imapServer = getserver;
            imapPort = getport;
            popMail = getemail;
            popPwd = getpass;
            isSecure = besecure; //gets from Welcome.aspx.cs
        }

        public void Dispose()
        {
            
        }
    }
}