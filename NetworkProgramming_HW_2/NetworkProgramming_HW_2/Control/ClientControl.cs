using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NetworkProgramming_HW_2.Model;

namespace NetworkProgramming_HW_2.Control
{
    class ClientControl
    {
        private Socket? _clientSocket;
        private IPAddress? _ipAdressServer;
        private ClientModel? _clientModel;
        private IPEndPoint? _ipEndPointServer;
       
        private int _portServer;
        private string? _serverMessage;
        private byte[] _bufferBytes;
        private int _sizeMessge;

        public async void ConnectServerAsync()
        {

           await Task.Run(Connect);

        }
        private void Connect()
        {
            try
            {
                _clientSocket.Connect(_ipEndPointServer);
                _clientSocket.Send(About());
                GetServerMessageAsync();
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Client" +ex.Message);
            }
        }

        private async void GetServerMessageAsync()
        {
            await Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        _sizeMessge = _clientSocket.Receive(_bufferBytes);
                        if (_sizeMessge <= 0)
                        {
                            _clientSocket.Shutdown(SocketShutdown.Both);
                            _clientSocket.Close();
                            return;
                        }
                        _serverMessage = Encoding.Default.GetString(_bufferBytes, 0, _sizeMessge);
                        Application.Current.Dispatcher.Invoke(() => _clientModel.ClientMsg.Add(_serverMessage));
                    }
                }
                catch (Exception ex)
                {

                    Application.Current.Dispatcher.Invoke(() => _clientModel.ClientMsg.Add(ex.Message));
                }
               
            });
        }
        public void SendMessage(string msg)
        {
            _clientSocket.Send(Encoding.Default.GetBytes(msg));
        }


        private byte[] About()
        {
            byte[] aboutClient = Encoding.Default.GetBytes($"Name client : {Environment.UserName}, time connect : {DateTime.Now}");
            return aboutClient;
        }
        public ClientControl(ClientModel clientModel)
        {
            _clientModel = clientModel;
            _clientSocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            _ipAdressServer = IPAddress.Parse("0:0:0:0:0:0:0:1");//Запись ipv6 сответствует 127.0.0.1 ipv4
            _portServer = 49000;
            _ipEndPointServer = new IPEndPoint(_ipAdressServer, _portServer);
            _bufferBytes = new byte[1024];
        }
    }
}
