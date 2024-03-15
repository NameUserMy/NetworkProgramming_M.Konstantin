using NetworkProgramming_HW_1.Control.ClientServerControl;
using NetworkProgramming_HW_1.Model.ClientServerModel;
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

namespace NetworkProgramming_HW_1.View.ClientServer
{
    /// <summary>
    /// Interaction logic for ClientServerView.xaml
    /// </summary>
    public partial class ClientServerView : UserControl
    {
        ServerControl _serverControl;
        ClientControl _clientControl;
        MessageUserModel _UserModel;
        ServerMesageModel _serverModel;
        public ClientServerView()
        {
            _UserModel = new MessageUserModel();
            _serverModel = new ServerMesageModel();
            _clientControl = new ClientControl(_UserModel);
            _serverControl = new ServerControl(_serverModel);
            InitializeComponent();
            this.Loaded += ClientServerView_Loaded;
        }

        private void ClientServerView_Loaded(object sender, RoutedEventArgs e)
        {
            userMessageList.DataContext = _UserModel;
            serverMessageList.DataContext = _serverModel;
        }
        private void sendUserMessage_Click(object sender, RoutedEventArgs e)
        {
            _clientControl.SendMessage(userMessage.Text);
        }

        private void startServerButton_Click(object sender, RoutedEventArgs e)
        {
            _serverControl.StartServerAsync();
        }

        private void connectToServer_Click(object sender, RoutedEventArgs e)
        {
            _clientControl.ConnectServerAsync();
        }
    }
}
