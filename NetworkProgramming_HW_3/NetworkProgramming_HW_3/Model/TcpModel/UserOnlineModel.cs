using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_3.Model.TcpModel
{
    internal class UserOnlineModel:BaseModel
    {
        private ObservableCollection<string>? _userName;

        public ObservableCollection<string>? UserOnline
        {
            get { return _userName; }
            set { _userName = value; ChangedProperty(nameof(UserOnline)); }
        }
        public UserOnlineModel() => _userName = new ObservableCollection<string>();
    }
}
