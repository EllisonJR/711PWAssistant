using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _711PWAssistant
{
    [Serializable]
    class Totalizers
    {
        private string _lowFeedtock;
        private string _highFeedstock;
        private string _diesel;
        private string _dieselFiscal5;
        private string _dieselKer1;
        private string _ultE852;
        private string _unleadRace;
        private string _def3;
        private string _defRec90;

        public string LowFeedstock
        {
            get
            {
                return _lowFeedtock;
            }
            set
            {
                _lowFeedtock = value;
            }
        }
        public string HighFeedstock
        {
            get
            {
                return _highFeedstock;
            }
            set
            {
                _highFeedstock = value;
            }
        }
        public string Diesel
        {
            get
            {
                return _diesel;
            }
            set
            {
                _diesel = value;
            }
        }
        public string DieselFiscal
        {
            get
            {
                return _dieselFiscal5;
            }
            set
            {
                _dieselFiscal5 = value;
            }
        }
        public string DieselKer1
        {
            get
            {
                return _dieselKer1;
            }
            set
            {
                _dieselKer1 = value;
            }
        }
        public string UltE852
        {
            get
            {
                return _ultE852;
            }
            set
            {
                _ultE852 = value;
            }
        }
        public string UnleadRace
        {
            get
            {
                return _unleadRace;
            }
            set
            {
                _unleadRace = value;
            }
        }
        public string Def3
        {
            get
            {
                return _def3;
            }
            set
            {
                _def3 = value;
            }
        }
        public string DefRec90
        {
            get
            {
                return _defRec90;
            }
            set
            {
                _defRec90 = value;
            }
        }
    }
}
