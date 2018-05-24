﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Jaipur_Weather
{
    public partial class Form1 : Form
    {
        private static JObject userData { get; set; }
        //private static Object fileLock = new Object();

        public Form1()
        {
            InitializeComponent();
        }

        private void GetData()
        {
            //if (InvokeRequired)
            //{
                //lock (fileLock)
                //{
                string data = "";

                using (WebClient wc = new WebClient())
                {
                    data = wc.DownloadString("http://api.openweathermap.org/data/2.5/weather?id=1269515&units=metric&appid=4d302b00539441446f7736801e1bb1cc");
                }

                Form1.userData = JObject.Parse(data);
                //}
            //}
        }

        private void SetData()
        {
            //if (InvokeRequired)
            //{
                //chart1.Series["Temperature"].Points.Clear();
                //chart1.Series["Pressure"].Points.Clear();
                //chart1.Series["Humidity"].Points.Clear();
                //lock (fileLock)
                //{
                chart1.Series["Temperature"].Points.AddXY("Jaipur", (int)userData["main"]["temp"]);
                chart1.Series["Pressure"].Points.AddXY("Jaipur", (int)userData["main"]["pressure"] / 100);
                chart1.Series["Humidity"].Points.AddXY("Jaipur", (int)userData["main"]["humidity"]);
                //}
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (InvokeRequired)
            //{
            //    GetData();

            this.Invoke(new MethodInvoker(delegate
            {
                GetData();
            }));

            this.Invoke(new MethodInvoker(delegate
            {
                SetData();
            }));

            //}

            //this.GetData();
            //this.SetData();

            //await Task.Run(() => this.GetData());
            //Task task1 = Task.Factory.StartNew(() => this.GetData());
            //Task task2 = task1.ContinueWith(antTask => this.SetData());

            //this.Invoke((MethodInvoker)delegate
            //{
            //    Program.SetData();
            //    Program.ShowData();
            //});


            //this.Invoke((MethodInvoker)delegate
            //{

            //});

        }
    }
}