using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_4.Client.Model
{
    public class UserOnline:BaseModel
    {
        private ObservableCollection<string>? _user;

        public ObservableCollection<string>? Users
        {
            get { return _user; }
            set { _user = value; ChangedProperty(nameof(Users)); }
        }
        public UserOnline() => _user = new ObservableCollection<string>();
    }
}
