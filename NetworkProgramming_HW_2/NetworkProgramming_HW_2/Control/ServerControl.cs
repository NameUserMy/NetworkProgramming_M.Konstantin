using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NetworkProgramming_HW_2.Model;
using NetworkProgramming_HW_2.GeneratorCetation;
using System.Windows.Interop;

namespace NetworkProgramming_HW_2.Control
{
    class ServerControl
    {
        private IPEndPoint? _endPointServer;
        private Socket? _listener;
        private Socket? _handlerClient;
        private ServerModel? _serverModel;
        private CetationGenerator _cetation;
        private string? _clientMessage;
        private byte[]? _bufferBytes;
        private int _sizeBuffer;
        private int _maxCitation;
        private int _countCitation;

        CancellationTokenSource cancelTokenSource;
        CancellationToken token;
        
        public async void StartServerAsync()
        {
            await Task.Run(SetListener);
            Task.Run(IsConnectClient);
        }
        private void SetListener()
        {
            try
            {
                _listener?.Bind(_endPointServer);
                _listener?.Listen(5);
                Application.Current.Dispatcher.Invoke(() => _serverModel.ServerMsg.Add("Server is start..."));
            }
            catch (SocketException ms)
            {

                Application.Current.Dispatcher.Invoke(() => _serverModel.ServerMsg.Add("Listener   "+ms.Message));
            }
            
        }
        private void IsConnectClient()
        {
            while (true)
            {
                _handlerClient = _listener.Accept();
                SendMsg("Connection successful");
                Task.Run(() => MesgProcessing(_handlerClient));
            }

        }


        private void MesgProcessing(Socket clien)
        {
            try
            {
                GetClientInfo();
               
                while (true)
                {
                    _sizeBuffer = clien.Receive(_bufferBytes);
                    if (_sizeBuffer <=0)
                    {
                        clien.Shutdown(SocketShutdown.Both);
                        clien.Close();
                        return;
                    }
                    _clientMessage = Encoding.Default.GetString(_bufferBytes,0,_sizeBuffer);
                    Application.Current.Dispatcher.Invoke(() =>_serverModel.ServerMsg.Add(_clientMessage));
                    if (_clientMessage == "Get")
                    {
                       
                       SendCitations();
                    }
                    else if(_clientMessage == "Stop")
                    {
                        MessageBox.Show($"{_countCitation}");
                        cancelTokenSource.Cancel();
                        cancelTokenSource.Dispose();
                        Application.Current.Dispatcher.Invoke(() => _serverModel.ServerMsg.Add(DateTime.Now.ToString()));
                    }
                }
            }
            catch (SocketException ms)
            {

                Application.Current.Dispatcher.Invoke(() => _serverModel.ServerMsg.Add(ms.Message));
            }

        }
        private async void SendCitations()
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            await Task.Run(() => {
                while (!token.IsCancellationRequested)
                {
                    var test = _cetation.GeneratorSend();
                    foreach (var item in test)
                    {
                        SendMsg(item);
                        _countCitation++;
                        if (_countCitation >= _maxCitation)
                        {
                           
                            cancelTokenSource.Cancel();
                           
                        }
                    }
                }
            },token);
            SendMsg("Limit !!!!    " + _maxCitation);
            Application.Current.Dispatcher.Invoke(() => _serverModel.ServerMsg.Add(DateTime.Now.ToString()));
            cancelTokenSource.Dispose();
            _handlerClient.Disconnect(false);
            return;
        }
        private void GetClientInfo()
        {
            _sizeBuffer= _handlerClient.Receive(_bufferBytes);
            _clientMessage = Encoding.Default.GetString(_bufferBytes, 0, _sizeBuffer);
            Application.Current.Dispatcher.Invoke(() => _serverModel.ServerMsg.Add(_clientMessage));
        }
        private void SendMsg(string message)
        {
            try
            {
                _handlerClient.Send(Encoding.Default.GetBytes(message));
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Server "+ Ex.Message);
            }
            
        }
      
        public ServerControl(ServerModel serverModel)
        {
            _maxCitation = 20;
            _serverModel = serverModel;
            _endPointServer = new IPEndPoint(IPAddress.IPv6Any,49000);
            _listener = new Socket(AddressFamily.InterNetworkV6,SocketType.Stream,ProtocolType.Tcp);
            _bufferBytes = new byte[1024];
           _cetation= new CetationGenerator();
        }


    }
}
