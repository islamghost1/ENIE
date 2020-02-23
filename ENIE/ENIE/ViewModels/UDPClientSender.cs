using Sockets.Plugin;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENIE.ViewModels
{
   public class UDPClientSender
    {
        public async void UDP_ClientSender()
        { 
            var port = 11011;
            var address = "127.0.0.1";

            var client = new UdpSocketClient();

            // convert our greeting message into a byte array
            var msg = "HELLO WORLD";
            var msgBytes = Encoding.UTF8.GetBytes(msg);

            // send to address:port, 
            // no guarantee that anyone is there 
            // or that the message is delivered.
            await client.SendToAsync(msgBytes, address, port);
        }
    }
}
