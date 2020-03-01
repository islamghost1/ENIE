using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ENIE_SERVER.ViewModel;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace ENIE_SERVER
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
<<<<<<< HEAD
        delegate void deleg();
        public static string clientMessage;
        public MainPage()
        {
            InitializeComponent();
            // BindingContext = new UDPReceiver(); 
           

        }
       
=======
      
        delegate void deleg();
        public MainPage()
        {
            InitializeComponent();
            // UDPSender.UDPSender_();
            // UDPReceiver.UDP_Receiver();
            // BindingContext = new UDPReceiver();
            //  ServerForm_Load();

            //===========================TCP=========================//
            TCPReceiver TCPobj = new TCPReceiver();
            deleg SocketReceiver =new deleg(TCPobj.TCPRTCPReceiver_);
            Thread thread = new Thread(new ThreadStart(SocketReceiver));
            thread.Start();
            //===========================TCP=========================//
            WriteOnLabel();

        }
        //public async void ServerForm_Load()
        //{
        //    int port = 27005;
        //    UdpClient udpListener = new UdpClient(port);
        //    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, port);
        //    while (true)
        //    {
        //        await Task.Delay(1000);
        //        byte[] receivedBytes = udpListener.Receive(ref ipEndPoint);      // Receive the information from the client as byte array
        //        MainPage.clientMessage = Encoding.UTF8.GetString(receivedBytes);   // Convert the message to a string

        //        byte[] response = Encoding.UTF8.GetBytes("Hello client, this is the server");   // Convert the reponse we want to send to the client to byte array
        //        udpListener.Send(response, response.Length, ipEndPoint);                        // Send the data to the client
        //        Debug.WriteLine(MainPage.clientMessage);
        //    }
        //}
>>>>>>> 3d64a4b... tcp logic changes
        private async void WriteOnLabel()
        {
            
           while(true)
            {
                await Task.Delay(1000);
                string data = TCPReceiver.clientMessage;
                Receive.Text = data;
            }
        }

        private void Connect(object sender, EventArgs e)
        {
            WriteOnLabel();
            TCPReceiver TCPObj = new TCPReceiver();
            deleg SocketSender = new deleg(TCPObj.TCPReceiver_);
            Thread thread = new Thread(new ThreadStart(SocketSender));
            thread.Start();
        }
    }
}
