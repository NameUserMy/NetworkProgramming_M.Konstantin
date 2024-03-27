using NetworkProgramming_HW_4.Client.Control;
using NetworkProgramming_HW_4.Client.Model;
using NetworkProgramming_HW_4.Client.Model.Message;
using NetworkProgramming_multiCast.View.Message;
using NetworkProgramming_multiCast.View.Online;
using NetworkProgramming_multiCast.View.SendMessage;
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

namespace NetworkProgramming_multiCast.View.StartView
{
    /// <summary>
    /// Interaction logic for MainStart.xaml
    /// </summary>
    public partial class MainStart : Window
    {
        private SenderClientC? _senderClientC;
        private MessageModel? _modelMessage;
        private SendMesgModel? _sendMesgModel;
        private UserOnline? _userOnline;
        public MainStart()
        {
            _userOnline = new UserOnline();
            _modelMessage = new MessageModel();
            _senderClientC = new SenderClientC(_modelMessage, _userOnline);
            _sendMesgModel = new SendMesgModel();
           
            InitializeComponent();
            this.Loaded += MainStart_Loaded;
        }

       

        private void MainStart_Loaded(object sender, RoutedEventArgs e)
        {
            _senderClientC.StartListenerAsync();
            _senderClientC.sendmessageUnic();
            sendMessage.Content = new SendView(_senderClientC, _sendMesgModel);
            online.Content = new OnlineView(_userOnline);
            message.Content = new MessageView(_modelMessage);
        }
    }
}
