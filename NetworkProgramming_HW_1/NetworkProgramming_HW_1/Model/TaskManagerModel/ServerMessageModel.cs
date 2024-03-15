using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_1.Model.TaskManagerModel
{
    internal class ServerMessageModel:BaseModel
    {
        private ObservableCollection<string>? _serverMsg;
        public ObservableCollection<string>? ServerMsg
        {
            get { return _serverMsg; }
            set { _serverMsg = value; NotifyPropertyChanged(nameof(ServerMsg));}

        }
        public ServerMessageModel() => _serverMsg = new ObservableCollection<string>();
    }
}
