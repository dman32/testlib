using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SEALib;

namespace testlib
{
    public partial class Form1 : Form
    {
        public static int cnt = 0;
        System.Timers.Timer update = new System.Timers.Timer();
        public Form1()
        {
            InitializeComponent();
            update.Interval = 100;
            update.Elapsed += new System.Timers.ElapsedEventHandler(update_Elapsed);
            update.Start();
            SEALib.TCP.addSocket("heartbeat", System.Net.IPAddress.Any, 2055);
            SEALib.TCP.startListening("heartbeat", onAccept, onDisconnect, onReceive, 1024);
            //SEALib.TCP.addSocket("data", System.Net.IPAddress.Any, 2056);
            //SEALib.TCP.startListening("data", onAccept, onDisconnect, onReceive, 16048);
            Form2 f2 = new Form2();
            f2.Show();
        }

        void update_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            cnt++;
            updateLabelDelegate(cnt.ToString());
            updateLabel2Delegate(SEALib.TCP.isConnected("heartbeat1").ToString());
        }
        public void updateLabelDelegate(string text)
        {
            try
            {
                if (label1.InvokeRequired)
                    label1.Invoke(new MethodInvoker(delegate { label1.Text = text; }));
                else
                    label1.Text = text;
            }
            catch { }
        }
        public void updateLabel2Delegate(string text)
        {
            try
            {
                if (label2.InvokeRequired)
                    label2.Invoke(new MethodInvoker(delegate { label2.Text = text; }));
                else
                    label2.Text = text;
            }
            catch { }
        }
        public void updateTextDelegate(string text)
        {
            try
            {
                if (textBox1.InvokeRequired)
                    textBox1.Invoke(new MethodInvoker(delegate { textBox1.Text += text; }));
                else
                    textBox1.Text += text;
            }
            catch { }
        }
        public void onAccept(string name)
        {
            updateTextDelegate(name.Substring(0, 1) + "+");
        }
        public void onDisconnect(string name)
        {
            updateTextDelegate(name.Substring(0, 1) + "-");
            switch (name)
            {
                case "heartbeat":
                    SEALib.TCP.startListening("heartbeat", onAccept, onDisconnect, onReceive, 1024);
                    break;
                case "data":
                    SEALib.TCP.startListening("data", onAccept, onDisconnect, onReceive, 16048);
                    break;
            }
        }
        public void onReceive(string name, byte[] bytes, int rec)
        {
            switch (name)
            {
                case "data":
                    updateTextDelegate(".");
                    break;
                case "heartbeat":
                    updateTextDelegate(Encoding.UTF8.GetString(bytes));
                    break;
            }
        }
    }
}
