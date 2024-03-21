using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_3.Model.UdpModel
{
    class ClientModel:BaseModel
    {
        private string? _message;

        public string? SendMessage
        {
            get { return _message; }
            set { _message = value; ChangedProperty(nameof(SendMessage));}
        }
    }
}
