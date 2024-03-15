using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Navigation;
using NetworkProgramming_HW_1.Model.ClientServerModel;

namespace NetworkProgramming_HW_1.Control.ClientServerControl
{
    internal class ClientControl
    {
        private Socket? _clientSocket;
        private IPAddress? _ipAdressServer;
        private int _portServer;
        private IPEndPoint? _ipEndPointServer;
        private MessageUserModel? _userMessage;

        private string? _serverMessage;
        private byte[] _bufferBytes;
        private int _sizeMessge;

        public async void ConnectServerAsync()
        {

            Task.Run(Connect);

        }
        private void Connect()
        {
            try
            {
                _clientSocket.Connect(_ipEndPointServer);
                byte[] msg = Encoding.Default.GetBytes(Dns.GetHostName());
                _clientSocket.Send(msg);
                _sizeMessge = _clientSocket.Receive(_bufferBytes);
                _serverMessage = Encoding.Default.GetString(_bufferBytes, 0, _sizeMessge);
                Application.Current.Dispatcher.Invoke(() => _userMessage.UserMsg.Add(_serverMessage));
            }
            catch (SocketException ex)
            {
                Application.Current.Dispatcher.Invoke(() => _userMessage.UserMsg.Add($"{ex.Message}"));
            }


        }
        private async void GetServerMessageAsync()
        {
            await Task.Run(() =>
            {
                _sizeMessge = _clientSocket.Receive(_bufferBytes);
                _serverMessage = Encoding.Default.GetString(_bufferBytes, 0, _sizeMessge);
                Application.Current.Dispatcher.Invoke(() => _userMessage.UserMsg.Add(_serverMessage));
            });
        }
        public void SendMessage(string msg)
        {
            _clientSocket.Send(Encoding.Default.GetBytes(msg));
            GetServerMessageAsync();

        }

        public ClientControl(MessageUserModel messageUserModel)
        {
            _userMessage = messageUserModel;
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ipAdressServer = IPAddress.Parse("127.0.0.1");
            _portServer = 49000;
            _ipEndPointServer = new IPEndPoint(_ipAdressServer, _portServer);
            _bufferBytes = new byte[1024];
        }
    }
}
