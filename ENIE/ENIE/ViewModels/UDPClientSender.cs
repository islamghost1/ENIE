using Sockets.Plugin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;



namespace ENIE.ViewModels
{
   public class UDPClientSender
    {
       
        public static  string SendMessageToServer(string message, IPEndPoint serverAddress)
        {
            
            string serverResponse = string.Empty;       // The variable which we will use to store the server response
          
            using (UdpClient client = new UdpClient())
            {
                byte[] data = Encoding.UTF8.GetBytes(message);      // Convert our message to a byte array
                client.Send(data, data.Length, serverAddress);      // Send the date to the server

                serverResponse = Encoding.UTF8.GetString(client.Receive(ref serverAddress));    // Retrieve the response from server as byte array and convert it to string
            }
                return serverResponse;
        }

        public  async void CallSendmessageToServer()
        {
<<<<<<< Updated upstream
            IPAddress serverIP = IPAddress.Parse("192.168.1.49");     // Server IP 105.235.139.18 192.168.1.49
=======
            IPAddress serverIP = IPAddress.Parse("192.168.171");     // Server IP 105.235.139.18 192.168.1.49
>>>>>>> Stashed changes
            int port = 27005;                                           // Server port
         
                for (int i =0; i<1000; i++) { 
                    await Task.Delay(1000);
                    IPEndPoint ipEndPoint = new IPEndPoint(serverIP, port);

                    string response = UDPClientSender.SendMessageToServer($"hello server{i} , this is the client", ipEndPoint);      // Send the message to the server
                    Debug.WriteLine(response); // Output the result
                }
            
        }
    }
   
        //public static async void UDP_ClientSender()
       // {
            //var port = 11811;
            //var address = "192.168.1.32";
            //for (int i = 0; i < 1000; i++)
            //{

            //    var client = new UdpSocketClient();

            //    // convert our greeting message into a byte array

            //    var msg = $"{i}";
            //    var msgBytes = Encoding.UTF8.GetBytes(msg);

            //    // send to address:port, 
            //    // no guarantee that anyone is there 
            //    // or that the message is delivered.
            //    await Task.Delay(1000);
            //    await client.SendToAsync(msgBytes, address, port);

            //}


            //var port = 11811;
            //var address = "192.168.1.32"; // must be a valid multicast address
            //for (int i = 0; i < 1000; i++)
            //{
            //    // typical instantiation
            //    var receiver = new UdpSocketMulticastClient();
            //    receiver.TTL = 5;

            //    receiver.MessageReceived += (sender, args) =>
            //    {
            //        var from = String.Format("{0}:{1}", args.RemoteAddress, args.RemotePort);
            //        var data = Encoding.UTF8.GetString(args.ByteData, 0, args.ByteData.Length);

            //        Debug.WriteLine("{0} - {1}", from, data);
            //    };

            //    // join the multicast address:port
            //    await receiver.JoinMulticastGroupAsync(address, port);

            //    var msg = $"smoaykom {i}";
            //    var msgBytes = Encoding.UTF8.GetBytes(msg);

            //    // send a message that will be received by all listening in
            //    // the same multicast group. 
            //    await receiver.SendMulticastAsync(msgBytes);
            //}

           
       //  }
    
}
