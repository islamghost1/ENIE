using System;
using System.Net.Sockets;
using System.Text;
namespace ENIE_CONSOLE_SERVER
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new UdpListener();
            listener.StartListening();
            Console.ReadLine();
        }
    }
    class UdpListener
    {
        private readonly UdpClient _udpClient = new UdpClient(15000);

        public async void StartListening()
        {
            while (true)
            {
                var result = await _udpClient.ReceiveAsync();
                var message = Encoding.ASCII.GetString(result.Buffer);
                Console.WriteLine(message);
            }
        }
    }
}
