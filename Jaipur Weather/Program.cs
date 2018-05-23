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
        private static JObject userData { get; set; }
        public static Object fileLock = new Object();

        static Form1 cls;

        public static void SetData()
        {
            lock (Program.fileLock)
            {
                string data = "";

                using (WebClient wc = new WebClient())
                {
                    data = wc.DownloadString("http://api.openweathermap.org/data/2.5/weather?id=1269515&units=metric&appid=4d302b00539441446f7736801e1bb1cc");
                }

                userData = JObject.Parse(data);
            }
        }

        public static void ShowData()
        {
            lock (Program.fileLock)
            {
                cls.chart1.Series["Temperature"].Points.AddXY("Jaipur", (int)userData["main"]["temp"]);
                cls.chart1.Series["Pressure"].Points.AddXY("Jaipur", (int)userData["main"]["pressure"]);
                cls.chart1.Series["Humidity"].Points.AddXY("Jaipur", (int)userData["main"]["humidity"]);
            }
        }

        public static void Set()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(10);

            var timer = new System.Threading.Timer((e) =>
            { Program.SetData(); }, null, startTimeSpan, periodTimeSpan);
        }
        
        public static void Show()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(90);

            var timer = new System.Threading.Timer((e) =>
            { Program.ShowData(); }, null, startTimeSpan, periodTimeSpan);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            cls = new Form1();
            Application.Run(cls);
        }
    }
}
