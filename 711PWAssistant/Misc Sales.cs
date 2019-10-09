using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _711PWAssistant
{
    [Serializable]
    class Misc_Sales
    {
        private string _ambestRedemption;
        private string _storePaidOut;
        private string _coupons;
        private string _employeeIncentive;
        public string Reimbursement { get; set; }
        public string Overrun { get; set; }

        public string AmbestRedemption
        {
            get
            {
                return _ambestRedemption;
            }
            set
            {
                _ambestRedemption = value;
            }
        }
        public string StorePaidOut
        {
            get
            {
                return _storePaidOut;
            }
            set
            {
                _storePaidOut = value;
            }
        }
        public string Coupons
        {
            get
            {
                return _coupons;
            }
            set
            {
                _coupons = value;
            }
        }
        public string EmployeeIncentive
        {
            get
            {
                return _employeeIncentive;
            }
            set
            {
                _employeeIncentive = value;
            }
        }
    }
}
