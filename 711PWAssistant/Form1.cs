using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;
using System.Text.RegularExpressions;
using ZetPDF.Pdf;
using ZetPDF.Drawing;
using System.Drawing.Printing;

namespace _711PWAssistant
{
    public partial class Form1 : Form
    {
        Form_Values formValues;
        IFormatter binaryFormatter = new BinaryFormatter();


        PWSDateForm dateForm;
        CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
        TubesForm tubesForm;
        PumpTestsForm pumpTests;
        public Form1()
        {
            InitializeComponent();
            dateForm = new PWSDateForm();
            tubesForm = new TubesForm();
            pumpTests = new PumpTestsForm();
            currentPWSLabel.Text = DateTime.Today.AddDays(-1).ToLongDateString();
            culture.NumberFormat.CurrencyNegativePattern = 1;
            TextBoxBackingFields.PaperworkDate = Convert.ToDateTime(currentPWSLabel.Text);
            Directory.CreateDirectory(Properties.Settings.Default["RootFilePath"].ToString());
            Directory.CreateDirectory(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["PdfFilePath"].ToString());
            Directory.CreateDirectory(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["BinFilePath"].ToString());
            Directory.CreateDirectory(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["ExceptionFilePath"].ToString());
            Directory.CreateDirectory(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["TraceFilePath"].ToString());
            Directory.CreateDirectory(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["ImgFilePath"].ToString());
            if(File.Exists(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["BinFilePath"].ToString() + TextBoxBackingFields.PaperworkDate.ToString("MM-dd-yyyy") + " PWS.bin"))
            {
                Stream objStreamDeSerialize = new FileStream(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["BinFilePath"].ToString() + TextBoxBackingFields.PaperworkDate.ToString("MM-dd-yyyy") + " PWS.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                formValues = (Form_Values)binaryFormatter.Deserialize(objStreamDeSerialize);

                DeserializeFormValues();
                objStreamDeSerialize.Close();
            }
        }
        private void textChanged(object sender, EventArgs e)
        {
            TextBox textBox = new TextBox();
            ComboBox comboBox = new ComboBox();
            if (sender is ComboBox)
            {
                comboBox = (ComboBox)sender;
            }
            else
            {
                textBox = (TextBox)sender;
            }
            switch (textBox.Name)
            {
                case "penniesFrontSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-"|| textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.FrontPennies = 0;
                        frontPenniesCalculated.Text = TextBoxBackingFields.FrontPennies.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.FrontPennies = Convert.ToDouble(textBox.Text);
                        frontPenniesCalculated.Text = (TextBoxBackingFields.FrontPennies * 0.50).ToString("C");
                    }
                    break;
                case "penniesBackSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.BackPennies = 0;
                        backPenniesCalculated.Text = TextBoxBackingFields.BackPennies.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.BackPennies = Convert.ToDouble(textBox.Text);
                        backPenniesCalculated.Text = (TextBoxBackingFields.BackPennies * 0.50).ToString("C");
                    }
                    break;
                case "nicklesFrontSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.FrontNickles = 0;
                        frontNicklesCalculated.Text = TextBoxBackingFields.FrontNickles.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.FrontNickles = Convert.ToDouble(textBox.Text);
                        frontNicklesCalculated.Text = (TextBoxBackingFields.FrontNickles * 2.00).ToString("C");
                    }
                    break;
                case "nicklesBackSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.BackNickles = 0;
                        backNicklesCalculated.Text = TextBoxBackingFields.BackNickles.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.BackNickles = Convert.ToDouble(textBox.Text);
                        backNicklesCalculated.Text = (TextBoxBackingFields.BackNickles * 2.00).ToString("C");
                    }
                    break;
                case "dimesFrontSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.FrontDimes = 0;
                        frontDimesCalculated.Text = TextBoxBackingFields.FrontDimes.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.FrontDimes = Convert.ToDouble(textBox.Text);
                        frontDimesCalculated.Text = (TextBoxBackingFields.FrontDimes * 5.00).ToString("C");
                    }
                    break;
                case "dimesBackSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.BackDimes = 0;
                        backDimesCalculated.Text = TextBoxBackingFields.BackDimes.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.BackDimes = Convert.ToDouble(textBox.Text);
                        backDimesCalculated.Text = (TextBoxBackingFields.BackDimes * 5.00).ToString("C");
                    }
                    break;
                case "quartersFrontSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.FrontQuarters = 0;
                        frontQuartersCalculated.Text = TextBoxBackingFields.FrontQuarters.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.FrontQuarters = Convert.ToDouble(textBox.Text);
                        frontQuartersCalculated.Text = (TextBoxBackingFields.FrontQuarters * 10.00).ToString("C");
                    }
                    break;
                case "quartersBackSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.BackQuarters = 0;
                        backQuartersCalculated.Text = TextBoxBackingFields.BackQuarters.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.BackQuarters = Convert.ToDouble(textBox.Text);
                        backQuartersCalculated.Text = (TextBoxBackingFields.BackQuarters * 10.00).ToString("C");
                    }
                    break;
                case "onesFrontSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.FrontOnes = 0;
                        frontOnesCalculated.Text = TextBoxBackingFields.FrontOnes.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.FrontOnes = Convert.ToDouble(textBox.Text);
                        frontOnesCalculated.Text = (TextBoxBackingFields.FrontOnes * Convert.ToDouble(Properties.Settings.Default["FrontOnes"])).ToString("C");
                    }
                    break;
                case "onesBackSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.BackOnes = 0;
                        backOnesCalculated.Text = TextBoxBackingFields.BackOnes.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.BackOnes = Convert.ToDouble(textBox.Text);
                        backOnesCalculated.Text = (TextBoxBackingFields.BackOnes * Convert.ToDouble(Properties.Settings.Default["BackOnes"])).ToString("C");
                    }
                    break;
                case "fivesFrontSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.FrontFives = 0;
                        frontFivesCalculated.Text = TextBoxBackingFields.FrontFives.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.FrontFives = Convert.ToDouble(textBox.Text);
                        frontFivesCalculated.Text = (TextBoxBackingFields.FrontFives * Convert.ToDouble(Properties.Settings.Default["FrontFives"])).ToString("C");
                    }
                    break;
                case "fivesBackSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.BackFives = 0;
                        backFivesCalculated.Text = TextBoxBackingFields.BackFives.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.BackFives = Convert.ToDouble(textBox.Text);
                        backFivesCalculated.Text = (TextBoxBackingFields.BackFives * Convert.ToDouble(Properties.Settings.Default["BackFives"])).ToString("C");
                    }
                    break;
                case "tensFrontSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.FrontTens = 0;
                        frontTensCalculated.Text = TextBoxBackingFields.FrontTens.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.FrontTens = Convert.ToDouble(textBox.Text);
                        frontTensCalculated.Text = (TextBoxBackingFields.FrontTens * Convert.ToDouble(Properties.Settings.Default["FrontTens"])).ToString("C");
                    }
                    break;
                case "tensBackSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.BackTens = 0;
                        backTensCalculated.Text = TextBoxBackingFields.BackTens.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.BackTens = Convert.ToDouble(textBox.Text);
                        backTensCalculated.Text = (TextBoxBackingFields.BackTens * Convert.ToDouble(Properties.Settings.Default["BackTens"])).ToString("C");
                    }
                    break;
                case "twentiesFrontSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.FrontTwenties = 0;
                        frontTwentiesCalculated.Text = TextBoxBackingFields.FrontTwenties.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.FrontTwenties = Convert.ToDouble(textBox.Text);
                        frontTwentiesCalculated.Text = (TextBoxBackingFields.FrontTwenties * Convert.ToDouble(Properties.Settings.Default["FrontTwenties"])).ToString("C");
                    }
                    break;
                case "twentiesBackSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.BackTwenties = 0;
                        backTwentiesCalculated.Text = TextBoxBackingFields.BackTwenties.ToString("C");
                    }
                    else
                    {
                        TextBoxBackingFields.BackTwenties = Convert.ToDouble(textBox.Text);
                        backTwentiesCalculated.Text = (TextBoxBackingFields.BackTwenties * Convert.ToDouble(Properties.Settings.Default["BackTwenties"])).ToString("C");
                    }
                    break;
                case "officeSafe":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.OfficeSafe = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.OfficeSafe = Convert.ToDouble(textBox.Text);
                        //officeSafe.Text = TextBoxBackingFields.OfficeSafe.ToString();
                    }
                    break;
                case "dieselDrawer":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.DieselDrawer = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.DieselDrawer = Convert.ToDouble(textBox.Text);
                        //dieselDrawer.Text = TextBoxBackingFields.DieselDrawer.ToString();
                    }
                    break;
                case "gasDrawer":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.GasDrawer = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.GasDrawer = Convert.ToDouble(textBox.Text);
                        //gasDrawer.Text = TextBoxBackingFields.GasDrawer.ToString();
                    }
                    break;
                case "gasCigs":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.GasCigs = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.GasCigs = Convert.ToDouble(textBox.Text);
                        //gasCigs.Text = TextBoxBackingFields.GasCigs.ToString();
                    }
                    break;
                case "dieselCigs":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.DieselCigs = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.DieselCigs = Convert.ToDouble(textBox.Text);
                        //dieselCigs.Text = TextBoxBackingFields.DieselCigs.ToString();
                    }
                    break;
                case "mclaneCigs":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.MclaneCigs = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.MclaneCigs = Convert.ToDouble(textBox.Text);
                        //mclaneCigs.Text = TextBoxBackingFields.MclaneCigs.ToString();
                    }
                    break;
                case "officeCigs":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.OfficeCigs = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.OfficeCigs = Convert.ToDouble(textBox.Text);
                        //officeCigs.Text = TextBoxBackingFields.OfficeCigs.ToString();
                    }
                    break;
                case "cashierVariance1":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierVariance1 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierVariance1 = Convert.ToDouble(textBox.Text);
                        //cashierVariance1.Text = TextBoxBackingFields.CashierVariance1.ToString();
                    }
                    break;
                case "cashierVariance2":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierVariance2 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierVariance2 = Convert.ToDouble(textBox.Text);
                        //cashierVariance2.Text = TextBoxBackingFields.CashierVariance2.ToString();
                    }
                    break;
                case "cashierVariance3":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierVariance3 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierVariance3 = Convert.ToDouble(textBox.Text);
                        //cashierVariance3.Text = TextBoxBackingFields.CashierVariance3.ToString();
                    }
                    break;
                case "cashierVariance4":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierVariance4 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierVariance4 = Convert.ToDouble(textBox.Text);
                        //cashierVariance4.Text = TextBoxBackingFields.CashierVariance4.ToString();
                    }
                    break;
                case "cashierVariance5":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierVariance5 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierVariance5 = Convert.ToDouble(textBox.Text);
                        //cashierVariance5.Text = TextBoxBackingFields.CashierVariance5.ToString();
                    }
                    break;
                case "cashierVariance6":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierVariance6 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierVariance6 = Convert.ToDouble(textBox.Text);
                        //cashierVariance6.Text = TextBoxBackingFields.CashierVariance6.ToString();
                    }
                    break;
                case "cashierVariance7":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierVariance7 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierVariance7 = Convert.ToDouble(textBox.Text);
                        //cashierVariance7.Text = TextBoxBackingFields.CashierVariance7.ToString();
                    }
                    break;
                case "cashierVariance8":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierVariance8 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierVariance8 = Convert.ToDouble(textBox.Text);
                        //cashierVariance8.Text = TextBoxBackingFields.CashierVariance8.ToString();
                    }
                    break;
                case "cashierVariance9":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierVariance9 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierVariance9 = Convert.ToDouble(textBox.Text);
                        //cashierVariance9.Text = TextBoxBackingFields.CashierVariance9.ToString();
                    }
                    break;
                case "cashierVariance10":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierVariance10 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierVariance10 = Convert.ToDouble(textBox.Text);
                        //cashierVariance10.Text = TextBoxBackingFields.CashierVariance10.ToString();
                    }
                    break;
                case "cashierDrops1":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierDrops1 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierDrops1 = Convert.ToDouble(textBox.Text);
                        //cashierDrops1.Text = TextBoxBackingFields.CashierDrops1.ToString();
                    }
                    break;
                case "cashierDrops2":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierDrops2 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierDrops2 = Convert.ToDouble(textBox.Text);
                        //cashierDrops2.Text = TextBoxBackingFields.CashierDrops2.ToString();
                    }
                    break;
                case "cashierDrops3":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierDrops3 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierDrops3 = Convert.ToDouble(textBox.Text);
                        //cashierDrops3.Text = TextBoxBackingFields.CashierDrops3.ToString();
                    }
                    break;
                case "cashierDrops4":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierDrops4 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierDrops4 = Convert.ToDouble(textBox.Text);
                        //cashierDrops4.Text = TextBoxBackingFields.CashierDrops4.ToString();
                    }
                    break;
                case "cashierDrops5":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierDrops5 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierDrops5 = Convert.ToDouble(textBox.Text);
                        //cashierDrops5.Text = TextBoxBackingFields.CashierDrops5.ToString();
                    }
                    break;
                case "cashierDrops6":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierDrops6 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierDrops6 = Convert.ToDouble(textBox.Text);
                        //cashierDrops6.Text = TextBoxBackingFields.CashierDrops6.ToString();
                    }
                    break;
                case "cashierDrops7":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierDrops7 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierDrops7 = Convert.ToDouble(textBox.Text);
                        //cashierDrops7.Text = TextBoxBackingFields.CashierDrops7.ToString();
                    }
                    break;
                case "cashierDrops8":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierDrops8 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierDrops8 = Convert.ToDouble(textBox.Text);
                        //cashierDrops8.Text = TextBoxBackingFields.CashierDrops8.ToString();
                    }
                    break;
                case "cashierDrops9":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierDrops9 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierDrops9 = Convert.ToDouble(textBox.Text);
                        //cashierDrops9.Text = TextBoxBackingFields.CashierDrops9.ToString();
                    }
                    break;
                case "cashierDrops10":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierDrops10 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierDrops10 = Convert.ToDouble(textBox.Text);
                        //cashierDrops10.Text = TextBoxBackingFields.CashierDrops10.ToString();
                    }
                    break;
                case "cashierChange1":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierChange1 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierChange1 = Convert.ToDouble(textBox.Text);
                        //cashierChange1.Text = TextBoxBackingFields.CashierChange1.ToString();
                    }
                    break;
                case "cashierChange2":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierChange2 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierChange2 = Convert.ToDouble(textBox.Text);
                        //cashierChange2.Text = TextBoxBackingFields.CashierChange2.ToString();
                    }
                    break;
                case "cashierChange3":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierChange3 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierChange3 = Convert.ToDouble(textBox.Text);
                        //cashierChange3.Text = TextBoxBackingFields.CashierChange3.ToString();
                    }
                    break;
                case "cashierChange4":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierChange4 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierChange4 = Convert.ToDouble(textBox.Text);
                        //cashierChange4.Text = TextBoxBackingFields.CashierChange4.ToString();
                    }
                    break;
                case "cashierChange5":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierChange5 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierChange5 = Convert.ToDouble(textBox.Text);
                        //cashierChange5.Text = TextBoxBackingFields.CashierChange5.ToString();
                    }
                    break;
                case "cashierChange6":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierChange6 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierChange6 = Convert.ToDouble(textBox.Text);
                        //cashierChange6.Text = TextBoxBackingFields.CashierChange6.ToString();
                    }
                    break;
                case "cashierChange7":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierChange7 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierChange7 = Convert.ToDouble(textBox.Text);
                        //cashierChange7.Text = TextBoxBackingFields.CashierChange7.ToString();
                    }
                    break;
                case "cashierChange8":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierChange8 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierChange8 = Convert.ToDouble(textBox.Text);
                        //cashierChange8.Text = TextBoxBackingFields.CashierChange8.ToString();
                    }
                    break;
                case "cashierChange9":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierChange9 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierChange9 = Convert.ToDouble(textBox.Text);
                        //cashierChange9.Text = TextBoxBackingFields.CashierChange9.ToString();
                    }
                    break;
                case "cashierChange10":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.CashierChange10 = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.CashierChange10 = Convert.ToDouble(textBox.Text);
                        //cashierChange10.Text = TextBoxBackingFields.CashierChange10.ToString();
                    }
                    break;
                case "cashierChecks":
                    if (textBox.Text == "" || textBox.Text == "." || textBox.Text == "-" || textBox.Text.Contains(".") && textBox.Text.Contains("-") && !Regex.IsMatch(textBox.Text, @"\d"))
                    {
                        TextBoxBackingFields.Checks = 0;
                    }
                    else
                    {
                        TextBoxBackingFields.Checks = Convert.ToDouble(textBox.Text);
                        //cashierChecks.Text = TextBoxBackingFields.Checks.ToString();
                    }
                    break;
            }
            TextBoxBackingFields.LowFeedstock = lowFeedstock.Text;
            TextBoxBackingFields.HighFeedstock = highFeedstock.Text;
            TextBoxBackingFields.Diesel = radiantDiesel.Text;
            TextBoxBackingFields.DieselFiscal5 = fiscalDiesel.Text;
            TextBoxBackingFields.DieselKer1 = dslKer1.Text;
            TextBoxBackingFields.UltE852 = ultE851.Text;
            TextBoxBackingFields.UnleadRace = unleadRace.Text;
            TextBoxBackingFields.Def3 = def3.Text;
            TextBoxBackingFields.DefRec90 = defRec90.Text;


            TextBoxBackingFields.CashierName1 = cashierName1.Text;
            TextBoxBackingFields.CashierName2 = cashierName2.Text;
            TextBoxBackingFields.CashierName3 = cashierName3.Text;
            TextBoxBackingFields.CashierName4 = cashierName4.Text;
            TextBoxBackingFields.CashierName5 = cashierName5.Text;
            TextBoxBackingFields.CashierName6 = cashierName6.Text;
            TextBoxBackingFields.CashierName7 = cashierName7.Text;
            TextBoxBackingFields.CashierName8 = cashierName8.Text;
            TextBoxBackingFields.CashierName9 = cashierName9.Text;
            TextBoxBackingFields.CashierName10 = cashierName10.Text;

            TextBoxBackingFields.OnlinePaidOut = onlinePaidout.Text;
            TextBoxBackingFields.OnlineSales = onlineSales.Text;
            TextBoxBackingFields.InstantPaidOut = instantPaidout.Text;
            TextBoxBackingFields.InstantSales = instantSales.Text;

            TextBoxBackingFields.StorePaidOut = storePaidOut.Text;
            TextBoxBackingFields.AmbestRedeem = ambestRedeem.Text;
            TextBoxBackingFields.Incentive = employeeIncentive.Text;
            TextBoxBackingFields.Coupons = coupons.Text;
            TextBoxBackingFields.Overrun = overrun.Text;
            TextBoxBackingFields.Reimbursement = reimbursement.Text;

            TextBoxBackingFields.FuelType1 = fuelPicker1.Text;
            TextBoxBackingFields.BillOfLading1 = billOfLading1.Text;
            TextBoxBackingFields.NetFuel1 = netFuel1.Text;
            TextBoxBackingFields.GrossFuel1 = grossFuel1.Text;

            TextBoxBackingFields.FuelType2 = fuelPicker2.Text;
            TextBoxBackingFields.BillOfLading2 = billOfLading2.Text;
            TextBoxBackingFields.NetFuel2 = netFuel2.Text;
            TextBoxBackingFields.GrossFuel2 = grossFuel2.Text;

            TextBoxBackingFields.FuelType3 = fuelPicker3.Text;
            TextBoxBackingFields.BillOfLading3 = billOfLading3.Text;
            TextBoxBackingFields.NetFuel3 = netFuel3.Text;
            TextBoxBackingFields.GrossFuel3 = grossFuel3.Text;

            TextBoxBackingFields.FuelType4 = fuelPicker4.Text;
            TextBoxBackingFields.BillOfLading4 = billOfLading4.Text;
            TextBoxBackingFields.NetFuel4 = netFuel4.Text;
            TextBoxBackingFields.GrossFuel4 = grossFuel4.Text;

            TextBoxBackingFields.FuelType5 = fuelPicker5.Text;
            TextBoxBackingFields.BillOfLading5 = billOfLading5.Text;
            TextBoxBackingFields.NetFuel5 = netFuel5.Text;
            TextBoxBackingFields.GrossFuel5 = grossFuel5.Text;

            TextBoxBackingFields.FuelType6 = fuelPicker6.Text;
            TextBoxBackingFields.BillOfLading6 = billOfLading6.Text;
            TextBoxBackingFields.NetFuel6 = netFuel6.Text;
            TextBoxBackingFields.GrossFuel6 = grossFuel6.Text;

            TextBoxBackingFields.FuelType7 = fuelPicker7.Text;
            TextBoxBackingFields.BillOfLading7 = billOfLading7.Text;
            TextBoxBackingFields.NetFuel7 = netFuel7.Text;
            TextBoxBackingFields.GrossFuel7 = grossFuel7.Text;

            TextBoxBackingFields.FuelType8 = fuelPicker8.Text;
            TextBoxBackingFields.BillOfLading8 = billOfLading8.Text;
            TextBoxBackingFields.NetFuel8 = netFuel8.Text;
            TextBoxBackingFields.GrossFuel8 = grossFuel8.Text;

            CalculateTotals();
        }
        private void CalculateTotals()
        {
            double cashierChangeTotalDouble = TextBoxBackingFields.CashierChange1 + TextBoxBackingFields.CashierChange2 +
                                              TextBoxBackingFields.CashierChange3 + TextBoxBackingFields.CashierChange4 +
                                              TextBoxBackingFields.CashierChange5 + TextBoxBackingFields.CashierChange6 +
                                              TextBoxBackingFields.CashierChange7 + TextBoxBackingFields.CashierChange8 +
                                              TextBoxBackingFields.CashierChange9 + TextBoxBackingFields.CashierChange10;
            TextBoxBackingFields.ChangeTotal = cashierChangeTotalDouble;
            cashierChangeTotal.Text = cashierChangeTotalDouble.ToString("C");
            cashierChangeBroughtToSafeTotals.Text = cashierChangeTotal.Text;

            double SafeTotalsCalculated =
                Convert.ToDouble(backPenniesCalculated.Text.Trim('$', '(', ')')) + Convert.ToDouble(frontPenniesCalculated.Text.Trim('$', '(', ')')) +
                Convert.ToDouble(backNicklesCalculated.Text.Trim('$', '(', ')')) + Convert.ToDouble(frontNicklesCalculated.Text.Trim('$', '(', ')')) +
                Convert.ToDouble(backDimesCalculated.Text.Trim('$', '(', ')')) + Convert.ToDouble(frontDimesCalculated.Text.Trim('$', '(', ')')) +
                Convert.ToDouble(backQuartersCalculated.Text.Trim('$', '(', ')')) + Convert.ToDouble(frontQuartersCalculated.Text.Trim('$', '(', ')')) +
                Convert.ToDouble(backOnesCalculated.Text.Trim('$', '(', ')')) + Convert.ToDouble(frontOnesCalculated.Text.Trim('$', '(', ')')) +
                Convert.ToDouble(backFivesCalculated.Text.Trim('$', '(', ')')) + Convert.ToDouble(frontFivesCalculated.Text.Trim('$', '(', ')')) +
                Convert.ToDouble(backTensCalculated.Text.Trim('$', '(', ')')) + Convert.ToDouble(frontTensCalculated.Text.Trim('$', '(', ')')) +
                Convert.ToDouble(backTwentiesCalculated.Text.Trim('$', '(', ')')) + Convert.ToDouble(frontTwentiesCalculated.Text.Trim('$', '(', ')'));


            SafeTotalsCalculated += TextBoxBackingFields.OfficeSafe + TextBoxBackingFields.GasDrawer +
                                    TextBoxBackingFields.DieselDrawer + TextBoxBackingFields.ChangeTotal;
            TextBoxBackingFields.TotalSafe = SafeTotalsCalculated;
            
            TotalSafe.Text = SafeTotalsCalculated.ToString("C");

            double cashierDropsDouble = TextBoxBackingFields.CashierDrops1 + TextBoxBackingFields.CashierDrops2 +
                                         TextBoxBackingFields.CashierDrops3 + TextBoxBackingFields.CashierDrops4 +
                                         TextBoxBackingFields.CashierDrops5 + TextBoxBackingFields.CashierDrops6 +
                                         TextBoxBackingFields.CashierDrops7 + TextBoxBackingFields.CashierDrops8 +
                                         TextBoxBackingFields.CashierDrops9 + TextBoxBackingFields.CashierDrops10;
            TextBoxBackingFields.DropsTotal = cashierDropsDouble;
            cashierDropsTotal.Text = cashierDropsDouble.ToString("C");

            double cashierVarianceDouble = TextBoxBackingFields.CashierVariance1 + TextBoxBackingFields.CashierVariance2 +
                                           TextBoxBackingFields.CashierVariance3 + TextBoxBackingFields.CashierVariance4 +
                                           TextBoxBackingFields.CashierVariance5 + TextBoxBackingFields.CashierVariance6 +
                                           TextBoxBackingFields.CashierVariance7 + TextBoxBackingFields.CashierVariance8 +
                                           TextBoxBackingFields.CashierVariance9 + TextBoxBackingFields.CashierVariance10;
            TextBoxBackingFields.VarianceTotal = cashierVarianceDouble;
            cashierVarianceTotal.Text = cashierVarianceDouble.ToString("C", culture);

            double BankDepositCalculated = TextBoxBackingFields.Checks + cashierDropsDouble;
            TextBoxBackingFields.BankDeposit = BankDepositCalculated;
            bankDeposit.Text = BankDepositCalculated.ToString("C");

            double cigTotalDouble = TextBoxBackingFields.DieselCigs + TextBoxBackingFields.GasCigs +
                                    TextBoxBackingFields.MclaneCigs + TextBoxBackingFields.OfficeCigs;
            totalCigs.Text = cigTotalDouble.ToString();
            TextBoxBackingFields.TotalCigs = cigTotalDouble;
        }
        private void textboxInputChecker(object sender, KeyEventArgs e)
        {
            TextBox txbx = (TextBox)sender;


            if ((e.KeyValue >= 48 && e.KeyValue <= 57 || e.KeyValue >= 96 && e.KeyValue <= 105 || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Back || e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Back) && e.Shift == false)
            {
                if (txbx.Text.Contains('.') && e.KeyCode == Keys.OemPeriod || txbx.Text.Contains('.') && e.KeyCode == Keys.Decimal || txbx.Text.Contains('-') && e.KeyCode == Keys.OemMinus || txbx.SelectionStart != 0 && e.KeyCode == Keys.OemMinus || txbx.SelectionStart != 0 && e.KeyCode == Keys.Subtract || txbx.SelectionStart <= txbx.Text.IndexOf('-') && e.KeyValue >= 48 && e.KeyValue <= 57 || txbx.SelectionStart <= txbx.Text.IndexOf('-') && e.KeyValue >= 96 && e.KeyValue <= 105 || txbx.SelectionStart <= txbx.Text.IndexOf('-') && e.KeyCode == Keys.Subtract|| txbx.SelectionStart == 0 && txbx.Text.Contains('-') && e.KeyCode == Keys.Decimal || txbx.SelectionStart == 0 && txbx.Text.Contains('-') && e.KeyCode == Keys.OemPeriod)
                {
                    
                    e.SuppressKeyPress = true;
                }
                else
                {
                    e.SuppressKeyPress = false;
                }
            }
            else
            {
                e.SuppressKeyPress = true;
                switch (txbx.Name)
                {
                    case "cashierName1":
                    case "cashierName2":
                    case "cashierName3":
                    case "cashierName4":
                    case "cashierName5":
                    case "cashierName6":
                    case "cashierName7":
                    case "cashierName8":
                    case "cashierName9":
                    case "cashierName10":
                        e.SuppressKeyPress = false;
                        break;
                }
            }
        }

        private void Serialize()
        {
            Stream objStream = new FileStream(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["BinFilePath"].ToString() + Convert.ToDateTime(currentPWSLabel.Text).ToString("MM-dd-yyy") + " PWS.bin", FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            
            formValues = new Form_Values();

            SerializeFormValues();

            binaryFormatter.Serialize(objStream, formValues);
            objStream.Close();
        }
        private void DeserializeFormValues()
        {
            cashierChange1.Text = formValues.cashierValues[0].CashierChange;
            cashierChange2.Text = formValues.cashierValues[1].CashierChange;
            cashierChange3.Text = formValues.cashierValues[2].CashierChange;
            cashierChange4.Text = formValues.cashierValues[3].CashierChange;
            cashierChange5.Text = formValues.cashierValues[4].CashierChange;
            cashierChange6.Text = formValues.cashierValues[5].CashierChange;
            cashierChange7.Text = formValues.cashierValues[6].CashierChange;
            cashierChange8.Text = formValues.cashierValues[7].CashierChange;
            cashierChange9.Text = formValues.cashierValues[8].CashierChange;
            cashierChange10.Text = formValues.cashierValues[9].CashierChange;

            cashierDrops1.Text = formValues.cashierValues[0].CashierDrops;
            cashierDrops2.Text = formValues.cashierValues[1].CashierDrops;
            cashierDrops3.Text = formValues.cashierValues[2].CashierDrops;
            cashierDrops4.Text = formValues.cashierValues[3].CashierDrops;
            cashierDrops5.Text = formValues.cashierValues[4].CashierDrops;
            cashierDrops6.Text = formValues.cashierValues[5].CashierDrops;
            cashierDrops7.Text = formValues.cashierValues[6].CashierDrops;
            cashierDrops8.Text = formValues.cashierValues[7].CashierDrops;
            cashierDrops9.Text = formValues.cashierValues[8].CashierDrops;
            cashierDrops10.Text = formValues.cashierValues[9].CashierDrops;

            cashierName1.Text = formValues.cashierValues[0].CashierName;
            cashierName2.Text = formValues.cashierValues[1].CashierName;
            cashierName3.Text = formValues.cashierValues[2].CashierName;
            cashierName4.Text = formValues.cashierValues[3].CashierName;
            cashierName5.Text = formValues.cashierValues[4].CashierName;
            cashierName6.Text = formValues.cashierValues[5].CashierName;
            cashierName7.Text = formValues.cashierValues[6].CashierName;
            cashierName8.Text = formValues.cashierValues[7].CashierName;
            cashierName9.Text = formValues.cashierValues[8].CashierName;
            cashierName10.Text = formValues.cashierValues[9].CashierName;

            cashierVariance1.Text = formValues.cashierValues[0].CashierVariance;
            cashierVariance2.Text = formValues.cashierValues[1].CashierVariance;
            cashierVariance3.Text = formValues.cashierValues[2].CashierVariance;
            cashierVariance4.Text = formValues.cashierValues[3].CashierVariance;
            cashierVariance5.Text = formValues.cashierValues[4].CashierVariance;
            cashierVariance6.Text = formValues.cashierValues[5].CashierVariance;
            cashierVariance7.Text = formValues.cashierValues[6].CashierVariance;
            cashierVariance8.Text = formValues.cashierValues[7].CashierVariance;
            cashierVariance9.Text = formValues.cashierValues[8].CashierVariance;
            cashierVariance10.Text = formValues.cashierValues[9].CashierVariance;

            bankDeposit.Text = formValues.cashierTotals.BankDeposit;
            cashierChangeTotal.Text = formValues.cashierTotals.CashierChangeTotals;
            cashierChecks.Text = formValues.cashierTotals.CashierChecks;
            cashierDropsTotal.Text = formValues.cashierTotals.CashierDropsTotals;
            cashierVarianceTotal.Text = formValues.cashierTotals.CashierVarianceTotals;

            dieselCigs.Text = formValues.cigaretteTotals.DieselCigs;
            gasCigs.Text = formValues.cigaretteTotals.GasCigs;
            officeCigs.Text = formValues.cigaretteTotals.OfficeCigs;
            mclaneCigs.Text = formValues.cigaretteTotals.MclaneCigs;

            instantPaidout.Text = formValues.lotteryTotals.InstantPaidOut;
            instantSales.Text = formValues.lotteryTotals.InstantSales;
            onlinePaidout.Text = formValues.lotteryTotals.OnlinePaidOut;
            onlineSales.Text = formValues.lotteryTotals.OnlineSales;

            fuelPicker1.Text = formValues.fuelDeliveries[0].FuelType;
            billOfLading1.Text = formValues.fuelDeliveries[0].BillOfLading;
            netFuel1.Text = formValues.fuelDeliveries[0].NetAmount;
            grossFuel1.Text = formValues.fuelDeliveries[0].GrossAmount;

            fuelPicker2.Text = formValues.fuelDeliveries[1].FuelType;
            billOfLading2.Text = formValues.fuelDeliveries[1].BillOfLading;
            netFuel2.Text = formValues.fuelDeliveries[1].NetAmount;
            grossFuel2.Text = formValues.fuelDeliveries[1].GrossAmount;

            fuelPicker3.Text = formValues.fuelDeliveries[2].FuelType;
            billOfLading3.Text = formValues.fuelDeliveries[2].BillOfLading;
            netFuel3.Text = formValues.fuelDeliveries[2].NetAmount;
            grossFuel3.Text = formValues.fuelDeliveries[2].GrossAmount;

            fuelPicker4.Text = formValues.fuelDeliveries[3].FuelType;
            billOfLading4.Text = formValues.fuelDeliveries[3].BillOfLading;
            netFuel4.Text = formValues.fuelDeliveries[3].NetAmount;
            grossFuel4.Text = formValues.fuelDeliveries[3].GrossAmount;

            fuelPicker5.Text = formValues.fuelDeliveries[4].FuelType;
            billOfLading5.Text = formValues.fuelDeliveries[4].BillOfLading;
            netFuel5.Text = formValues.fuelDeliveries[4].NetAmount;
            grossFuel5.Text = formValues.fuelDeliveries[4].GrossAmount;

            fuelPicker6.Text = formValues.fuelDeliveries[5].FuelType;
            billOfLading6.Text = formValues.fuelDeliveries[5].BillOfLading;
            netFuel6.Text = formValues.fuelDeliveries[5].NetAmount;
            grossFuel6.Text = formValues.fuelDeliveries[5].GrossAmount;

            fuelPicker7.Text = formValues.fuelDeliveries[6].FuelType;
            billOfLading7.Text = formValues.fuelDeliveries[6].BillOfLading;
            netFuel7.Text = formValues.fuelDeliveries[6].NetAmount;
            grossFuel7.Text = formValues.fuelDeliveries[6].GrossAmount;

            fuelPicker8.Text = formValues.fuelDeliveries[7].FuelType;
            billOfLading8.Text = formValues.fuelDeliveries[7].BillOfLading;
            netFuel8.Text = formValues.fuelDeliveries[7].NetAmount;
            grossFuel8.Text = formValues.fuelDeliveries[7].GrossAmount;

            ambestRedeem.Text = formValues.miscSales.AmbestRedemption;
            coupons.Text = formValues.miscSales.Coupons;
            employeeIncentive.Text = formValues.miscSales.EmployeeIncentive;
            storePaidOut.Text = formValues.miscSales.StorePaidOut;
            overrun.Text = formValues.miscSales.Overrun;
            reimbursement.Text = formValues.miscSales.Reimbursement;

            highFeedstock.Text = formValues.totalizers.HighFeedstock;
            lowFeedstock.Text = formValues.totalizers.LowFeedstock;
            radiantDiesel.Text = formValues.totalizers.Diesel;
            fiscalDiesel.Text = formValues.totalizers.DieselFiscal;
            dslKer1.Text = formValues.totalizers.DieselKer1;
            ultE851.Text = formValues.totalizers.UltE852;
            unleadRace.Text = formValues.totalizers.UnleadRace;
            def3.Text = formValues.totalizers.Def3;
            defRec90.Text = formValues.totalizers.DefRec90;

            penniesBackSafe.Text = formValues.safeTotals.PenniesDiesel;
            nicklesBackSafe.Text = formValues.safeTotals.NicklesDiesel;
            dimesBackSafe.Text = formValues.safeTotals.DimesDiesel;
            quartersBackSafe.Text = formValues.safeTotals.QuartersDiesel;
            onesBackSafe.Text = formValues.safeTotals.OnesDiesel;
            fivesBackSafe.Text = formValues.safeTotals.FivesDiesel;
            tensBackSafe.Text = formValues.safeTotals.TensDiesel;
            twentiesBackSafe.Text = formValues.safeTotals.TwentiesDiesel;

            penniesFrontSafe.Text = formValues.safeTotals.PenniesGas;
            nicklesFrontSafe.Text = formValues.safeTotals.NicklesGas;
            dimesFrontSafe.Text = formValues.safeTotals.DimesGas;
            quartersFrontSafe.Text = formValues.safeTotals.QuartersGas;
            onesFrontSafe.Text = formValues.safeTotals.OnesGas;
            fivesFrontSafe.Text = formValues.safeTotals.FivesGas;
            tensFrontSafe.Text = formValues.safeTotals.TensGas;
            twentiesFrontSafe.Text = formValues.safeTotals.TwentiesGas;

            cashierChangeTotal.Text = formValues.safeTotals.Cashierchange;
            dieselDrawer.Text = formValues.safeTotals.DieselDrawer;
            gasDrawer.Text = formValues.safeTotals.GasDrawer;
            officeSafe.Text = formValues.safeTotals.OfficeSafe;
            TotalSafe.Text = formValues.safeTotals.TotalSafe;

            TextBoxBackingFields.UnleadedEthanolDollars = formValues.pumpTests.UnleadedEthanolDollars;
            TextBoxBackingFields.PremiumEthanolDollars = formValues.pumpTests.PremiumEthanolDollars;
            TextBoxBackingFields.MidgradeEthanolDollars = formValues.pumpTests.MidgradeEthanolDollars;
            TextBoxBackingFields.DefDollars = formValues.pumpTests.DefDollars;
            TextBoxBackingFields.UltraDollars = formValues.pumpTests.UltraDollars;
            TextBoxBackingFields.DieselDollars = formValues.pumpTests.DieselDollars;
            pumpTests.unleadedDollars.Text = formValues.pumpTests.UnleadedEthanolDollars;
            pumpTests.premiumDollars.Text = formValues.pumpTests.PremiumEthanolDollars;
            pumpTests.midgradeDollars.Text = formValues.pumpTests.MidgradeEthanolDollars;
            pumpTests.defDollars.Text = formValues.pumpTests.DefDollars;
            pumpTests.ultraDollars.Text = formValues.pumpTests.UltraDollars;
            pumpTests.dieselDollars.Text = formValues.pumpTests.DieselDollars;

            TextBoxBackingFields.UnleadedEthanolUnits = formValues.pumpTests.UnleadedEthanolUnits;
            TextBoxBackingFields.PremiumEthanolUnits = formValues.pumpTests.PremiumEthanolUnits;
            TextBoxBackingFields.MidgradeEthanolUnits = formValues.pumpTests.MidgradeEthanolUnits;
            TextBoxBackingFields.DefUnits = formValues.pumpTests.DefUnits;
            TextBoxBackingFields.UltraUnits = formValues.pumpTests.UltraUnits;
            TextBoxBackingFields.DieselUnits = formValues.pumpTests.DieselUnits;
            pumpTests.unleadedUnits.Text = formValues.pumpTests.UnleadedEthanolUnits;
            pumpTests.premiumUnits.Text = formValues.pumpTests.PremiumEthanolUnits;
            pumpTests.midgradeUnits.Text = formValues.pumpTests.MidgradeEthanolUnits;
            pumpTests.defUnits.Text = formValues.pumpTests.DefUnits;
            pumpTests.ultraUnits.Text = formValues.pumpTests.UltraUnits;
            pumpTests.dieselUnits.Text = formValues.pumpTests.DieselUnits;
        }
        private void SerializeFormValues()
        {
            formValues.cashierValues[0].CashierChange = cashierChange1.Text;
            formValues.cashierValues[1].CashierChange = cashierChange2.Text;
            formValues.cashierValues[2].CashierChange = cashierChange3.Text;
            formValues.cashierValues[3].CashierChange = cashierChange4.Text;
            formValues.cashierValues[4].CashierChange = cashierChange5.Text;
            formValues.cashierValues[5].CashierChange = cashierChange6.Text;
            formValues.cashierValues[6].CashierChange = cashierChange7.Text;
            formValues.cashierValues[7].CashierChange = cashierChange8.Text;
            formValues.cashierValues[8].CashierChange = cashierChange9.Text;
            formValues.cashierValues[9].CashierChange = cashierChange10.Text;

            formValues.cashierValues[0].CashierDrops = cashierDrops1.Text;
            formValues.cashierValues[1].CashierDrops = cashierDrops2.Text;
            formValues.cashierValues[2].CashierDrops = cashierDrops3.Text;
            formValues.cashierValues[3].CashierDrops = cashierDrops4.Text;
            formValues.cashierValues[4].CashierDrops = cashierDrops5.Text;
            formValues.cashierValues[5].CashierDrops = cashierDrops6.Text;
            formValues.cashierValues[6].CashierDrops = cashierDrops7.Text;
            formValues.cashierValues[7].CashierDrops = cashierDrops8.Text;
            formValues.cashierValues[8].CashierDrops = cashierDrops9.Text;
            formValues.cashierValues[9].CashierDrops = cashierDrops10.Text;

            formValues.cashierValues[0].CashierName = cashierName1.Text;
            formValues.cashierValues[1].CashierName = cashierName2.Text;
            formValues.cashierValues[2].CashierName = cashierName3.Text;
            formValues.cashierValues[3].CashierName = cashierName4.Text;
            formValues.cashierValues[4].CashierName = cashierName5.Text;
            formValues.cashierValues[5].CashierName = cashierName6.Text;
            formValues.cashierValues[6].CashierName = cashierName7.Text;
            formValues.cashierValues[7].CashierName = cashierName8.Text;
            formValues.cashierValues[8].CashierName = cashierName9.Text;
            formValues.cashierValues[9].CashierName = cashierName10.Text;

            formValues.cashierValues[0].CashierVariance = cashierVariance1.Text;
            formValues.cashierValues[1].CashierVariance = cashierVariance2.Text;
            formValues.cashierValues[2].CashierVariance = cashierVariance3.Text;
            formValues.cashierValues[3].CashierVariance = cashierVariance4.Text;
            formValues.cashierValues[4].CashierVariance = cashierVariance5.Text;
            formValues.cashierValues[5].CashierVariance = cashierVariance6.Text;
            formValues.cashierValues[6].CashierVariance = cashierVariance7.Text;
            formValues.cashierValues[7].CashierVariance = cashierVariance8.Text;
            formValues.cashierValues[8].CashierVariance = cashierVariance9.Text;
            formValues.cashierValues[9].CashierVariance = cashierVariance10.Text;

            formValues.cashierTotals.BankDeposit = bankDeposit.Text;
            formValues.cashierTotals.CashierChangeTotals = cashierChangeTotal.Text;
            formValues.cashierTotals.CashierChecks = cashierChecks.Text;
            formValues.cashierTotals.CashierDropsTotals = cashierDropsTotal.Text;
            formValues.cashierTotals.CashierVarianceTotals = cashierVarianceTotal.Text;

            formValues.cigaretteTotals.DieselCigs = dieselCigs.Text;
            formValues.cigaretteTotals.GasCigs = gasCigs.Text;
            formValues.cigaretteTotals.OfficeCigs = officeCigs.Text;
            formValues.cigaretteTotals.MclaneCigs = mclaneCigs.Text;

            formValues.lotteryTotals.InstantPaidOut = instantPaidout.Text;
            formValues.lotteryTotals.InstantSales = instantSales.Text;
            formValues.lotteryTotals.OnlinePaidOut = onlinePaidout.Text;
            formValues.lotteryTotals.OnlineSales = onlineSales.Text;

            formValues.fuelDeliveries[0].FuelType = fuelPicker1.Text;
            formValues.fuelDeliveries[0].BillOfLading = billOfLading1.Text;
            formValues.fuelDeliveries[0].NetAmount = netFuel1.Text;
            formValues.fuelDeliveries[0].GrossAmount = grossFuel1.Text;

            formValues.fuelDeliveries[1].FuelType = fuelPicker2.Text;
            formValues.fuelDeliveries[1].BillOfLading = billOfLading2.Text;
            formValues.fuelDeliveries[1].NetAmount = netFuel2.Text;
            formValues.fuelDeliveries[1].GrossAmount = grossFuel2.Text;

            formValues.fuelDeliveries[2].FuelType = fuelPicker3.Text;
            formValues.fuelDeliveries[2].BillOfLading = billOfLading3.Text;
            formValues.fuelDeliveries[2].NetAmount = netFuel3.Text;
            formValues.fuelDeliveries[2].GrossAmount = grossFuel3.Text;

            formValues.fuelDeliveries[3].FuelType = fuelPicker4.Text;
            formValues.fuelDeliveries[3].BillOfLading = billOfLading4.Text;
            formValues.fuelDeliveries[3].NetAmount = netFuel4.Text;
            formValues.fuelDeliveries[3].GrossAmount = grossFuel4.Text;

            formValues.fuelDeliveries[4].FuelType = fuelPicker5.Text;
            formValues.fuelDeliveries[4].BillOfLading = billOfLading5.Text;
            formValues.fuelDeliveries[4].NetAmount = netFuel5.Text;
            formValues.fuelDeliveries[4].GrossAmount = grossFuel5.Text;

            formValues.fuelDeliveries[5].FuelType = fuelPicker6.Text;
            formValues.fuelDeliveries[5].BillOfLading = billOfLading6.Text;
            formValues.fuelDeliveries[5].NetAmount = netFuel6.Text;
            formValues.fuelDeliveries[5].GrossAmount = grossFuel6.Text;

            formValues.fuelDeliveries[6].FuelType = fuelPicker7.Text;
            formValues.fuelDeliveries[6].BillOfLading = billOfLading7.Text;
            formValues.fuelDeliveries[6].NetAmount = netFuel7.Text;
            formValues.fuelDeliveries[6].GrossAmount = grossFuel7.Text;

            formValues.fuelDeliveries[7].FuelType = fuelPicker8.Text;
            formValues.fuelDeliveries[7].BillOfLading = billOfLading8.Text;
            formValues.fuelDeliveries[7].NetAmount = netFuel8.Text;
            formValues.fuelDeliveries[7].GrossAmount = grossFuel8.Text;

            formValues.miscSales.AmbestRedemption = ambestRedeem.Text;
            formValues.miscSales.Coupons = coupons.Text;
            formValues.miscSales.EmployeeIncentive = employeeIncentive.Text;
            formValues.miscSales.StorePaidOut = storePaidOut.Text;
            formValues.miscSales.Overrun = overrun.Text;
            formValues.miscSales.Reimbursement = reimbursement.Text;

            formValues.totalizers.HighFeedstock = highFeedstock.Text;
            formValues.totalizers.LowFeedstock = lowFeedstock.Text;
            formValues.totalizers.Diesel = radiantDiesel.Text;
            formValues.totalizers.DieselFiscal = fiscalDiesel.Text;
            formValues.totalizers.DieselKer1 = dslKer1.Text;
            formValues.totalizers.UltE852 = ultE851.Text;
            formValues.totalizers.UnleadRace = unleadRace.Text;
            formValues.totalizers.Def3 = def3.Text;
            formValues.totalizers.DefRec90 = defRec90.Text;

            formValues.safeTotals.PenniesDiesel = penniesBackSafe.Text;
            formValues.safeTotals.NicklesDiesel = nicklesBackSafe.Text;
            formValues.safeTotals.DimesDiesel = dimesBackSafe.Text;
            formValues.safeTotals.QuartersDiesel = quartersBackSafe.Text;
            formValues.safeTotals.OnesDiesel = onesBackSafe.Text;
            formValues.safeTotals.FivesDiesel = fivesBackSafe.Text;
            formValues.safeTotals.TensDiesel = tensBackSafe.Text;
            formValues.safeTotals.TwentiesDiesel = twentiesBackSafe.Text;

            formValues.safeTotals.PenniesGas = penniesFrontSafe.Text;
            formValues.safeTotals.NicklesGas = nicklesFrontSafe.Text;
            formValues.safeTotals.DimesGas = dimesFrontSafe.Text;
            formValues.safeTotals.QuartersGas = quartersFrontSafe.Text;
            formValues.safeTotals.OnesGas = onesFrontSafe.Text;
            formValues.safeTotals.FivesGas = fivesFrontSafe.Text;
            formValues.safeTotals.TensGas = tensFrontSafe.Text;
            formValues.safeTotals.TwentiesGas = twentiesFrontSafe.Text;

            formValues.safeTotals.Cashierchange = cashierChangeTotal.Text;
            formValues.safeTotals.DieselDrawer = dieselDrawer.Text;
            formValues.safeTotals.GasDrawer = gasDrawer.Text;
            formValues.safeTotals.OfficeSafe = officeSafe.Text;
            formValues.safeTotals.TotalSafe = TotalSafe.Text;


            formValues.pumpTests.UnleadedEthanolDollars = TextBoxBackingFields.UnleadedEthanolDollars;
            formValues.pumpTests.PremiumEthanolDollars = TextBoxBackingFields.PremiumEthanolDollars;
            formValues.pumpTests.MidgradeEthanolDollars = TextBoxBackingFields.MidgradeEthanolDollars;
            formValues.pumpTests.DefDollars = TextBoxBackingFields.DefDollars;
            formValues.pumpTests.UltraDollars = TextBoxBackingFields.UltraDollars;
            formValues.pumpTests.DieselDollars = TextBoxBackingFields.DieselDollars;

            formValues.pumpTests.UnleadedEthanolUnits = TextBoxBackingFields.UnleadedEthanolUnits;
            formValues.pumpTests.PremiumEthanolUnits = TextBoxBackingFields.PremiumEthanolUnits;
            formValues.pumpTests.MidgradeEthanolUnits = TextBoxBackingFields.MidgradeEthanolUnits;
            formValues.pumpTests.DefUnits = TextBoxBackingFields.DefUnits;
            formValues.pumpTests.UltraUnits = TextBoxBackingFields.UltraUnits;
            formValues.pumpTests.DieselUnits = TextBoxBackingFields.DieselUnits;
        }

        private void SavePWSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["BinFilePath"].ToString() + Convert.ToDateTime(currentPWSLabel.Text).ToString("MM-dd-yyy") + " PWS.bin"))
            {
                if (MessageBox.Show(this.Owner, "Saving this sheet will overwrite an existing PWS file.", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Serialize();
                }
            }
            else if (!File.Exists(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["BinFilePath"].ToString() + Convert.ToDateTime(currentPWSLabel.Text).ToString("MM-dd-yyy") + " PWS.bin"))
            {
                Serialize();
            }
        }

        private void OpenPWSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBoxBackingFields.ClearAllFields();
            DateTime date;
            if (dateForm.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Displaying a different PWS will clear your current form.\nDo you want to continue?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        date = Convert.ToDateTime(dateForm.pwsDate);
                        currentPWSLabel.Text = date.ToLongDateString();
                        foreach (TextBox textBox in Controls.OfType<TextBox>())
                        {
                            textBox.Text = "";
                        }
                        Stream objStreamDeSerialize = new FileStream(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["BinFilePath"].ToString() + Convert.ToDateTime(currentPWSLabel.Text).ToString("MM-dd-yyy") + " PWS.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                        formValues = (Form_Values)binaryFormatter.Deserialize(objStreamDeSerialize);

                        DeserializeFormValues();
                        TextBoxBackingFields.PaperworkDate = date;
                        objStreamDeSerialize.Close();
                    }
                    catch (FileNotFoundException exception)
                    {
                        MessageBox.Show("File does not exist for selected Paperwork Set");
                    }
                }
            }
        }
        private void SelectUponTab(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Select(0, textBox.Text.Length);
        }
        private void PrintPWSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PDFFormatter pdfFormatter = new PDFFormatter(false);
        }
        private void ChangeApplicationFilepathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default["RootFilePath"] = folderBrowserDialog1.SelectedPath.ToString() + "\\7 11 Paperwork Assistant\\";
                Properties.Settings.Default.Save();

                Directory.CreateDirectory(Properties.Settings.Default["RootFilePath"].ToString());
                Directory.CreateDirectory(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["PdfFilePath"].ToString());
                Directory.CreateDirectory(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["BinFilePath"].ToString());
                Directory.CreateDirectory(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["ExceptionFilePath"].ToString());
                Directory.CreateDirectory(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["TraceFilePath"].ToString());
                Directory.CreateDirectory(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["ImgFilePath"].ToString());
            }
        }

        private void ChangeTubes_Click(object sender, EventArgs e)
        {
            tubesForm.FrontOnes.Text = Properties.Settings.Default["FrontOnes"].ToString();
            tubesForm.FrontFives.Text = Properties.Settings.Default["FrontFives"].ToString();
            tubesForm.FrontTens.Text = Properties.Settings.Default["FrontTens"].ToString();
            tubesForm.FrontTwenties.Text = Properties.Settings.Default["FrontTwenties"].ToString();

            tubesForm.BackOnes.Text = Properties.Settings.Default["BackOnes"].ToString();
            tubesForm.BackFives.Text = Properties.Settings.Default["BackFives"].ToString();
            tubesForm.BackTens.Text = Properties.Settings.Default["BackTens"].ToString();
            tubesForm.BackTwenties.Text = Properties.Settings.Default["BackTwenties"].ToString();

            if(tubesForm.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default["FrontOnes"] = Convert.ToDouble(tubesForm.FrontOnes.Text);
                Properties.Settings.Default["FrontFives"] = Convert.ToDouble(tubesForm.FrontFives.Text);
                Properties.Settings.Default["FrontTens"] = Convert.ToDouble(tubesForm.FrontTens.Text);
                Properties.Settings.Default["FrontTwenties"] = Convert.ToDouble(tubesForm.FrontTwenties.Text);

                Properties.Settings.Default["BackOnes"] = Convert.ToDouble(tubesForm.BackOnes.Text);
                Properties.Settings.Default["BackFives"] = Convert.ToDouble(tubesForm.BackFives.Text);
                Properties.Settings.Default["BackTens"] = Convert.ToDouble(tubesForm.BackTens.Text);
                Properties.Settings.Default["BackTwenties"] = Convert.ToDouble(tubesForm.BackTwenties.Text);

                Properties.Settings.Default.Save();

                textChanged(onesFrontSafe, e);
                textChanged(fivesFrontSafe, e);
                textChanged(tensFrontSafe, e);
                textChanged(twentiesFrontSafe, e);

                textChanged(onesBackSafe, e);
                textChanged(fivesBackSafe, e);
                textChanged(tensBackSafe, e);
                textChanged(twentiesBackSafe, e);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (pumpTests.ShowDialog() == DialogResult.OK)
            {
                if (pumpTests.unleadedDollars.Text != "")
                {
                    TextBoxBackingFields.UnleadedEthanolDollars = pumpTests.unleadedDollars.Text;
                }
                else
                {
                    TextBoxBackingFields.UnleadedEthanolDollars = null;
                }
                if (pumpTests.midgradeDollars.Text != "")
                {
                    TextBoxBackingFields.MidgradeEthanolDollars = pumpTests.midgradeDollars.Text;
                }
                else
                {
                    TextBoxBackingFields.MidgradeEthanolDollars = null;
                }
                if(pumpTests.premiumDollars.Text != "")
                {
                    TextBoxBackingFields.PremiumEthanolDollars = pumpTests.premiumDollars.Text;
                }
                else
                {
                    TextBoxBackingFields.PremiumEthanolDollars = null;
                }
                if (pumpTests.ultraDollars.Text != "")
                {
                    TextBoxBackingFields.UltraDollars = pumpTests.ultraDollars.Text;
                }
                else
                {
                    TextBoxBackingFields.UltraDollars = null;
                }
                if (pumpTests.dieselDollars.Text != "")
                {
                    TextBoxBackingFields.DieselDollars = pumpTests.dieselDollars.Text;
                }
                else
                {
                    TextBoxBackingFields.DieselDollars = null;
                }
                if (pumpTests.defDollars.Text != "")
                {
                    TextBoxBackingFields.DefDollars = pumpTests.defDollars.Text;
                }
                else
                {
                    TextBoxBackingFields.DefDollars = null;
                }

                if (pumpTests.unleadedUnits.Text != "")
                {
                    TextBoxBackingFields.UnleadedEthanolUnits = pumpTests.unleadedUnits.Text;
                }
                else
                {
                    TextBoxBackingFields.UnleadedEthanolUnits = null;
                }
                if (pumpTests.midgradeUnits.Text != "")
                {
                    TextBoxBackingFields.MidgradeEthanolUnits = pumpTests.midgradeUnits.Text;
                }
                else
                {
                    TextBoxBackingFields.MidgradeEthanolUnits = null;
                }
                if (pumpTests.premiumUnits.Text != "")
                {
                    TextBoxBackingFields.PremiumEthanolUnits = pumpTests.premiumUnits.Text;
                }
                else
                {
                    TextBoxBackingFields.PremiumEthanolUnits = null;
                }
                if (pumpTests.ultraUnits.Text != "")
                {
                    TextBoxBackingFields.UltraUnits = pumpTests.ultraUnits.Text;
                }
                else
                {
                    TextBoxBackingFields.UltraUnits = null;
                }
                if (pumpTests.dieselUnits.Text != "")
                {
                    TextBoxBackingFields.DieselUnits = pumpTests.dieselUnits.Text;
                }
                else
                {
                    TextBoxBackingFields.DieselUnits = null;
                }
                if (pumpTests.defUnits.Text != "")
                {
                    TextBoxBackingFields.DefUnits = pumpTests.defUnits.Text;
                }
                else
                {
                    TextBoxBackingFields.DefUnits = null;
                }
            }
        }

        private void PrintPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PDFFormatter pdfFormatter = new PDFFormatter(true);
        }
    }
}
