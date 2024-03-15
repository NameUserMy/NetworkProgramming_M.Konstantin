using NetworkProgramming_HW_1.Model.TaskManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkProgramming_HW_1.Control.TaskManagerControl
{
    internal class ManagerClientControl
    {
        
        private TcpClient? _client;
        private IPEndPoint? _ipEndPoint;
        private NetworkStream? _serverStream;
        private ClientMessageModel? _clientModel;
        private int _sizeMessage;
        private byte[]? _bufferMessage;
        private string? _userMessage;
        public async void StartConnectAsync()
        {
           await Task.Run(ConnectToServer);
        }
        private void ConnectToServer()
        {
            try
            {
                _client.Connect(_ipEndPoint);
                _serverStream = _client.GetStream();
                _serverStream.Write(Encoding.Default.GetBytes(_userMessage), 0, Encoding.Default.GetBytes(_userMessage).Length);
                GetServerMessageAsync();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Client   " +ex.Message);
            }
 
        }
        private async void GetServerMessageAsync()
        {
            _sizeMessage = _serverStream.Read(_bufferMessage = new byte[_client.ReceiveBufferSize], 0, _client.ReceiveBufferSize);
            var processList = new List<string>();
            await Task.Run(() => {
                processList = JsonSerializer.Deserialize<List<string>>(Encoding.Default.GetString(_bufferMessage, 0, _sizeMessage));
                foreach (var item in processList)
                {
                    Application.Current.Dispatcher.Invoke(() => _clientModel.ClientMsg.Add(item));
                }
            }); 
        }
        public  async void SendMessage(string mesg)
        {
            await _serverStream.WriteAsync(Encoding.Default.GetBytes(mesg), 0, Encoding.Default.GetBytes(mesg).Length);
        }
        
        public ManagerClientControl(ClientMessageModel clientModel)
        {
            _clientModel = clientModel;
            _client = new TcpClient();
            _ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 49000);
            _userMessage = $" User name {Environment.UserName} User domian {Environment.UserDomainName}";

        }
    }
}
