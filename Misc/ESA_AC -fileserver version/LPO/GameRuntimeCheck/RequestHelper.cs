using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using LPO.Global;
using System.Net;
using LPO.GameRuntimeCheck;

namespace ESA_AC.GameRuntimeCheck
{
    class RequestHelper
    {
        internal static void requestFolder(string host, string cmd, string user)
        {
                TcpClient client = new TcpClient();

                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(host), 8888);

                client.Connect(serverEndPoint);

                NetworkStream clientStream = client.GetStream();

                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(cmd + user);

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();

                client.GetStream().Close();
                client.Close();
        }

        internal static void uploadFile(string host, string username, string getGame, string filename, string filepath)
        {
                byte[] m_clientData;
                Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] fileName = Encoding.UTF8.GetBytes(username + "_" + getGame + "_" + filename);
                byte[] fileData = File.ReadAllBytes(filepath);
                byte[] fileNameLen = BitConverter.GetBytes(fileName.Length);

                m_clientData = new byte[4 + fileName.Length + fileData.Length];

                fileNameLen.CopyTo(m_clientData, 0);
                fileName.CopyTo(m_clientData, 4);
                fileData.CopyTo(m_clientData, 4 + fileName.Length);

                clientSock.Connect(host, 8889);
                clientSock.Send(m_clientData); //tofix exception
                clientSock.Close();

                File.Delete(filepath);
        }

    }
}
