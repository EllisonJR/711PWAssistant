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
    public partial class PWSDateForm : Form
    {
        public string pwsDate { get; set; }
        public PWSDateForm()
        {
            InitializeComponent();
        }

        private void retrievePWS_Click(object sender, EventArgs e)
        {
            pwsDate = pwsTimePicker.Value.ToString("MM-dd-yyyy");
            this.Hide();
            this.DialogResult = DialogResult.OK;
        }
    }
}
