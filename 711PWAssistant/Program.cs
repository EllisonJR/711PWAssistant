using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;

namespace _711PWAssistant
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            try
            { 
                Application.Run(new Form1());
            }
            catch(Exception e)
            {
                DateTime date = new DateTime();
                string exception = e.Message.ToString();
                string stackTrace = e.StackTrace.ToString();

                File.WriteAllText(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["TraceFilePath"].ToString() + DateTime.Now.Millisecond + ".txt", stackTrace);
                File.WriteAllText(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["ExceptionFilePath"].ToString() + DateTime.Now.Millisecond + ".txt", exception);

                if (MessageBox.Show("The application ran into an error (Steven fucked up somewhere)." +
                    "\nThe program will now close and you'll likely have to re-enter the information into the form." +
                    "\nThis information has been logged.", "Crash Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK);
                {
                    Application.Exit();
                }
            }
        }
    }
}
