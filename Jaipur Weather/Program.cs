using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Jaipur_Weather
{
    static class Program
    {
        private static JObject userData { get; set; }
        private static Object fileLock = new Object();

        private static void SetData()
        {
            string data = "";

            lock (Program.fileLock)
            {
                using (WebClient wc = new WebClient())
                {
                    data = wc.DownloadString("http://api.openweathermap.org/data/2.5/weather?id=1269515&units=metric&appid=4d302b00539441446f7736801e1bb1cc");
                }

                userData = JObject.Parse(data);
            }
        }

        public static void Set()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(30);

            var timer = new System.Threading.Timer((e) =>
            { Program.SetData(); }, null, startTimeSpan, periodTimeSpan);
        }

        // Repair
        private static void ShowData()
        {
            lock (Program.fileLock)
            {
                Console.WriteLine(Program.userData);
            }
        }

        public static void Show()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(5);

            var timer = new System.Threading.Timer((e) =>
            { Program.ShowData(); }, null, startTimeSpan, periodTimeSpan);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
