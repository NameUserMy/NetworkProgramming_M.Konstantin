using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_4.Client.Model.Message
{
    public class MessageModel:BaseModel
    {
        private ObservableCollection<string>? _message;

        public ObservableCollection<string>? Message
        {
            get { return _message; }
            set { _message = value; ChangedProperty(nameof(Message));}
        }
        public MessageModel() => _message = new ObservableCollection<string>();
    }
}
