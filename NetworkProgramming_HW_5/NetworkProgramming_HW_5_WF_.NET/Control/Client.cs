using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using NetworkProgramming_HW_5_WF_.NET.Model;

namespace NetworkProgramming_HW_5_WF_.NET.Control
{
    internal class Client
    {

        private ScreanServer _screanServer;
        private Socket _clientSocket;
        private IPAddress _ipAdressServer;
        private int _portServer;
        private IPEndPoint _ipEndPointServer;
        private byte[] _bufferBytes;
        private int _sizeMessge;

        public async void ConnectServerAsync()
        {

            await Task.Run(Connect);
            startMessage();
        }
        private void Connect()
        {
            try
            {
                _clientSocket.Connect(_ipEndPointServer);
            }
            catch (SocketException ex)
            {
                
            }
        }
        public  void startMessage()
        {
            System.Timers.Timer timer = new System.Timers.Timer(5000);
            timer.Elapsed += async (sender, e) => await SendMessage();
            timer.Start();
            
        }
        private   async Task SendMessage()
        {
           await  Task.Run(()=> _clientSocket.Send(_screanServer.Screan()));
        }

        public Client()
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ipAdressServer = IPAddress.Parse("127.0.0.1");
            _portServer = 49000;
            _ipEndPointServer = new IPEndPoint(_ipAdressServer, _portServer);
            _bufferBytes = new byte[1024];
            _screanServer = new ScreanServer();
        }
    }
}
