using ServerTcp.Control;
using ServerTcp.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServerTcp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServerControl _serverControl;
        private LogModel _logModel;
        public MainWindow()
        {
            _logModel = new LogModel();
            _serverControl = new ServerControl(_logModel);
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            logList.DataContext = _logModel;
        }

        private void startServer_Click(object sender, RoutedEventArgs e)
        {
            _serverControl.StartServerAsync();
        }
    }
}