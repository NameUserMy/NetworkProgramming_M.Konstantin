using ServerUdp.Control;

namespace ServerUdp
{
    internal class Program
    {

        //private ControlServer? _controlServer;
        static void Main(string[] args)
        {
            ControlServer _controlServer = new ControlServer(11000,"127.0.0.1");
            _controlServer.ReciveSendUnic();
            Console.ReadKey();
        }
    }
}
