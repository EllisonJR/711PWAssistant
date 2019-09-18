using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _711PWAssistant
{
    [Serializable]
    class Fuel_Deliveries
    {
        private string _fuelType;
        private string _billOfLading;
        private string _netAmount;
        private string _grossAmount;

        public string FuelType
        {
            get
            {
                return _fuelType;
            }
            set
            {
                _fuelType = value;
            }
        }
        public string BillOfLading
        {
            get
            {
                return _billOfLading;
            }
            set
            {
                _billOfLading = value;
            }
        }
        public string NetAmount
        {
            get
            {
                return _netAmount;
            }
            set
            {
                _netAmount = value;
            }
        }
        public string GrossAmount
        {
            get
            {
                return _grossAmount;
            }
            set
            {
                _grossAmount = value;
            }
        }
    }
}
