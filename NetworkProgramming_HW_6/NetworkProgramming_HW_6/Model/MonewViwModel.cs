using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkProgramming_HW_6.Model
{
    class MonewViwModel:BaseModelView
    {

        private ObservableCollection<Money>? _moneyList;

        public ObservableCollection<Money>? Money
        {
            get { return _moneyList; }
            set { _moneyList = value; ChangedProperty(nameof(Money)); }
        }
        public MonewViwModel() => _moneyList = new ObservableCollection<Money>();

    }
}
