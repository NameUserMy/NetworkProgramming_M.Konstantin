using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_2.Model
{
    class ClientModel:BaseModel
    {
        private ObservableCollection<string>? _client;
        public ObservableCollection<string>? ClientMsg
        {
            get => _client;
            set { _client = value; IsChanged(nameof(ClientMsg)); }
        }
        public ClientModel() => _client = new ObservableCollection<string>();
    }
}
