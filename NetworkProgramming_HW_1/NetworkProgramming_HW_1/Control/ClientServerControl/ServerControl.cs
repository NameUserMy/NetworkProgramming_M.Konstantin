using NetworkProgramming_HW_1.Model.ClientServerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace NetworkProgramming_HW_1.Control.ClientServerControl
{
    internal class ServerControl
    {
        private IPEndPoint? _endPointServer;

        private Socket? _listener;
        private Socket? _handlerClient;
        private ServerMesageModel? _serverMessage;
        private string? infoAboutClient;
        private string? _clientMessage;
        private byte[] _bufferBytes;
        private int _sizeMessge;

        public async void StartServerAsync()
        {
            await Task.Run(StartListen);
            Task.Run(ConnectToClient);
        }
        private void StartListen()
        {
            try
            {
                _listener?.Bind(_endPointServer);
                _listener?.Listen(5);
                Application.Current.Dispatcher.Invoke(() => _serverMessage.ServerMsg.Add("Server is start... " + DateTime.Now));
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() => _serverMessage.ServerMsg.Add(ex.Message + " " + DateTime.Now));
            }
        }
        private void ConnectToClient()
        {
            while (true)
            {
                _handlerClient = _listener.Accept();
                Task.Run(() => ClientMessage(_handlerClient));
            }
        }
        private void ClientMessage(Socket handlerClient)
        {
            handlerClient.Send(Encoding.Default.GetBytes("Connection established"));
            _sizeMessge = handlerClient.Receive(_bufferBytes);
            infoAboutClient = Encoding.Default.GetString(_bufferBytes, 0, _sizeMessge);
            Application.Current.Dispatcher.Invoke(() => _serverMessage.ServerMsg.Add(infoAboutClient + " Is connecting " + DateTime.Now));
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
                if (_clientMessage.Equals("Hi"))
                {
                    DateTime time = DateTime.Now;
                    if (time.Hour < 11)
                    {

                        handlerClient.Send(Encoding.Default.GetBytes("Good morning"));

                    }
                    else { handlerClient.Send(Encoding.Default.GetBytes("Hello!")); }

                }
                else if (_clientMessage.Equals("Time"))
                {
                    handlerClient.Send(Encoding.Default.GetBytes(DateTime.Now.ToString()));
                }
                Application.Current.Dispatcher.Invoke(() => _serverMessage.ServerMsg.Add($"{infoAboutClient} send msg {_clientMessage}"));
            }

        }
        public ServerControl(ServerMesageModel serverModel)
        {
            _serverMessage = serverModel;
            _endPointServer = new IPEndPoint(IPAddress.Any, 49000);//End point сервера прослушиваем все Ip на порту 49000
            _listener = new Socket(AddressFamily.InterNetwork/*ipv4*/, SocketType.Stream, ProtocolType.Tcp);
            _bufferBytes = new byte[1024];
        }
    }
}
