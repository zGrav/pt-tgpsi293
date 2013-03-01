using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using LPO.Utillity;

namespace ESA_FileServer
{
	class MainClass
	{

private static Thread newThread; //file thread
        private static TcpListener listenTCP; //message TCPListener
        private static Thread listenThread; //message thread
        private static int flag = 0; //file flag
        private static string receivedPath = "/home/anticheat_logs"; //path for files.
        private static string fileName; //gets filename to store
        private static string getUsername; //gets username from client
        private static int getUsernameIndex; //used to organize files
        private static string getGame; //gets Game name from client
        private static int getGameIndex; //used to organize files
        private static string user; //gets username
        private static string game; //gets selected game by user
        private static int setPort = 8888; // folder creation port
        private static int setPort2 = 8889; // file upload port
        private static long launchTime; //gets time app was opened
        public delegate void invokehelp();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("#######");
            Console.WriteLine("#        ####    ##    ####    ##   #    # ###### ##### ");
            Console.WriteLine("#       #       #  #  #    #  #  #  ##  ## #      #    #");
            Console.WriteLine("#####    ####  #    # #      #    # # ## # #####  #    #");
            Console.WriteLine("#            # ###### #  ### ###### #    # #      #####");
            Console.WriteLine("#       #    # #    # #    # #    # #    # #      #   #");
            Console.WriteLine("#######  ####  #    #  ####  #    # #    # ###### #    #");
            Console.WriteLine("                                                        ");
            Console.WriteLine("###### # #      ######  ####  ###### #####  #    # ###### ##### ");
            Console.WriteLine("#      # #      #      #      #      #    # #    # #      #    #");
            Console.WriteLine("#####  # #      #####   ####  #####  #    # #    # #####  #    #");
            Console.WriteLine("#      # #      #           # #      #####  #    # #      #####");
            Console.WriteLine("#      # #      #      #    # #      #   #   #  #  #      #   #");
            Console.WriteLine("#      # ###### ######  ####  ###### #    #   ##   ###### #    #");
            
            launchTime = TextHandling.GetUnixTimestamp();
            conLog("Logging started.");

            conLog("Listening for connections on ports: " + setPort + " and " + setPort2);
            
            checkFolder(receivedPath);

            conLog("Saving files in: " + receivedPath);

            conLog("Bootup complete.");

            listenTCP = new TcpListener(IPAddress.Any, setPort); //starts Command Server on setPort
            listenThread = new Thread(new ThreadStart(clientListen)); //creates Command Thread
            listenThread.Start(); //starts Command Thread
            newThread = new Thread(new ThreadStart(startServer)); //creates File Thread
            newThread.Start(); //starts File Thread

        }

        private static void clientListen()
        {
            listenTCP.Start();

            while (true)
            {
                TcpClient client = listenTCP.AcceptTcpClient(); //accepts connection

                Thread clientThread = new Thread(new ParameterizedThreadStart(getClientResponse)); //each client = new thread

                clientThread.Start(client); //starts thread
            }
        }

        private static void getClientResponse(object client)
        {
            TcpClient tcpClient = (TcpClient)client; //passes client
            NetworkStream clientStream = tcpClient.GetStream(); //gets data

            byte[] message = new byte[4096]; //message buffer
            int bytesRead; //reader

            while (true)
            {
                bytesRead = 0; //sets buffer at 0

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096); //reads message
                }
                catch
                {
                    break; // if a error occurs.
                }

                if (bytesRead == 0)
                {
                    break; // client disconnected.
                }

                ASCIIEncoding encoder = new ASCIIEncoding(); //creates message encoder

                string getMsg = encoder.GetString(message, 0, bytesRead); //converts message from bytes to String
                
                if (getMsg.Contains("REQUEST USER FOLDER "))
                {
                    getMsg = getMsg.Remove(0, 20);
                    user = getMsg;
                    conLog("Connection accepted from user: " + user);
                    conLog("Request for user folder: " + user + " acknowledged.");
                    try
                    {
                        checkFolder(receivedPath + "/" + user);
                    }
                    catch (Exception)
                    {
                        conLog("Folder creation: " + receivedPath + "/" + user + " failed. Exception occured.");
                    }
                }

                if (getMsg.Contains("REQUEST GAME FOLDER"))
                {
                    getMsg = getMsg.Remove(0, 20);
                    game = getMsg;
                    conLog("Request for game folder: " + game + " acknowledged.");
                    try
                    {
                        checkFolder(receivedPath + "/" + game);
                    }
                    catch (Exception)
                    {
                        conLog("Folder creation: " + receivedPath + "/" + game + " failed. Exception occured.");
                    }
                }
            }

            tcpClient.Close(); //closes connection
        }

        public class State
        {
            public Socket Socket_w; //File Socket
            public const int bufferSize = 1638400; //1.5mb buffer
            public byte[] buffer = new byte[(bufferSize)]; //sets 1.5mb buffer
        }

        public static ManualResetEvent isDone = new ManualResetEvent(false); //reset thread event

        public static void startServer()
        {
            byte[] bytes = new byte[1024]; //sets a 1024kb buffer

            IPEndPoint endIP = new IPEndPoint(IPAddress.Any, setPort2); //gets ip + port

            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //starts file socket

            try
            {
                listenSocket.Bind(endIP); //starts file server
                listenSocket.Listen(100); //listens for connection

                while (true)
                {
                    isDone.Reset(); //resets "Operation Done" Event
                    listenSocket.BeginAccept(new AsyncCallback(Accept), listenSocket); //accepts connections.
                    isDone.WaitOne(); //waits for continue signal.
                }
            }

            catch (Exception ex)
            {
                conLog("Exception occurred: " + ex.ToString());
            }
        }

        static void Accept(IAsyncResult ar)
        {
            isDone.Set(); //sets signal

            Socket listenSocket = (Socket)ar.AsyncState; //gets state of Socket
            Socket handler = listenSocket.EndAccept(ar); //terminates accept and starts parsing data

            State newState = new State(); // initiates buffers
            newState.Socket_w = handler; //passes current socket to newState

            string getRemoteIP = handler.RemoteEndPoint.ToString();
            getRemoteIP = getRemoteIP.Substring(0, getRemoteIP.Length - 5); //gets connecting IP from Socket

            conLog("Connection accepted from IP: " + getRemoteIP);

            handler.BeginReceive(newState.buffer, 0, State.bufferSize, 0, new AsyncCallback(Read), newState); //initiates file storage
            flag = 0;
        }

        static void Read(IAsyncResult ar)
        {
       
        int fileNameLen = 1;
        getUsernameIndex = 0;
        getGameIndex = 0;

        State newState = (State)ar.AsyncState; //gets state of Socket
        Socket handler = newState.Socket_w; //passes Socket to handler

        int bytesRead = handler.EndReceive(ar); //terminates Data Receive from Socket.

        if (bytesRead > 0)
        {
            if (flag == 0)
            {
                fileNameLen = BitConverter.ToInt32(newState.buffer, 0); //gets filename length
                fileName = Encoding.UTF8.GetString(newState.buffer, 4, fileNameLen); //gets filename

                if (fileName.Contains(".txt"))
                {
                    getUsername = fileName;
                    getUsernameIndex = getUsername.IndexOf("_");
                    getUsername = getUsername.Substring(0, getUsernameIndex);

                    getGame = fileName;
                    getGame = getGame.Remove(0, getUsername.Length + 1);
                    getGameIndex = getGame.IndexOf("_");
                    getGame = getGame.Substring(0, getGameIndex);
                }

                else if (fileName.Contains(".jpeg"))
                {
                    getUsername = fileName;
                    getUsernameIndex = getUsername.IndexOf("_");
                    getUsername = getUsername.Substring(0, getUsernameIndex);

                    getGame = fileName;
                    getGame = getGame.Remove(0, getUsername.Length + 1);
                    getGameIndex = getGame.IndexOf("_");
                    getGame = getGame.Substring(0, getGameIndex);
                }
            flag++;
        }
            if (flag >= 1)
            {
                try
                {
                    BinaryWriter writer = new BinaryWriter(File.Open(receivedPath + "/" + getUsername + "/" + getGame + "/" + fileName, FileMode.Append)); //writes file to specified Path.
                   
                    if (flag == 1)
                    {
                        writer.Write(newState.buffer, 4 + fileNameLen, bytesRead - (4 + fileNameLen)); // if more File bytes exists
                        flag++; //increments flag.
                    }
                    else
                        writer.Write(newState.buffer, 0, bytesRead); //if complete.
                    writer.Close(); //closes File Write

                    handler.BeginReceive(newState.buffer, 0, State.bufferSize, 0,
                    new AsyncCallback(Read), newState); //waits for more files if exist.

                }
                catch (Exception) { conLog("Exception while writing to disk - filename: " + fileName); return; }
            }
           
        conLog("File saved: " + fileName);
    }
        }

        static void checkFolder(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                conLog("Folder created successfully - Folder name: " + dir);
            }

            else
            {
                conLog("Folder already exists - Folder name: " + dir);
            }
        }

        static void checkGameFolder(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                conLog("Folder created successfully - Folder name: " + dir);
            }

            else
            {
                conLog("Folder already exists - Folder name: " + dir);
            }
        }

        static void conLog(string contxt)
        {
            try
            {
                contxt.Trim();

                Console.WriteLine();
                Console.WriteLine(contxt);
                Console.WriteLine();

                StringBuilder sb = new StringBuilder();
                sb.Append(DateTime.Now + " - " + contxt + Environment.NewLine);

                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "/" + "log_" + launchTime + ".txt", sb.ToString() + Environment.NewLine);
            }

           catch (IOException) {
               Console.WriteLine();
               Console.WriteLine("Could not write to log file.");
               Console.WriteLine();
           }
        }
    }
}
