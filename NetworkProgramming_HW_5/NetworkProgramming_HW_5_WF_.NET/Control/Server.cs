using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;

namespace NetworkProgramming_HW_5_WF_.NET.Control
{
    internal class Server
    {
        private IPEndPoint _endPointServer;

        private Socket _listener;
        private Socket _handlerClient;
        
        private string infoAboutClient;
        private string _clientMessage;
        private byte[] _bufferBytes;
        private int _sizeMessge;

        public async void StartServerAsync()
        {
            await Task.Run(StartListen);
            await Task.Run(ConnectToClient);
        }
        private void StartListen()
        {
            try
            {
                _listener?.Bind(_endPointServer);
                _listener?.Listen(5);
                
            }
            catch (Exception ex)
            {
                
            }
        }
        private async void ConnectToClient()
        {
            while (true)
            {
                _handlerClient = _listener.Accept();
                await Task.Run(() => ClientMessage(_handlerClient));
            }
        }
        private void ClientMessage(Socket handlerClient)
        {
            while (true)
            {
                _sizeMessge = handlerClient.Receive(_bufferBytes);
                if (_sizeMessge == 0)
                {
                    handlerClient.Shutdown(SocketShutdown.Both);
                    handlerClient.Close();
                    return;
                }
                _clientMessage = Encoding.Default.GetString(_bufferBytes, 0, _sizeMessge);

                MessageBox.Show("kljl");
                FileStream fs = new FileStream("copy/1.jpg", FileMode.OpenOrCreate, FileAccess.ReadWrite);

                BinaryWriter writer = new BinaryWriter(fs);
                writer.Write(_bufferBytes);
                writer.Close();
            }
        }
        public Server()
        {
            
            _endPointServer = new IPEndPoint(IPAddress.Any, 49000);
            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _bufferBytes = new byte[0x0001013f];
        }
    }
}

