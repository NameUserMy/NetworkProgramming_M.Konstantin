

using ServerTcp.Model;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace ServerTcp.Control
{
    internal class ServerControl
    {
        private IPEndPoint? _endPointServer;

        private Socket? _listener;
        private Socket? _handlerClient;
        private LogModel? _logM;
        private UserList _userLis;
        private string? _clientMessage;
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
                Application.Current.Dispatcher.Invoke(() => _logM.Log.Add($"Start ..  {_listener.Handle}"));
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ConnectToClient()
        {
           
            while (true)
            {
                _handlerClient = _listener.Accept();
                _userLis._userInfo.Add($"{_handlerClient.RemoteEndPoint}",new UserList { 
                    IsOnline=true,
                    UserName= $"{_handlerClient.RemoteEndPoint}",
                    userHendler=_handlerClient
                
                });
                Application.Current.Dispatcher.Invoke(() => _logM.Log.Add($"{_handlerClient.RemoteEndPoint} Is online"));
                Task.Run(() => ClientMessage(_handlerClient));
            }
            
        }
        private void ClientMessage(Socket handlerClient)
        {
            try
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
                  
                        SendMsgUserOnline(Encoding.Default.GetString(_bufferBytes, 0, _sizeMessge));
                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Current.Dispatcher.Invoke(() => _logM.Log.Remove($"{_handlerClient.RemoteEndPoint} Is online"));
                handlerClient.Shutdown(SocketShutdown.Both);
                handlerClient.Close();
                return;
            }
            
        }
        private void SendMsgUserOnline(string msg)
        {
            foreach (var item in _userLis._userInfo)
            {
                item.Value.userHendler.Send(Encoding.Default.GetBytes(msg, 0, msg.Length));
            }
        }
       
        public ServerControl(LogModel logModel)
        {
            _userLis = new UserList();
            _logM = logModel;
            _endPointServer = new IPEndPoint(IPAddress.Any, 49001);//End point сервера прослушиваем все Ip на порту 49001
            _listener = new Socket(AddressFamily.InterNetwork/*ipv4*/, SocketType.Stream, ProtocolType.Tcp);
            _bufferBytes = new byte[1024];
        }
    }
}

