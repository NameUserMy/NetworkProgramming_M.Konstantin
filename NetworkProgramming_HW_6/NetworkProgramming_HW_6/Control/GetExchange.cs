using NetworkProgramming_HW_6.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkProgramming_HW_6.Control
{
    class GetExchange
    {

        private MonewViwModel? _money;
        private List<Money> _ml;
        string query = "https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5";
        public void GetSome()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(query);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string data = sr.ReadToEnd();
            _ml = JsonSerializer.Deserialize< List<Money>> (data);
            foreach (var item in _ml)
            {
                Application.Current.Dispatcher.Invoke(() =>_money?.Money?.Add(item));
            }
        } 

       
        public GetExchange(MonewViwModel monewViwModel)
        {
            _money = monewViwModel;
           _ml = new List<Money>();

        }
       
    }
}
