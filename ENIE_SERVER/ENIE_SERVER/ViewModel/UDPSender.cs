using Sockets.Plugin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;


namespace ENIE_SERVER.ViewModel
{
    public class UDPSender
    {
        public static async void UDPSender_()
        {
            var port = 11811;
            var address = "192.168.1.178";
            for (int i = 0; i < 1000; i++)
            {

                var client = new UdpSocketClient();

                // convert our greeting message into a byte array

                var msg = $"{i}";
                var msgBytes = Encoding.UTF8.GetBytes(msg);

                // send to address:port, 
                // no guarantee that anyone is there 
                // or that the message is delivered.
                await Task.Delay(1000);
                await client.SendToAsync(msgBytes, address, port);

            }
        }
    }
}
