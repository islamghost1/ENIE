using Sockets.Plugin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ENIE_SERVER.ViewModel
{
    public class UDPReceiver
    {
        public async void  UDP_Receiver()
        {
            var listenPort = 11011;
            var receiver = new UdpSocketReceiver();

            receiver.MessageReceived += (sender, args) =>
            {
                // get the remote endpoint details and convert the received data into a string
                var from = String.Format("{0}:{1}", args.RemoteAddress, args.RemotePort);
                var data = Encoding.UTF8.GetString(args.ByteData, 0, args.ByteData.Length);

                Debug.WriteLine("{0} - {1}", from, data);
            };

            // listen for udp traffic on listenPort
            await receiver.StartListeningAsync(listenPort);
        }
    }
}
