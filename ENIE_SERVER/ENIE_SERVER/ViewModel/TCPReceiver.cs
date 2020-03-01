using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ENIE_SERVER.ViewModel
{
    class TCPReceiver
    {
        public  void TCPReceiver_()
        {
            // Get Host IP Address that is used to establish a connection
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
            // If a host has multiple addresses, you will get a list of addresses  
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            //


            try
            {

                // Create a Socket that will use Tcp protocol      
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // A Socket must be associated with an endpoint using the Bind method  
                listener.Bind(localEndPoint);
                // Specify how many requests a Socket can listen before it gives Server busy response.  
                // We will listen 10 requests at a time  
                listener.Listen(10);

                Console.WriteLine("Waiting for a connection...");
                Console.WriteLine($"{ipAddress}");
                Socket handler = listener.Accept();

                // Incoming data from the client.    
                string data = null;
                byte[] bytes = null;
                int x = 0;
                while (x == 0)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("socket") > -1)
                    {
                        Console.WriteLine("Text received : {0}", data);

                        byte[] msg = Encoding.ASCII.GetBytes(data);
                        handler.Send(msg);
                        Thread.Sleep(100);
                        MainPage.clientMessage = data;
                        data = "";


                    }
                    if (data.IndexOf("Bocket") > -1)
                    {
                        Console.WriteLine("Text received : {0}", data);

                        byte[] msg = Encoding.ASCII.GetBytes(data);
                        handler.Send(msg);
                        Thread.Sleep(500);
                        data = "";


                    }
                }
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                /* handler.Shutdown(SocketShutdown.Both);
                                       handler.Close();
                                Console.WriteLine("Text received : {0}", data);

                                byte[] msg = Encoding.ASCII.GetBytes(data);
                                handler.Send(msg);
                                handler.Shutdown(SocketShutdown.Both);
                                handler.Close();*/
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\n SERVER STOPED");

            //  Console.ReadKey();
        }
    }
    
=======
using System.Diagnostics;
using Sockets.Plugin;

namespace ENIE_SERVER.ViewModel
{
    public class TCPReceiver
    {
        public static string clientMessage;
        public async void TCPRTCPReceiver_()
        {
            var listenPort = 11000;
            var listener = new TcpSocketListener();

            // when we get connections, read byte-by-byte from the socket's read stream
            listener.ConnectionReceived += async (sender, args) =>
            {
                var client = args.SocketClient;

                var bytesRead = -1;
                var buf = new byte[1];

                while (bytesRead != 0)
                {
                    bytesRead = await args.SocketClient.ReadStream.ReadAsync(buf, 0, 1);
                    if (bytesRead > 0)
                        TCPReceiver.clientMessage = buf[0].ToString();
                        Debug.Write(TCPReceiver.clientMessage);
                }
            };

            // bind to the listen port across all interfaces
            await listener.StartListeningAsync(listenPort);
        }
    }
>>>>>>> 3d64a4b... tcp logic changes
}
