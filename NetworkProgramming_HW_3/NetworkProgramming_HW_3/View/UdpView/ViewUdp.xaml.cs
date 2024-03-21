using NetworkProgramming_HW_3.Control.UdpControl;
using NetworkProgramming_HW_3.Model.UdpModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetworkProgramming_HW_3.View.UdpView
{
    /// <summary>
    /// Interaction logic for ViewUdp.xaml
    /// </summary>
    public partial class ViewUdp : UserControl
    {
        private ServerModel? _serverM;
        private ClientModel? _clientM;
        private ClientControlUdp? _clientUdp;
        private ServerControlUdp? _serverUdp;
        public ViewUdp()
        {
            _clientM = new ClientModel();
            _serverM = new ServerModel();
            _clientUdp = new ClientControlUdp(_clientM);
            _serverUdp = new ServerControlUdp(_serverM);
            InitializeComponent();

            this.Loaded += ViewUdp_Loaded;
        }

        private void ViewUdp_Loaded(object sender, RoutedEventArgs e)
        {
            serverList.DataContext = _serverM;
            clientList.DataContext = _clientM;
        }

        private void sendMessage_Click(object sender, RoutedEventArgs e)
        {
            _clientUdp.SendMessageAsync();
            clientList.Clear();
        }

        private void startServer_Click(object sender, RoutedEventArgs e)
        {
            _serverUdp.StartListenerAsync();
        }
    }
}
