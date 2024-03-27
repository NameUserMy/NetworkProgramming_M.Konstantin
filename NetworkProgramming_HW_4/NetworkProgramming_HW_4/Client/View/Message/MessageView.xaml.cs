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

namespace NetworkProgramming_multiCast.View.Message
{
    /// <summary>
    /// Interaction logic for MessageView.xaml
    /// </summary>
    /// 
   
    public partial class MessageView : UserControl
    {
        private MessageModel? _modelMessage;
        public MessageView(MessageModel messageModel)
        {
            _modelMessage = messageModel;
            InitializeComponent();
            this.Loaded += MessageView_Loaded;
        }

        private void MessageView_Loaded(object sender, RoutedEventArgs e)
        {
            mesaggeList.DataContext = _modelMessage;
        }
    }
}
