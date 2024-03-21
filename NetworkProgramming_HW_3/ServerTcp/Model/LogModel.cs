using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTcp.Model
{
    internal class LogModel:BaseModel
    {

        private ObservableCollection<string>? _log;

        public ObservableCollection<string>? Log
        {
            get { return _log; }
            set { _log = value; ChangedProperty(nameof(Log)); }
        }
        public LogModel() => _log = new ObservableCollection<string>();
    }
}
