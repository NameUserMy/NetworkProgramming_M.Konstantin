using NetworkProgramming_HW_1.Control.TaskManagerControl;
using NetworkProgramming_HW_1.Model.TaskManagerModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace NetworkProgramming_HW_1.View.TaskManager
{
    /// <summary>
    /// Interaction logic for TaskManagerView.xaml
    /// </summary>
    public partial class TaskManagerView : UserControl
    {
        private ServerMessageModel? _serverMessage;
        private ClientMessageModel? _clientMessage;

        private ManagerServerControl? _serverControl;
        private ManagerClientControl? _clientControl;

        private string _processName;
        public TaskManagerView()
        {
            _serverMessage = new ServerMessageModel();
            _clientMessage = new ClientMessageModel();
            _serverControl = new ManagerServerControl(_serverMessage);
            _clientControl = new ManagerClientControl(_clientMessage);
            InitializeComponent();
            this.Loaded += TaskManagerView_Loaded;
        }

        private void TaskManagerView_Loaded(object sender, RoutedEventArgs e)
        {
            _serverControl.StartServerAsync();
            serverInfoList.DataContext = _serverMessage;
            proccesInfoList.DataContext = _clientMessage;


        }


        #region Button click
        private void getprocessButton_Click(object sender, RoutedEventArgs e)
        {
            _clientControl.SendMessage("Get process");
        }

        private void proccesInfoList_Selected(object sender, RoutedEventArgs e)
        {
            _processName = proccesInfoList.SelectedItem.ToString();
            MessageBox.Show($"You pick process  {_processName}");
        }

        private void stopProcessButton_Click(object sender, RoutedEventArgs e)
        {
            _clientControl.SendMessage($"Stop {_processName}");
        }

        private void startProcessButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Technical problems");
        }

        private void connectServerButton_Click(object sender, RoutedEventArgs e)
        {
            _clientControl.StartConnectAsync();
        }
        #endregion
    }
}
