using System;
using System.Windows.Forms;

namespace Jaipur_Weather
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //cls = new Form1();
            Application.Run(new Form1());
        }
    }
}
