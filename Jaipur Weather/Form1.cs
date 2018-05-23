using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jaipur_Weather
{
    public partial class Form1 : Form
    {
        //private static void ShowData()
        //{
        //    lock (Program.fileLock)
        //    {
        //        // provide data to chart variables
        //        Form1.chart1.Series["Temperature"].Points.AddXY("Jaipur", Program.userData["main"]["temp"]);
        //    }
        //}

        //public static void Show()
        //{
        //    var startTimeSpan = TimeSpan.Zero;
        //    var periodTimeSpan = TimeSpan.FromMinutes(1);

        //    var timer = new System.Threading.Timer((e) =>
        //    { Form1.ShowData(); }, null, startTimeSpan, periodTimeSpan);
        //}

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Set();
            System.Threading.Thread.Sleep(2 * 1000);
            Program.Show();
        }
    }
}
