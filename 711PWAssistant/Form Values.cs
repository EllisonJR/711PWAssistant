using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _711PWAssistant
{
    [Serializable]
    class Form_Values
    {
        public Cashier_Totals cashierTotals;
        public Cigarette_Totals cigaretteTotals;
        public Lottery_Totals lotteryTotals;
        public Misc_Sales miscSales;
        public Safe_Totals safeTotals;
        public Totalizers totalizers;

        public List<Fuel_Deliveries> fuelDeliveries;
        public List<Cashier_Values> cashierValues;

        public Form_Values()
        {
            cashierTotals = new Cashier_Totals();
            cigaretteTotals = new Cigarette_Totals();
            lotteryTotals = new Lottery_Totals();
            miscSales = new Misc_Sales();
            safeTotals = new Safe_Totals();
            totalizers = new Totalizers();

            fuelDeliveries = new List<Fuel_Deliveries>();
            cashierValues = new List<Cashier_Values>();

            for (int i = 0; i < 8; i++)
            {
                fuelDeliveries.Add(new Fuel_Deliveries());
            }
            for (int i = 0; i < 10; i++)
            {
                cashierValues.Add(new Cashier_Values());
            }
        }
    }
}
