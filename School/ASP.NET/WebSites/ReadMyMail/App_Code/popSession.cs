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

namespace z
{
    public class popSession : IDisposable
    {
        #region "Variables"
        public string popServer { get; protected set; }
        public int popPort { get; protected set; }
        public string popMail { get; protected set; }
        public string popPwd { get; protected set; }
        public bool isSecure { get; protected set; }
        public TcpClient TCP { get; protected set; }
        public Stream popStream { get; protected set; }
        public StreamReader popRead { get; protected set; }
        public StreamWriter popWrite { get; protected set; }
        private bool isDisposed = false;
        public popSession(string getserver, int getport, string getemail, string getpass) : this(getserver, getport, getemail, getpass, false) { } //gets values from Default
        #endregion

        public popSession(string getserver, int getport, string getemail, string getpass, bool besecure)
        {
            popServer = getserver;
            popPort = getport;
            popMail = getemail;
            popPwd = getpass;
            isSecure = besecure; //gets from Welcome.aspx.cs
        }

        public void doConnect()
        {

            if (TCP == null)
            {
                TCP = new TcpClient();
            }

            if (!TCP.Connected)
            {
                TCP.Connect(popServer, popPort);
            }

            if (isSecure) // starts SSL connection
            {
                SslStream iamSecure = new SslStream(TCP.GetStream()); //creates new Stream
                iamSecure.AuthenticateAsClient(popServer); //makes secure auth to Server
                popStream = iamSecure; //passes Secure Stream to POP Client Stream
                iamSecure = null; //resets Stream
            }

            else //if not SSL connection
                popStream = TCP.GetStream(); //passes unencrypted TCPClient Stream to POP Stream
                popWrite = new StreamWriter(popStream); //awaits for commands to POP Stream
                popRead = new StreamReader(popStream); //awaits to read commands from POP Stream
                doReadLine(); // drops a new line on popRead
                doLogin(); //initiate login using checkResponse
        }

        public int countMail() // displays number of messages currently in mail
        {
            int doCount = 0;
            string getResponse = dosendCmd("STAT");

            if (checkResponse(getResponse))
            {
                string[] countArr = getResponse.Substring(4).Split(' ');
                doCount = Convert.ToInt32(countArr[0]);
            }

            else
            {
                doCount = -1;
            }
            return doCount;
        }

        public getMail grab(int mailIndex) //gets header of message
        {
            if (checkResponse(dosendCmd("TOP " + mailIndex + " 0")))
            {
                return new getMail(doReadLines());
            }

            else
            {
                return null;
            }
        }

        public List<getMail> grabList(int get, int count)
        {
            List<getMail> getList = new List<getMail>(count);

            for (int i = get; i < (get + count); i++)
            {
                getMail grabIt = grab(i);

                if (grabIt != null)
                {
                    getList.Add(grabIt);
                }
            }

            return getList;
        } //creates mail list from getMail.grab

        public List<getMessage> getParts(int mailID) //retrives message content
        {
            if (checkResponse(dosendCmd("RETR " + mailID)))
                return doParsing.ofParts(doReadLines());

            return null;
        }

        protected string doReadLine()
        {
            return popRead.ReadLine() + "\r\n";
        } //drops readline

        protected string doReadLines()
        {
            StringBuilder build = new StringBuilder();

            while (true) 
            {
                string buildtemp = doReadLine();

                if (buildtemp == ".\r\n" || buildtemp.IndexOf("-ERR") != -1) 
                {
                    break;
                }

                build.Append(buildtemp);
            }

            return build.ToString();
        } //drops readline

        protected void doLogin() //login
        {
            if (!checkResponse(dosendCmd("USER " + popMail)) || !checkResponse(dosendCmd("PASS " + popPwd)))
                throw new Exception("Invalid username/password");
        }

        protected void doLogout() //logout
        {
                dosendCmd("RSET");
        }

        protected string dosendCmd(string text) //sends command
        {
            popWrite.WriteLine(text); //receives text by value and sends to POP stream
            popWrite.Flush(); //flushes
            return doReadLine(); //drops newline on popRead
        }

        protected static bool checkResponse(string response) //checks server response
        {
            if (response.StartsWith("+OK"))
                return true; //all went good

            if (response.StartsWith("-ERR"))
                return false; //error occured

            throw new Exception("Unimplemented server response: " + response); //in case we get another Server Response
        }

        public void doClose() //closes
        { //closes streams and client
            if (TCP != null)
            {

                if (TCP.Connected)
                    doLogout();
                TCP.Close();
                TCP = null;
            }

            if (popStream != null)
            {
                popStream.Close();
                popStream = null;
            }

            if (popWrite != null)
            {
                popWrite.Close();
                popWrite = null;
            }

            if (popRead != null)
            {
                popRead.Close();
                popRead = null;
            }

            isDisposed = true;
        }

        public void Dispose() //disposes
        { //disposes streams and client
            if (!isDisposed)
                doClose();
        }
    }

    public class getMail
    {
        #region "Variables"
        public NameValueCollection getHeaders { get; protected set; }
        public string getContentType { get; protected set; }
        public DateTime getDateTime { get; protected set; }
        public string getFrom { get; protected set; }
        public string getTo { get; protected set; }
        public string getSubject { get; protected set; }
        #endregion

        public getMail(string mailtxt) //gets mail
        {
            getHeaders = doParsing.ofHeaders(mailtxt);
            getContentType = getHeaders["Content-Type"];
            getFrom = getHeaders["From"];
            getTo = getHeaders["To"];
            getSubject = getHeaders["Subject"];

            if (getHeaders["Date"] != null)
            {

                try
                {
                    getDateTime = doParsing.getDateTime(getHeaders["Date"]);
                }

                catch (FormatException)
                {
                    getDateTime = DateTime.MinValue;
                }
            }

            else
            {
                getDateTime = DateTime.MinValue;
            }
        }
    }

    public class getMessage
    {
        #region "Variables"
        public NameValueCollection getHeaders { get; protected set; }
        public string getContentType { get; protected set; }
        public string getMessageText { get; protected set; }
        #endregion

        public getMessage(NameValueCollection headers, string messageText) //gets message
        {
            getHeaders = headers;
            getContentType = getHeaders["Content-Type"];
            getMessageText = messageText;
        }
    }

    public class doParsing //displays the number of messages currently in the mailbox
    {
        #region "Regex Variables"
        protected static Regex bounds = new Regex("Content-Type: multipart(?:/\\S+;)" + "\\s+[^\r\n]*boundary=\"?(?<boundary>" + "[^\"\r\n]+)\"?\r\n", RegexOptions.IgnoreCase | RegexOptions.Compiled); //searches for Content-Type
        protected static Regex datetime = new Regex(@"^(?:\w+,\s+)?(?<day>\d+)\s+(?<month>\w+)\s+(?<year>\d+)\s+(?<hour>\d{1,2})" + @":(?<minute>\d{1,2}):(?<second>\d{1,2})\s+(?<offsetsign>\-|\+)(?<offsethours>" + @"\d{2,2})(?<offsetminutes>\d{2,2})(?:.*)$", RegexOptions.IgnoreCase | RegexOptions.Compiled); //searches for DateTime
        #endregion

        public static NameValueCollection ofHeaders(string htext) //parses message header
        {
            NameValueCollection getHeaders = new NameValueCollection();
            StringReader readHeader = new StringReader(htext);
            string doLine;
            string nameofHeader = null;
            string valueofHeader;
            int colon;

            while ((doLine = readHeader.ReadLine()) != null)
            {
                if (doLine == "")
                {
                    break;
                }

                if (Char.IsLetterOrDigit(doLine[0]) && (colon = doLine.IndexOf(':')) != -1)
                {
                    nameofHeader = doLine.Substring(0, colon);
                    valueofHeader = doLine.Substring(colon + 1).Trim();
                    getHeaders.Add(nameofHeader, valueofHeader);
                }

                else if (nameofHeader != null)
                {
                    getHeaders[nameofHeader] += " " + doLine.Trim();
                }

                else
                {
                    throw new FormatException("Incorrect Header Parsing occured.");
                }
            }
            return getHeaders;

        }

        public static List<getMessage> ofParts(string mailtext) //parses message part
        {
            List<getMessage> getParts = new List<getMessage>();

            int newLine = mailtext.IndexOf("\r\n\r\n");

            Match tryMatch = bounds.Match(mailtext);

            if (tryMatch.Index < mailtext.IndexOf("\r\n\r\n") && tryMatch.Success)
            {
                string getBounds = tryMatch.Groups["boundary"].Value;
                string startBounds = "\r\n--" + getBounds;

                int startBoundsIndex = -1;

                while (true)
                {
                    if (startBoundsIndex == -1)
                    {
                        startBoundsIndex = mailtext.IndexOf(startBounds);
                    }

                    if (startBoundsIndex != -1)
                    {
                        int nextBoundIndex = mailtext.IndexOf(startBounds, startBoundsIndex + startBounds.Length);

                        if (nextBoundIndex != -1 && nextBoundIndex != startBoundsIndex)
                        {
                            string multipart = mailtext.Substring(startBoundsIndex + startBounds.Length, (nextBoundIndex - startBoundsIndex - startBounds.Length));
                            int headerIndex = multipart.IndexOf("\r\n\r\n");

                            if (headerIndex == -1)
                            {
                                throw new FormatException("Incompatible message format");
                            }

                            string bodyContent = multipart.Substring(headerIndex).Trim();

                            NameValueCollection getHeaders = z.doParsing.ofHeaders(multipart.Trim());

                            getParts.Add(new getMessage(getHeaders, bodyContent));
                        }

                        else
                        {
                            break;
                        }

                        startBoundsIndex = nextBoundIndex;
                    }

                    else
                    {
                        break;
                    }

                }

                if (newLine != -1)
                {
                    string mailBody = mailtext.Substring(newLine + 1);
                }
            }

            else
            {
                int headerIndex = mailtext.IndexOf("\r\n\r\n");

                if (headerIndex == -1)
                {
                    throw new FormatException("Incompatible message format");
                }

                string bodyContent = mailtext.Substring(headerIndex).Trim();
                NameValueCollection headers = z.doParsing.ofHeaders(mailtext);
                getParts.Add(new getMessage(headers, bodyContent));
            }
            return getParts;
        }

        public static DateTime getDateTime(string getdt) //parses datetime
        {
            Match compare = datetime.Match(getdt);
            int getDay, getMonth, getYear, getHour, getMin, getSec;

            if (compare.Success)
            {
                getDay = Convert.ToInt32(compare.Groups["day"].Value);
                getYear = Convert.ToInt32(compare.Groups["year"].Value);
                getHour = Convert.ToInt32(compare.Groups["hour"].Value);
                getMin = Convert.ToInt32(compare.Groups["minute"].Value);
                getSec = Convert.ToInt32(compare.Groups["second"].Value);

                switch (compare.Groups["month"].Value)
                {
                    case "Jan":
                        getMonth = 1;
                        break;

                    case "Feb":
                        getMonth = 2;
                        break;

                    case "Mar":
                        getMonth = 3;
                        break;

                    case "Apr":
                        getMonth = 4;
                        break;

                    case "May":
                        getMonth = 5;
                        break;

                    case "Jun":
                        getMonth = 6;
                        break;

                    case "Jul":
                        getMonth = 7;
                        break;

                    case "Aug":
                        getMonth = 8;
                        break;

                    case "Sep":
                        getMonth = 9;
                        break;

                    case "Oct":
                        getMonth = 10;
                        break;

                    case "Nov":
                        getMonth = 11;
                        break;

                    case "Dec":
                        getMonth = 12;
                        break;

                    default:
                        throw new FormatException("Invalid month.");
                }

                string offSet = compare.Groups["offset"].Value;
                int offSetH = Convert.ToInt32(compare.Groups["offsethours"].Value);
                int offSetM = Convert.ToInt32(compare.Groups["offsetminutes"].Value);
                DateTime doDT = new DateTime(getYear, getMonth, getDay, getHour, getMin, getSec);

                if (offSet == "+")
                {
                    doDT.AddHours(offSetH);
                    doDT.AddMinutes(offSetM);
                }

                else if (offSet == "-")
                {
                    doDT.AddHours(-offSetH);
                    doDT.AddMinutes(-offSetM);
                }

                return doDT;
            }

            throw new FormatException("DateTime parsing failed.");
        }
    }
}