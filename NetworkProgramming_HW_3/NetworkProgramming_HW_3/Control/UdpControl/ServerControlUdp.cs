using NetworkProgramming_HW_3.Model.UdpModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkProgramming_HW_3.Control.UdpControl
{
    class ServerControlUdp
    {
        private IPEndPoint? _ipEndPoint;
        private Socket? _serverSocket;
        EndPoint? _remotePoint;
        private ServerModel _model;

        private int _porServer;
        private byte[]? _buffer;



        public async void StartListenerAsync()
        {
            Application.Current.Dispatcher.Invoke(() => _model.GetMessage.Add("Start listener ..."));
            await Task.Run(Listener);

        }
        private void Listener()
        {
            try
            {
                while (true)
                {
                    _serverSocket.ReceiveFrom(_buffer, ref _remotePoint);
                    Application.Current.Dispatcher.Invoke(() => _model.GetMessage.Add($"Ip {((IPEndPoint)_remotePoint).Address} send " +
                        $"{Encoding.Default.GetString(_buffer, 0, _buffer.Length)}"));
                }
            }
            catch (Exception ex)
            {

                Application.Current.Dispatcher.Invoke(() => _model.GetMessage.Add(ex.Message));
            }
           
        }
        public ServerControlUdp(ServerModel serverModel)
        {
            _model = serverModel;
            _porServer = 2020;
            _buffer = new byte[1024];
            _remotePoint = new IPEndPoint(0, 0);
            _ipEndPoint = new IPEndPoint(IPAddress.Any, _porServer);
            _serverSocket = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
            _serverSocket.Bind(_ipEndPoint);
        }
    }
}
