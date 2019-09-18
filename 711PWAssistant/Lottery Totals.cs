using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _711PWAssistant
{
    [Serializable]
    class Lottery_Totals
    {
        private string _onlineSales;
        private string _instantSales;
        private string _onlinPaidOut;
        private string _instantPaidOut;

        public string OnlineSales
        {
            get
            {
                return _onlineSales;
            }
            set
            {
                _onlineSales = value;
            }
        }
        public string InstantSales
        {
            get
            {
                return _instantSales;
            }
            set
            {
                _instantSales = value;

            }
        }
        public string OnlinePaidOut
        {
            get
            {
                return _onlinPaidOut;
            }
            set
            {
                _onlinPaidOut = value;
            }
        }
        public string InstantPaidOut
        {
            get
            {
                return _instantPaidOut;
            }
            set
            {
                _instantPaidOut = value;
            }
        }
    }
}
