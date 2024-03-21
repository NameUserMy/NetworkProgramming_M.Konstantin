using NetworkProgramming_HW_3.Control.UdpControl;
using NetworkProgramming_HW_3.View.TcpChatView;
using NetworkProgramming_HW_3.View.UdpView;
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
using System.Windows.Shapes;

namespace NetworkProgramming_HW_3.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            
            InitializeComponent();
        }

        private void tcpChat_Click(object sender, RoutedEventArgs e)
        {
            networkControl.Content = new ChatView();
        }

        private void udpClienServerButton_Click(object sender, RoutedEventArgs e)
        {
            networkControl.Content = new ViewUdp();
        }
    }
}
