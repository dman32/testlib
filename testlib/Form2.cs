using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testlib
{
    public partial class Form2 : Form
    {
        public static int cnt = 0, sndCnt = 1, byteSize = 1024;
        System.Timers.Timer update = new System.Timers.Timer();
        public Form2()
        {
            InitializeComponent();
            update.Interval = 100;
            update.Elapsed += new System.Timers.ElapsedEventHandler(update_Elapsed);
            update.Start();
            SEALib.TCP.addSocket("heartbeat1", System.Net.IPAddress.Parse("10.0.64.211"), 2055);
            //SEALib.TCP.addSocket("data1", System.Net.IPAddress.Parse("10.0.64.211"), 2056);
            //SEALib.TCP.startConnecting("data1", onAccept, onDisconnect, onReceive);
        }
        void update_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (SEALib.TCP.isConnected("heartbeat1"))
                updateButtonDelegate("disconnect");
            else
                updateButtonDelegate("connect");
            cnt++;
            updateLabelDelegate(cnt.ToString());
            updateLabel2Delegate(SEALib.TCP.isConnected("heartbeat1").ToString());
        }
        public void updateButtonDelegate(string text)
        {
            try
            {
                if (button1.InvokeRequired)
                    button1.Invoke(new MethodInvoker(delegate { button1.Text = text; }));
                else
                    button1.Text = text;
            }
            catch { }
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
            SEALib.TCP.startSend(name, onSend, Encoding.UTF8.GetBytes(sndCnt.ToString()));
        }
        public void onSend(string name)
        {
            updateTextDelegate(":");
            sndCnt++;
            System.Threading.Thread.Sleep(200);
            try
            {
                SEALib.TCP.startSend(name, onSend, Encoding.UTF8.GetBytes(sndCnt.ToString()));
            }
            catch { }
        }
        public void onDisconnect(string name)
        {
            updateTextDelegate(name.Substring(0, 1) + "-");
        }
        public void onReceive(string name, byte[] bytes, int rec)
        {
            switch (name)
            {
                case "data1":
                    updateTextDelegate(".");
                    break;
                case "heartbeat1":
                    updateTextDelegate("!");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SEALib.TCP.isConnected("heartbeat1"))
            {
                SEALib.TCP.disconnect("heartbeat1"); 
            }else
            {
                SEALib.TCP.startConnecting("heartbeat1", onAccept, onDisconnect, onReceive, byteSize);
            }
        }
    }
}
