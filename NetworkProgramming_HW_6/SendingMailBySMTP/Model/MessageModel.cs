using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SendingMailBySMTP.Model
{
    internal class MessageModel : BaseVM
    {
        private string _sendTo;
        private string _senFrom;
        private string _subject;
        private string _body;
        private string _file;
        private int _port;
        private string _pass;
        private string _loggin;

        public string SendTo { get { return _sendTo; } set { _sendTo = value; ChangedProperty(nameof(SendTo)); } }
        public string SenFrom { get { return _senFrom; } set { _senFrom = value; ChangedProperty(nameof(SenFrom)); } }
        public string Subject { get { return _subject; } set { _subject = value; ChangedProperty(nameof(Subject)); } }
        public string Body { get { return _body; } set { _body = value; ChangedProperty(nameof(Body)); } }
        public string File { get { return _file; } set { _file = value; ChangedProperty(nameof(File)); } }
        public int Port { get { return _port; } set { _port = value; ChangedProperty(nameof(Port)); } }
        public string Loggin { get { return _loggin; } set { _loggin = value; ChangedProperty(nameof(Loggin)); }  }
        public string Pass { get { return _pass;} set { _pass = value; ChangedProperty(nameof(Pass)); } }
       
    }
}
