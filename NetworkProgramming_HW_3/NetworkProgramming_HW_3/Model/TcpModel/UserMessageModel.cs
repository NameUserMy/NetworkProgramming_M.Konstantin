using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_3.Model.TcpModel
{
    internal class UserMessageModel:BaseModel
    {
        private string _userMsg;

        public string? UserMsg
        {
            get { return _userMsg; }
            set { _userMsg = value; ChangedProperty(nameof(UserMsg)); }
        }
    }
}
