using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_1.Model.ClientServerModel
{
    internal class MessageUserModel : BaseModel
    {
        private ObservableCollection<string>? _message;
        public ObservableCollection<string>? UserMsg
        {
            get => _message;
            set { _message = value; NotifyPropertyChanged(nameof(UserMsg)); }
        }
        public MessageUserModel()
        {

            _message = new ObservableCollection<string>();

        }
    }
}
