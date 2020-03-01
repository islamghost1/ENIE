using Sockets.Plugin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ENIE.ViewModels
{
    class TCPCLientSender
    {
        public async void TCPCleintSender_()
        {
            byte[] bytes = new byte[1024];

            try
            {
                // Connect to a Remote server  
                // Get Host IP Address that is used to establish a connection  
                // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
                // If a host has multiple addresses, you will get a list of addresses  
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.    
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                int attempts = 0;

                while (!sender.Connected)
                {
                    try
                    {
                        await Task.Delay(1000);
                        attempts++; 
                        Console.WriteLine("Connection attempt " + attempts);
                        Console.WriteLine("ipAddress " + ipAddress);
                        // Change IPAddress.Loopback to a remote IP to connect to a remote host.
                        sender.Connect(remoteEP);

                        Console.WriteLine("Socket connected to {0}",
                            sender.RemoteEndPoint.ToString());
                    }
                    catch (SocketException)
                    {

                    }
                }


                Console.WriteLine("Connected");
                // Connect the socket to the remote endpoint. Catch any errors.    
                int i = 0;
                while (true)
                {
                    int counter = 0; 
                    try
                    {
                        counter++;
                        // Connect to Remote EndPoint  

                        // Encode the data string into a byte array.    
                        byte[] msg = Encoding.ASCII.GetBytes($"socket: {counter} ");

                        Console.WriteLine($"{msg}");

                        // Send the data through the socket.    
                        int bytesSent = sender.Send(msg);


                        // Receive the response from the remote device.    
                        int bytesRec = sender.Receive(bytes);
                        // Console.WriteLine("Echoed test = {0}",
                        //   Encoding.ASCII.GetString(bytes, 0, bytesRec));

                        // Release the socket.    
                        i++;


                    }
                    catch (ArgumentNullException ane)
                    {
                        Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();
                        Console.WriteLine("\n SERVER STOPED");
                    }
                    catch (SocketException se)
                    {
                        Console.WriteLine("SocketException : {0}", se.ToString());
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();
                        Console.WriteLine("\n SERVER STOPED");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Unexpected exception : {0}", e.ToString());
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();
                        Console.WriteLine("\n SERVER STOPED");
                    }

                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
    
}
