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
        public Form1()
        {
            InitializeComponent();
            SEALib.TCP.addSocket("heartbeat", 2055);
            SEALib.TCP.addSocket("data", 2056);
            SEALib.TCP.startListening("heartbeat", onAccept, onReceive, 1, 1024);
            SEALib.TCP.startListening("data", onAccept, onReceive, 1, 16048);
        }
        public void onAccept(string name)
        {
            SEALib.ErrorMessages.ThrowError(name + " connected!", "test", ErrorMessages.Level.alert, null, null);
        }
        public void onReceive(string name, byte[] bytes, int rec)
        {
            if (name=="data")
                updateTextDelegate();
        }
        public void updateTextDelegate()
        {
            cnt++;
            if (textBox1.InvokeRequired)
                textBox1.Invoke(new MethodInvoker(delegate { textBox1.Text = cnt.ToString(); }));
            else
                textBox1.Text += cnt.ToString();
        }
    }
}
