using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _711PWAssistant
{
    [Serializable]
    class Cashier_Values
    {
        private string _cashierName;
        private string _cashierVariance;
        private string _cashierChange;
        private string _cashierDrops;

        public string CashierName
        {
            get
            {
                return _cashierName;
            }
            set
            {
                _cashierName = value;
            }
        }
        public string CashierVariance
        {
            get
            {
                return _cashierVariance;
            }
            set
            {
                _cashierVariance = value;
            }
        }
        public string CashierChange
        {
            get
            {
                return _cashierChange;
            }
            set
            {
                _cashierChange = value;
            }
        }
        public string CashierDrops
        {
            get
            {
                return _cashierDrops;
            }
            set
            {
                _cashierDrops = value;
            }
        }
        
    }
}
