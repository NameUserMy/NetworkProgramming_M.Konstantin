using SendingMailBySMTP.Control;
using SendingMailBySMTP.Model;
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

namespace SendingMailBySMTP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MessageModel _messageModel;
        SendMail _sendMail;
        public MainWindow()
        {
            _messageModel = new MessageModel();
            _sendMail = new SendMail(_messageModel);
            InitializeComponent();
            this.DataContext = _messageModel;
        }

        private void sendfile_Click(object sender, RoutedEventArgs e)
        {
            _sendMail.GetFile();
        }

        private void sendMail_Click(object sender, RoutedEventArgs e)
        {
            _sendMail.SendMailAsync();
        }
    }
}
