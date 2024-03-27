using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NetworkProgramming_HW_4.Client.Model.Message;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows.Documents;
using NetworkProgramming_HW_4.Client.Model;
using System.Drawing;

namespace NetworkProgramming_HW_4.Client.Control
{
    public class SenderClientC
    {
        private EndPoint? _endPoint;
        private EndPoint? _endPointUnic;
        private Socket? _senderUdp;
        private Socket? _unicastSocket;


        private Socket? _listenerUdp;
        private EndPoint? _listenerEndP;
        private IPAddress? _ip;

        private MessageModel? _messageModel;
        private UserOnline? _userOnline;
        private byte[]? _buffer;
        private int _sizeBuffer;
        private string? _jsonUser;

        public async void SendAsync(string msg)
        {
            await Task.Run(() => Send(msg));
        }
        private void Send(string msg)
        {

            byte[] arr = Encoding.Default.GetBytes(msg);
            _senderUdp.SendTo(arr, _endPoint);

        }
        public async void StartListenerAsync()
        {
            await Task.Run(Listener);

        }
        private void Listener()
        {

            try
            {
                _listenerUdp.Bind(_listenerEndP);
                while (true)
                {
                    _sizeBuffer = _listenerUdp.ReceiveFrom(_buffer, ref _listenerEndP);
                    if (_sizeBuffer > 0)
                    {
                       
                        if (Encoding.Default.GetString(_buffer, 0, _sizeBuffer).Split(",")[0].Equals("[\"User list\""))
                        {
                            UserOnline();
                        }
                        else { Application.Current.Dispatcher.Invoke(() => _messageModel.Message.Add(Encoding.Default.GetString(_buffer, 0, _sizeBuffer))); }
                        
                    }
                   
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Listener {ex.Message}");
            }
        }
        private void UserOnline()
        {
            var userOnline = new List<string>(); 
            userOnline= JsonSerializer.Deserialize<List<String>>(Encoding.Default.GetString(_buffer, 0, _sizeBuffer));

            for (int i = 1; i < userOnline.Count(); i++)
            {
                Application.Current.Dispatcher.Invoke(() => _userOnline.Users.Add(userOnline[i]));
            }
        }

            

        public async void sendmessageUnic(){

           await Task.Run(() => {
                _unicastSocket.Send(Encoding.Default.GetBytes("test"));
            });
        }
        public SenderClientC(MessageModel messageModel,UserOnline userOnline)
        {
            _buffer = new Byte[1024];
            _userOnline = userOnline;
            #region Unicast
            _endPointUnic = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            _unicastSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _unicastSocket.Connect(_endPointUnic);
            _messageModel = messageModel;
            #endregion

            #region for send message multicast
            _ip = IPAddress.Parse("235.0.0.0");
            _endPoint = new IPEndPoint(_ip, 11000);
            _senderUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _senderUdp.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
            _senderUdp.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(_ip));
            #endregion

            #region Listener Multicast
            _listenerEndP = new IPEndPoint(IPAddress.Any,11000);
            _listenerUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _listenerUdp.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
            _listenerUdp.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(_ip,IPAddress.Any));
            #endregion
        }
    }
}
