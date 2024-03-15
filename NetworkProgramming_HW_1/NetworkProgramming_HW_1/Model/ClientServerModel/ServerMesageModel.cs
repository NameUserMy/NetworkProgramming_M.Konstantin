using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_1.Model.ClientServerModel
{
    internal class ServerMesageModel : BaseModel
    {
        private ObservableCollection<string>? _server;

        public ObservableCollection<string> ServerMsg
        {
            get { return _server; }
            set { _server = value; NotifyPropertyChanged(nameof(ServerMsg)); }
        }
        public ServerMesageModel()
        {
            _server = new ObservableCollection<string>();
        }
    }
}
