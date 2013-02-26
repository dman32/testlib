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
        public Form1()
        {
            InitializeComponent();
            SEALib.TCP.Server.addSocket("heartbeat", 2055);
            SEALib.TCP.Server.startListening("heartbeat", onAccept, 1);
        }
        public void onAccept(IAsyncResult ar)
        {
            SEALib.ErrorMessages.ThrowError("connected!", "test", ErrorMessages.Level.alert, null, null);
        }
    }
}
