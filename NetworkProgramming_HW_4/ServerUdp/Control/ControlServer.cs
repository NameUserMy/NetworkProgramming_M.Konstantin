using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerUdp.Control
{
    internal class ControlServer
    {
        private Socket? _UdpListenerUnicast;
        private Socket? _UdpsenderMultiCast;
        EndPoint? _remote;
        private EndPoint? _ipServerPoint;
        private EndPoint? _multiCastPoint;
        private List<string>? _onlineUserl;
        public async void ReciveSendUnic()
        {
            await Task.Run(() =>
            {
                _UdpListenerUnicast.Bind(_ipServerPoint);
                try
                {

                    _remote = new IPEndPoint(0,0);
                    while (true)
                    {
                        byte[] arr = new Byte[1024];
                        int size = _UdpListenerUnicast.ReceiveFrom(arr, ref _remote); // получим UDP-датаграмму
                        Console.WriteLine(_remote);
                        _onlineUserl.Add(_remote.ToString());
                        string from_server = Encoding.Default.GetString(arr, 0, size);
                        Console.WriteLine(from_server);
                        _UdpsenderMultiCast.SendTo(SendListOnline(), _multiCastPoint); 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    _UdpListenerUnicast.Shutdown(SocketShutdown.Send); 
                    _UdpListenerUnicast.Close(); 
                }
            });
        }
        private byte[]  SendListOnline()
        {
            
            return Encoding.Default.GetBytes(JsonSerializer.Serialize(_onlineUserl),0, JsonSerializer.Serialize(_onlineUserl).Length);
        }
        public ControlServer(int port,string Ip)
        {
            _multiCastPoint = new IPEndPoint(IPAddress.Parse("235.0.0.0"), 11000);
            _UdpsenderMultiCast = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _UdpsenderMultiCast.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);
            _UdpsenderMultiCast.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(IPAddress.Parse("235.0.0.0")));


            _onlineUserl = new List<string>() {"User list" };
            _ipServerPoint = new IPEndPoint(IPAddress.Parse(Ip), port);
            _UdpListenerUnicast = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
    }
}
