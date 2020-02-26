using Sockets.Plugin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ENIE_SERVER.ViewModel
{
    public class UDPReceiver
    {
        
        //public static string data;
        //public static async void  UDP_Receiver()
        //{
        //    var listenPort = 11811;
        //    var receiver = new UdpSocketReceiver();

        //    receiver.MessageReceived += (sender, args) =>
        //    {
        //        // get the remote endpoint details and convert the received data into a string
        //        var from = String.Format("{0}:{1}", args.RemoteAddress, args.RemotePort);
        //        UDPReceiver.data = Encoding.UTF8.GetString(args.ByteData, 0, args.ByteData.Length);

        //        Debug.WriteLine("{0} - {1}", from, data);
        //    };

        //    // listen for udp traffic on listenPort
        //    await receiver.StartListeningAsync(listenPort);


        //}

        //private void ServerForm_Load(object sender, EventArgs e)
        //{
        //    int port = 27005;
        //    UdpClient udpListener = new UdpClient(port);
        //    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, port);

        //    byte[] receivedBytes = udpListener.Receive(ref ipEndPoint);      // Receive the information from the client as byte array
        //     UDPReceiver.clientMessage = Encoding.UTF8.GetString(receivedBytes);   // Convert the message to a string

        //    byte[] response = Encoding.UTF8.GetBytes("Hello client, this is the server");   // Convert the reponse we want to send to the client to byte array
        //    udpListener.Send(response, response.Length, ipEndPoint);                        // Send the data to the client
        //}

    }
    
}
