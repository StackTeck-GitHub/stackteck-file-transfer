using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace StackTeck_File_Transfer
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
            Application.Run(new InputForm());
        }

        public static void SwitchBtnColors(Button btn)
        {
            Color back = btn.BackColor;
            Color fore = btn.ForeColor;

            btn.BackColor = fore;
            btn.ForeColor = back;
        }
    }
}
