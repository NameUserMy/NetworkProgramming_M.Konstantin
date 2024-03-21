using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using NetworkProgramming_HW_3.Model.UdpModel;

namespace NetworkProgramming_HW_3.Control.UdpControl
{
    class ClientControlUdp
    {
        private IPEndPoint? _ipEndPoint;
        private Socket? _clientSocket;
        private ClientModel? _model;
     
        private int _porServer;
        private byte[]? _buffer;

        public async void SendMessageAsync()
        {
            await Task.Run(Send);
        }
        private void  Send()
        {
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
           
             byte[] arr = Encoding.Default.GetBytes(_model.SendMessage); 
            _clientSocket.SendTo(arr, _ipEndPoint);
            _clientSocket.Shutdown(SocketShutdown.Send); 
            _clientSocket.Close(); 

        }


        public ClientControlUdp(ClientModel clientModel)
        {
            _model = clientModel;
            _porServer = 2020;
            _buffer = new byte[1024];
            _ipEndPoint = new IPEndPoint(IPAddress.Broadcast, _porServer);
        }
    }
}
