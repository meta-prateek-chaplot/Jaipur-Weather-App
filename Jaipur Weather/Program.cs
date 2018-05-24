using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

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
