using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = args[0];
            if (type == "-c")
            {
                Send(args);
            }
            else if (type == "-s")
            {
               Recv(args);
            }
        }

        private static void Send(string[] args)
        {
            var host = args[1];
            var port = int.Parse(args[2]);
            TcpClient tcpClient = null;
            try
            {
                tcpClient = new TcpClient();
                Console.WriteLine("connecting to {0}:{1}", host, port);
                tcpClient.Connect(host, port);
                Console.WriteLine("connected to {0}:{1}", host, port);
                using (var networkStream = tcpClient.GetStream())
                {
                    string line = null;
                    while ((line = Console.ReadLine()) != null)
                    {
                        if (line == "exit" || line == "quit")
                        {
                            break;
                        }
                        else if (line.StartsWith("upload"))
                        {
                            var filePath = line.Substring(7);
                            using (FileStream stream = new FileStream(filePath, FileMode.Open))
                            {
                                stream.CopyTo(networkStream);
                            }
                        }
                        else
                        {
                            var bytes = Encoding.Unicode.GetBytes(line + "\n");
                            networkStream.WriteAsync(bytes, 0, bytes.Length).Wait();
                            Console.WriteLine("send: " + line);
                        }
                    }
                }
            }
            finally
            {
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }
            }
        }

        private static void Recv(string[] args)
        {
            TcpListener tcpListener = null;
            try
            {
                var port = int.Parse(args[1]);
                string address = "127.0.0.1";
                IPAddress ipAddress = IPAddress.Parse(address);
                tcpListener = new TcpListener(ipAddress, port);
                Console.WriteLine("listening from {0}:{1}", address, port);
                tcpListener.Start();
                Console.WriteLine("listenned from {0}:{1}", address, port);
                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(RecvMsg, tcpClient);
                }
            }
            finally
            {
                if (tcpListener != null)
                {
                    tcpListener.Stop();
                }
            }
        }

        private static void RecvMsg(object o)
        {
            TcpClient tcpClient = o as TcpClient;
            try
            {
                using (var networkStream = tcpClient.GetStream())
                {
                    Console.WriteLine("connected from {0}", tcpClient.Client.RemoteEndPoint.ToString());
                    byte[] bytes = new byte[256];
                    int i;
                    while ((i = networkStream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var content = Encoding.Unicode.GetString(bytes, 0, i);
                        Console.Write("recv: " + content);
                    }
                }
            }
            finally
            {
                tcpClient.Close();
            }
        }
    }
}