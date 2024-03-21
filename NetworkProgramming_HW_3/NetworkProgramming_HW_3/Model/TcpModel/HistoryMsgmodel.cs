using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_3.Model.TcpModel
{
    internal class HistoryMsgmodel:BaseModel
    {
        private ObservableCollection<string>? _msgHistory;

        public ObservableCollection<string>? MsgHistory
        {
            get { return _msgHistory; }
            set { _msgHistory = value; ChangedProperty(nameof(MsgHistory)); }
        }
        public HistoryMsgmodel() => _msgHistory = new ObservableCollection<string>();
    }
}
