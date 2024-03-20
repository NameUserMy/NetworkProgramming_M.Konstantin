using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_2.Model
{
    class ServerModel:BaseModel
    {
        private ObservableCollection<string>? _servers;
        public  ObservableCollection<string>? ServerMsg
        {
            get => _servers;
            set { _servers = value; IsChanged(nameof(ServerMsg)); }
        }
        public ServerModel() => _servers = new ObservableCollection<string>();
    }
}
