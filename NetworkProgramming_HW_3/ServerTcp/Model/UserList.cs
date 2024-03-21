using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerTcp.Model
{
    internal class UserList
    {
        public Dictionary<String, UserList>? _userInfo { get; set; }
        public string? UserMsg { get; set; }
        public string? UserName { get; set; }
        public Socket? userHendler { get; set; }
        public bool IsOnline { get; set; }

        public UserList() {
            _userInfo = new Dictionary<string, UserList>();
        }
    }
}
