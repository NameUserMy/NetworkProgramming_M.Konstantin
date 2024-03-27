using NetworkProgramming_HW_4.Client.Model;
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

namespace NetworkProgramming_multiCast.View.Online
{
    /// <summary>
    /// Interaction logic for OnlineView.xaml
    /// </summary>
    public partial class OnlineView : UserControl
    {
       
        public OnlineView(UserOnline user)
        {
            InitializeComponent();
            onlineList.DataContext = user;
        }
    }
}
