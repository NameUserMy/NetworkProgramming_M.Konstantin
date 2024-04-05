using NetworkProgramming_HW_6.Control;
using NetworkProgramming_HW_6.Model;
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

namespace NetworkProgramming_HW_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MonewViwModel? _monewViwModel;
        private GetExchange? _getExchange;
        public MainWindow()
        {
            _monewViwModel = new MonewViwModel();
            InitializeComponent();
            _getExchange = new GetExchange(_monewViwModel);
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _getExchange?.GetSome();
            listMoney.DataContext = _monewViwModel;
        }

        private void GetMoney_Click(object sender, RoutedEventArgs e)
        {
            
            _getExchange?.GetSome();
        }
    }
}