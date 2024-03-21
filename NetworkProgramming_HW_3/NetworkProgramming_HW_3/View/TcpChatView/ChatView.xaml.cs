using NetworkProgramming_HW_3.Control.TcpChat;
using NetworkProgramming_HW_3.Model.TcpModel;
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

namespace NetworkProgramming_HW_3.View.TcpChatView
{
    /// <summary>
    /// Interaction logic for ChatView.xaml
    /// </summary>
    public partial class ChatView : UserControl
    {
        private ClientControl c;
        private UserOnlineModel _userOnlineM;
        private UserMessageModel _UmsgM;
        private HistoryMsgmodel _historyMsgM;
        public ChatView()
        {
            _userOnlineM = new UserOnlineModel();
            _UmsgM = new UserMessageModel();
            _historyMsgM = new HistoryMsgmodel();
            c = new ClientControl(_historyMsgM);
            InitializeComponent();
            this.Loaded += ChatView_Loaded;
        }
        private void ChatView_Loaded(object sender, RoutedEventArgs e)
        {
            onlineUserList.DataContext = _userOnlineM;
            userMsgTextBox.DataContext = _UmsgM;
            messageHistoyList.DataContext = _historyMsgM;
            c.ConnectServerAsync();
        }
        private void sendMessage_Click(object sender, RoutedEventArgs e)
        {
            c.SendMessage(_UmsgM.UserMsg);
            userMsgTextBox.Clear();
        }

       
    }
}
