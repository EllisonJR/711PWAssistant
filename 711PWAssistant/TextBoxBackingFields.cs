using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _711PWAssistant
{
    static class TextBoxBackingFields
    {
        public static DateTime PaperworkDate { get; set; }

        public static double FrontPennies { get; set; }
        public static double FrontNickles { get; set; }
        public static double FrontDimes { get; set; }
        public static double FrontQuarters { get; set; }
        public static double FrontOnes { get; set; }
        public static double FrontFives { get; set; }
        public static double FrontTens { get; set; }
        public static double FrontTwenties { get; set; }

        public static double BackPennies { get; set; }
        public static double BackNickles { get; set; }
        public static double BackDimes { get; set; }
        public static double BackQuarters { get; set; }
        public static double BackOnes { get; set; }
        public static double BackFives { get; set; }
        public static double BackTens { get; set; }
        public static double BackTwenties { get; set; }

        public static double OfficeSafe { get; set; }
        public static double DieselDrawer { get; set; }
        public static double GasDrawer { get; set; }

        public static double TotalSafe { get; set; }

        public static double GasCigs { get; set; }
        public static double DieselCigs { get; set; }
        public static double MclaneCigs { get; set; }
        public static double OfficeCigs { get; set; }
        public static double TotalCigs { get; set; }

        public static double CashierVariance1 { get; set; }
        public static double CashierVariance2 { get; set; }
        public static double CashierVariance3 { get; set; }
        public static double CashierVariance4 { get; set; }
        public static double CashierVariance5 { get; set; }
        public static double CashierVariance6 { get; set; }
        public static double CashierVariance7 { get; set; }
        public static double CashierVariance8 { get; set; }
        public static double CashierVariance9 { get; set; }
        public static double CashierVariance10 { get; set; }

        public static double CashierDrops1 { get; set; }
        public static double CashierDrops2 { get; set; }
        public static double CashierDrops3 { get; set; }
        public static double CashierDrops4 { get; set; }
        public static double CashierDrops5 { get; set; }
        public static double CashierDrops6 { get; set; }
        public static double CashierDrops7 { get; set; }
        public static double CashierDrops8 { get; set; }
        public static double CashierDrops9 { get; set; }
        public static double CashierDrops10 { get; set; }

        public static double CashierChange1 { get; set; }
        public static double CashierChange2 { get; set; }
        public static double CashierChange3 { get; set; }
        public static double CashierChange4 { get; set; }
        public static double CashierChange5 { get; set; }
        public static double CashierChange6 { get; set; }
        public static double CashierChange7 { get; set; }
        public static double CashierChange8 { get; set; }
        public static double CashierChange9 { get; set; }
        public static double CashierChange10 { get; set; }

        public static string CashierName1 { get; set; }
        public static string CashierName2 { get; set; }
        public static string CashierName3 { get; set; }
        public static string CashierName4 { get; set; }
        public static string CashierName5 { get; set; }
        public static string CashierName6 { get; set; }
        public static string CashierName7 { get; set; }
        public static string CashierName8 { get; set; }
        public static string CashierName9 { get; set; }
        public static string CashierName10 { get; set; }

        public static double VarianceTotal { get; set; }
        public static double DropsTotal { get; set; }
        public static double ChangeTotal { get; set; }
        public static double BankDeposit { get; set; }

        public static string LowFeedstock { get; set; }
        public static string HighFeedstock { get; set; }
        public static string Diesel { get; set; }
        public static string DieselFiscal5 { get; set; }
        public static string DieselKer1 { get; set; }
        public static string UltE852 { get; set; }
        public static string UnleadRace { get; set; }
        public static string Def3 { get; set; }
        public static string DefRec90 { get; set; }

        public static double Checks { get; set; }

        public static double OnlinePaidOut { get; set; }
        public static double OnlineSales { get; set; }
        public static double InstantPaidOut { get; set; }
        public static double InstantSales { get; set; }

        public static double AmbestRedeem { get; set; }
        public static double StorePaidOut { get; set; }
        public static double Coupons { get; set; }
        public static double Incentive { get; set; }
        public static double Reimbursement { get; set; }
        public static double Overrun { get; set; }

        public static string FuelType1 { get; set; }
        public static string BillOfLading1 { get; set; }
        public static string NetFuel1 { get; set; }
        public static string GrossFuel1 { get; set; }
        public static string FuelType2 { get; set; }
        public static string BillOfLading2 { get; set; }
        public static string NetFuel2 { get; set; }
        public static string GrossFuel2 { get; set; }
        public static string FuelType3 { get; set; }
        public static string BillOfLading3 { get; set; }
        public static string NetFuel3 { get; set; }
        public static string GrossFuel3 { get; set; }
        public static string FuelType4 { get; set; }
        public static string BillOfLading4 { get; set; }
        public static string NetFuel4 { get; set; }
        public static string GrossFuel4 { get; set; }
        public static string FuelType5 { get; set; }
        public static string BillOfLading5 { get; set; }
        public static string NetFuel5 { get; set; }
        public static string GrossFuel5 { get; set; }
        public static string FuelType6 { get; set; }
        public static string BillOfLading6 { get; set; }
        public static string NetFuel6 { get; set; }
        public static string GrossFuel6 { get; set; }
        public static string FuelType7 { get; set; }
        public static string BillOfLading7 { get; set; }
        public static string NetFuel7 { get; set; }
        public static string GrossFuel7 { get; set; }
        public static string FuelType8 { get; set; }
        public static string BillOfLading8 { get; set; }
        public static string NetFuel8 { get; set; }
        public static string GrossFuel8 { get; set; }
        public static string UnleadedEthanolDollars { get; set; }
        public static string MidgradeEthanolDollars { get; set; }
        public static string PremiumEthanolDollars { get; set; }
        public static string UltraDollars { get; set; }
        public static string DieselDollars { get; set; }
        public static string DefDollars { get; set; }
        public static string UnleadedEthanolUnits { get; set; }
        public static string MidgradeEthanolUnits { get; set; }
        public static string PremiumEthanolUnits { get; set; }
        public static string UltraUnits { get; set; }
        public static string DieselUnits { get; set; }
        public static string DefUnits { get; set; }

        public static void ClearAllFields()
        {
            FrontPennies = 0;
            FrontNickles = 0;
            FrontDimes = 0;
            FrontQuarters = 0;
            FrontOnes = 0;
            FrontFives = 0;
            FrontTens = 0;
            FrontTwenties = 0;

            BackPennies = 0;
            BackNickles = 0;
            BackDimes = 0;
            BackQuarters = 0;
            BackOnes = 0;
            BackFives = 0;
            BackTens = 0;
            BackTwenties = 0;

            TotalSafe = 0;

            DieselCigs = 0;
            GasCigs = 0;
            OfficeCigs = 0;
            MclaneCigs = 0;
            TotalCigs = 0;

            CashierChange1 = 0;
            CashierChange2 = 0;
            CashierChange3 = 0;
            CashierChange4 = 0;
            CashierChange5 = 0;
            CashierChange6 = 0;
            CashierChange7 = 0;
            CashierChange8 = 0;
            CashierChange9 = 0;
            CashierChange10 = 0;

            CashierVariance1 = 0;
            CashierVariance2 = 0;
            CashierVariance3 = 0;
            CashierVariance4 = 0;
            CashierVariance5 = 0;
            CashierVariance6 = 0;
            CashierVariance7 = 0;
            CashierVariance8 = 0;
            CashierVariance9 = 0;
            CashierVariance10 = 0;

            CashierDrops1 = 0;
            CashierDrops2 = 0;
            CashierDrops3 = 0;
            CashierDrops4 = 0;
            CashierDrops5 = 0;
            CashierDrops6 = 0;
            CashierDrops7 = 0;
            CashierDrops8 = 0;
            CashierDrops9 = 0;
            CashierDrops10 = 0;

            CashierName1 = null;
            CashierName2 = null;
            CashierName3 = null;
            CashierName4 = null;
            CashierName5 = null;
            CashierName6 = null;
            CashierName7 = null;
            CashierName8 = null;
            CashierName9 = null;
            CashierName10 = null;

            LowFeedstock = null;
            HighFeedstock = null;
            Diesel = null;
            DieselFiscal5 = null;
            DieselKer1 = null;
            UltE852 = null;
            UnleadRace = null;
            Def3 = null;
            DefRec90 = null;

            Checks = 0;

            InstantPaidOut = 0;
            InstantSales = 0;
            OnlinePaidOut = 0;
            OnlineSales = 0;

            AmbestRedeem = 0;
            StorePaidOut = 0;
            Incentive = 0;
            Coupons = 0;
            Reimbursement = 0;
            Overrun = 0;

            FuelType1 = null;
            BillOfLading1 = null;
            NetFuel1 = null;
            GrossFuel1 = null;

            FuelType2 = null;
            BillOfLading2 = null;
            NetFuel2 = null;
            GrossFuel2 = null;

            FuelType3 = null;
            BillOfLading3 = null;
            NetFuel3 = null;
            GrossFuel3 = null;

            FuelType4 = null;
            BillOfLading4 = null;
            NetFuel4 = null;
            GrossFuel4 = null;

            FuelType5 = null;
            BillOfLading5 = null;
            NetFuel5 = null;
            GrossFuel5 = null;

            FuelType6 = null;
            BillOfLading6 = null;
            NetFuel6 = null;
            GrossFuel6 = null;

            FuelType7 = null;
            BillOfLading7 = null;
            NetFuel7 = null;
            GrossFuel7 = null;

            FuelType8 = null;
            BillOfLading8 = null;
            NetFuel8 = null;
            GrossFuel8 = null;

            UnleadedEthanolDollars = null;
            MidgradeEthanolDollars = null;
            PremiumEthanolDollars = null;
            DieselDollars = null;
            DefDollars = null;
            UltraDollars = null;

            UnleadedEthanolUnits = null;
            MidgradeEthanolUnits = null;
            PremiumEthanolUnits = null;
            DieselUnits = null;
            DefUnits = null;
            UltraUnits = null;
        }
    }
}
