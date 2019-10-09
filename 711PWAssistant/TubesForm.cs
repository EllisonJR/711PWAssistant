using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _711PWAssistant
{
    public partial class TubesForm : Form
    {
        public TubesForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void SelectUponTab(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Select(0, textBox.Text.Length);
        }
        private void textboxInputChecker(object sender, KeyEventArgs e)
        {
            TextBox txbx = (TextBox)sender;


            if ((e.KeyValue >= 48 && e.KeyValue <= 57 || e.KeyValue >= 96 && e.KeyValue <= 105 || e.KeyCode == Keys.Back || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Back) && e.Shift == false)
            {
                if (txbx.Text.Contains('.') && e.KeyCode == Keys.OemPeriod || txbx.Text.Contains('.') && e.KeyCode == Keys.Decimal || txbx.Text.Contains('-') && e.KeyCode == Keys.OemMinus || txbx.SelectionStart != 0 && e.KeyCode == Keys.OemMinus || txbx.SelectionStart != 0 && e.KeyCode == Keys.Subtract || txbx.SelectionStart <= txbx.Text.IndexOf('-') && e.KeyValue >= 48 && e.KeyValue <= 57 || txbx.SelectionStart <= txbx.Text.IndexOf('-') && e.KeyValue >= 96 && e.KeyValue <= 105 || txbx.SelectionStart <= txbx.Text.IndexOf('-') && e.KeyCode == Keys.Subtract || txbx.SelectionStart == 0 && txbx.Text.Contains('-') && e.KeyCode == Keys.Decimal || txbx.SelectionStart == 0 && txbx.Text.Contains('-') && e.KeyCode == Keys.OemPeriod)
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
    }
}
