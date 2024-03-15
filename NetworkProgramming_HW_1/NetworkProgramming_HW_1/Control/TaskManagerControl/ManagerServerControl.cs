using NetworkProgramming_HW_1.Model.TaskManagerModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkProgramming_HW_1.Control.TaskManagerControl
{
    internal class ManagerServerControl
    {
        private TcpListener? _server;
        private TcpClient? _clientHandle;
        private string _clientMesg;
        private ServerMessageModel _serverMessage;
        private int _sizeMessage;
        private byte[]? _bufferMessage;
        private int _port;
        public async void StartServerAsync()
        {

            await Task.Run(SetListener);
            Task.Run(StartConnectClient);
            

        }
        private void SetListener()
        {

            try
            {
                _server.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void StartConnectClient()
        {

            while (true)
            {
                _clientHandle = _server.AcceptTcpClient();
                Task.Run(()=>MessageProcessing(_clientHandle));
            }
        }
        private void MessageProcessing(TcpClient tcpClient)
        {
            _sizeMessage=tcpClient.GetStream().Read( _bufferMessage=new byte[tcpClient.ReceiveBufferSize],0,tcpClient.ReceiveBufferSize);
            Application.Current.Dispatcher.Invoke(()=>_serverMessage.ServerMsg.Add(Encoding.Default.GetString(_bufferMessage, 0, _sizeMessage)));
            while (true)
            {
                _sizeMessage = tcpClient.GetStream().Read(_bufferMessage = new byte[tcpClient.ReceiveBufferSize], 0, tcpClient.ReceiveBufferSize);
                if (_sizeMessage > 0)
                {
                    Application.Current.Dispatcher.Invoke(() => _serverMessage.ServerMsg.Add(Encoding.Default.GetString(_bufferMessage, 0, _sizeMessage)));
                    _clientMesg = Encoding.Default.GetString(_bufferMessage, 0, _sizeMessage);
                   
                 
                    
                }
                else { tcpClient.Close(); }
                if (_clientMesg.Equals("Get process"))
                {
                    tcpClient.GetStream().Write(Encoding.Default.GetBytes(GetProcessList()), 0, Encoding.Default.GetBytes(GetProcessList()).Length);
                }
                if (_clientMesg.Split(' ')[0] == "Stop" && _clientMesg.Split(' ')[1].Length > 0)
                {
                    StopProcess(_clientMesg.Split(' ')[1]);
                }
                

            }
        }
        private string GetProcessList()
        {
            var listProcess = new List<string>();
            foreach (var item in Process.GetProcesses())
            {
                listProcess.Add(item.ProcessName);
            }
            
           return JsonSerializer.Serialize(listProcess);
        }
        private void StopProcess(string pName)
        {
            var targetProcces = Process.GetProcessesByName(pName);
            Process.GetProcessById(targetProcces[0].Id).Kill();

        }
        public ManagerServerControl(ServerMessageModel serverMessageModel)
        {
            _serverMessage = serverMessageModel;
            _port = 49000;
            _server = new TcpListener(IPAddress.Any,_port);
        }
    }
}
