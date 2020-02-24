using Sockets.Plugin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ENIE.ViewModels
{
   public class UDPClientSender
    {
        public static async void UDP_ClientSender()
        {
            //var port = 58638;
            //var address = "192.168.1.32";
            //for(int i=0;i<1000; i++) { 

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
            var port = 11811;
            var address = "105.235.139.50"; // must be a valid multicast address
            for (int i = 0; i < 1000; i++)
            {
                    // typical instantiation
                    var receiver = new UdpSocketMulticastClient();
                receiver.TTL = 5;

                receiver.MessageReceived += (sender, args) =>
                {
                    var from = String.Format("{0}:{1}", args.RemoteAddress, args.RemotePort);
                    var data = Encoding.UTF8.GetString(args.ByteData, 0, args.ByteData.Length);

                    Debug.WriteLine("{0} - {1}", from, data);
                };

                // join the multicast address:port
                await receiver.JoinMulticastGroupAsync(address, port);

                var msg = $"smoaykom {i}";
                var msgBytes = Encoding.UTF8.GetBytes(msg);

                // send a message that will be received by all listening in
                // the same multicast group. 
                await receiver.SendMulticastAsync(msgBytes);
            }
        }
    }
}
