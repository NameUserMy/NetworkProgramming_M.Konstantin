using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_1.Model.TaskManagerModel
{
    internal class ClientMessageModel:BaseModel
    {

        private ObservableCollection<string>? _message;

        public  ObservableCollection<string>? ClientMsg
        {
            get { return _message; }
            set { _message = value; NotifyPropertyChanged(nameof(ClientMsg));}
        }
        public ClientMessageModel()=>_message = new ObservableCollection<string>();
    }
}
