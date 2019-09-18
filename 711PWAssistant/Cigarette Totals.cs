using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _711PWAssistant
{
    [Serializable]
    class Cigarette_Totals
    {
        private string _officeCigs;
        private string _dieselCigs;
        private string _gasCigs;
        private string _mclaneCigs;
        private string _totalCigs;

        public string OfficeCigs
        {
            get
            {
                return _officeCigs;
            }
            set
            {
                _officeCigs = value;
            }
        }
        public string DieselCigs
        {
            get
            {
                return _dieselCigs;
            }
            set
            {
                _dieselCigs = value;
            }
        }
        public string GasCigs
        {
            get
            {
                return _gasCigs;
            }
            set
            {
                _gasCigs = value;
            }
        }
        public string MclaneCigs
        {
            get
            {
                return _mclaneCigs;
            }
            set
            {
                _mclaneCigs = value;
            }
        }
        public string TotalCigs
        {
            get
            {
                return _totalCigs;
            }
            set
            {
                _totalCigs = value;
            }
        }
    }
}
