using NetworkProgramming_HW_4.Client.Control;
using NetworkProgramming_HW_4.Client.Model.Message;
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

namespace NetworkProgramming_multiCast.View.SendMessage
{
    /// <summary>
    /// Interaction logic for SendView.xaml
    /// </summary>
    public partial class SendView : UserControl
    {
        private SenderClientC? _senderClient;
        private SendMesgModel? _sendMessage;
        public SendView(SenderClientC send, SendMesgModel sendMesg)
        {
            _sendMessage = sendMesg;
            _senderClient = send;
            InitializeComponent();
            this.Loaded += SendView_Loaded;
        }

        private void SendView_Loaded(object sender, RoutedEventArgs e)
        {
            sendMessageText.DataContext = _sendMessage;
        }

        private void sendtMessageButton_Click(object sender, RoutedEventArgs e)
        {
            _senderClient.SendAsync(_sendMessage.SendMessage);
            sendMessageText.Clear();
        }
    }
}
