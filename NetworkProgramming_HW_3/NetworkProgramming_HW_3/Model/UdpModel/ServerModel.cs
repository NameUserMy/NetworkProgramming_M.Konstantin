using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_3.Model.UdpModel
{
    class ServerModel:BaseModel
    {
        private ObservableCollection<string>? _message;

        public ObservableCollection<string>? GetMessage
        {
            get { return _message; }
            set { _message = value; ChangedProperty(nameof(GetMessage)); }
        }
        public ServerModel() => _message = new ObservableCollection<string>();
    }
}
