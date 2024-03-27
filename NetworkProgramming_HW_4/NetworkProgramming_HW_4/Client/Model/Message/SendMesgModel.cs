using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_4.Client.Model.Message
{
    public class SendMesgModel:BaseModel
    {
        private string? _message;

        public string? SendMessage
        {
            get { return _message; }
            set { _message = value; ChangedProperty(nameof(Message)); }
        }
       
    }
}
