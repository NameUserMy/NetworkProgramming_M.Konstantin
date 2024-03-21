using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NetworkProgramming_HW_3.Model.TcpModel;
using System.Windows;
using System.Text.Json;

namespace NetworkProgramming_HW_3.Control.TcpChat
{
    internal class ClientControl
    {

        private Socket? _clientSocket;
        private IPAddress? _ipAdressServer;
        private int _portServer;
        private IPEndPoint? _ipEndPointServer;
        private HistoryMsgmodel? _historyM;
       
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
                GetServerMessageAsync();

            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
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
                        if (_sizeMessge != 0)
                        {
                            _serverMessage = Encoding.Default.GetString(_bufferBytes, 0, _sizeMessge);
                            Application.Current.Dispatcher.Invoke(() => _historyM.MsgHistory.Add($"{_serverMessage}"));
                        }
                       

                    }
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   
                }
                
                
            });
        }
        public void SendMessage(string msg)
        {
            try
            {
                _clientSocket.Send(Encoding.Default.GetBytes(msg, 0, msg.Length));
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
        public ClientControl(HistoryMsgmodel historyMsgmodel)
        {
            _historyM = historyMsgmodel;
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _ipAdressServer = IPAddress.Parse("127.0.0.1");
            _portServer = 49001;
            _ipEndPointServer = new IPEndPoint(_ipAdressServer, _portServer);
            _bufferBytes = new byte[1024];
            
        }
    }



}

