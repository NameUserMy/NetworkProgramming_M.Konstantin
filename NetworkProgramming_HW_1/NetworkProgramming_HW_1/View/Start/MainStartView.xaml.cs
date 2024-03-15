using NetworkProgramming_HW_1.Control.ClientServerControl;
using NetworkProgramming_HW_1.Control.TaskManagerControl;
using NetworkProgramming_HW_1.View.ClientServer;
using NetworkProgramming_HW_1.View.TaskManager;
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

namespace NetworkProgramming_HW_1.View.Start
{
    /// <summary>
    /// Interaction logic for MainStartView.xaml
    /// </summary>
    public partial class MainStartView : Window
    {

       
        public MainStartView()
        {
            InitializeComponent();
        }

        private void clienServerButton_Click(object sender, RoutedEventArgs e)
        {
            networkControl.Content = new ClientServerView();
        }

        private void тaskManager_Click(object sender, RoutedEventArgs e)
        {
            networkControl.Content = new TaskManagerView();
        }
    }
}
