using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _711PWAssistant
{
    [Serializable]
    class Cashier_Totals
    {
        private string _cashierDropsTotals;
        private string _cashierVarianceTotals;
        private string _cashierChangeTotals;
        private string _cashierChecks;
        private string _bankDeposit;

        public string CashierDropsTotals
        {
            get
            {
                return _cashierDropsTotals;
            }
            set
            {
                _cashierDropsTotals = value;
            }
        }
        public string CashierVarianceTotals
        {
            get
            {
                return _cashierVarianceTotals;
            }
            set
            {
                _cashierVarianceTotals = value;
            }
        }
        public string CashierChangeTotals
        {
            get
            {
                return _cashierChangeTotals;
            }
            set
            {
                _cashierChangeTotals = value;
            }
        }
        public string CashierChecks
        {
            get
            {
                return _cashierChecks;
            }
            set
            {
                _cashierChecks = value;
            }
        }
        public string BankDeposit
        {
            get
            {
                return _bankDeposit;
            }
            set
            {
                _bankDeposit = value;
            }
        }
    }
}
