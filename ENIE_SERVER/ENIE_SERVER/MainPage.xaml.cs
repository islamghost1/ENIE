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
        delegate void deleg();
        public static string clientMessage;
        public MainPage()
        {
            InitializeComponent();
            // BindingContext = new UDPReceiver(); 
           

        }
       
        private async void WriteOnLabel()
        {
            
           while(true)
            {
                await Task.Delay(1000);
                string data = MainPage.clientMessage;
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
