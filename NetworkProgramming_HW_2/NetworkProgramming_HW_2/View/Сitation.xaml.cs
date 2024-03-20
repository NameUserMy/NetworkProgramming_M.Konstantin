using NetworkProgramming_HW_2.Control;
using NetworkProgramming_HW_2.GeneratorCetation;
using NetworkProgramming_HW_2.Model;
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

namespace NetworkProgramming_HW_2.View
{
    /// <summary>
    /// Interaction logic for Сitation.xaml
    /// </summary>
    public partial class Сitation : Window
    {
        private ClientModel _clientModel;
        private ServerModel _serverModel;
        private ServerControl _serverControl;
        private ClientControl _clientControl;
        public Сitation()
        {
            _clientModel = new ClientModel();
            _serverModel = new ServerModel();
             _serverControl = new ServerControl(_serverModel);
            _clientControl = new ClientControl(_clientModel);
            InitializeComponent();
            this.Loaded += Сitation_Loaded;
        }

        private void Сitation_Loaded(object sender, RoutedEventArgs e)
        {
            serverMsgList.DataContext = _serverModel;
            clientMsgList.DataContext = _clientModel;
        }

        private void statServerButton_Click(object sender, RoutedEventArgs e)
        {
            _serverControl.StartServerAsync();
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _clientControl.ConnectServerAsync();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void getCitationButton_Click(object sender, RoutedEventArgs e)
        {
            _clientControl.SendMessage("Get");
        }

        private void stopEndDisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            _clientControl.SendMessage("Stop");
        }
    }
}
