using NetworkProgramming_HW_5_WF_.NET.Control;
using NetworkProgramming_HW_5_WF_.NET.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkProgramming_HW_5_WF_.NET
{
    public partial class Form1 : Form
    {
        private Client _client;
        public Form1()
        {
            InitializeComponent();
            new Server().StartServerAsync();
            _client = new Client();
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            _client.ConnectServerAsync();
        }
    }
}
