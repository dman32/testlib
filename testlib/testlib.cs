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
    public partial class testlib : Form
    {
        public const int byteSize = 1024;
        public const string server = "testserver", client = "testclient";
        public testlib()
        {
            InitializeComponent();
            SEALib.Configuration.Init("testlib.xml");
            SEALib.Logging.Init("log.txt");
            SEALib.Database.OLEDB.Init("test.accdb");
            SEALib.TCP.addSocket(server, System.Net.IPAddress.Any, 2055);
            SEALib.TCP.addSocket(client, System.Net.IPAddress.Parse("10.0.64.211"), 2055);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SEALib.Configuration.Set("config1", "value1", DateTime.Now.ToShortTimeString());
            SEALib.Configuration.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String title = "test title", message="current time: "+DateTime.Now.ToShortTimeString();
            SEALib.ErrorMessages.ThrowError(message, title, (SEALib.ErrorMessages.Level)comboBox1.SelectedIndex, null, null);
         }

        private void button4_Click(object sender, EventArgs e)
        {
            SEALib.Logging.Write("current time: " + DateTime.Now.ToShortTimeString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtConfiguration.Text = SEALib.Configuration.GetString("config1", "value1") + Environment.NewLine;
            txtConfiguration.Text += SEALib.Configuration.GetString("config1", "value2") + Environment.NewLine;
            txtConfiguration.Text += SEALib.Configuration.GetString("config1", "value3") + Environment.NewLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SEALib.Database.OLEDB.Insert("INSERT INTO test (message) VALUES (@message)", new System.Data.OleDb.OleDbParameter[] { new System.Data.OleDb.OleDbParameter("message", DateTime.Now.ToShortTimeString()) });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = SEALib.Database.OLEDB.Select("SELECT * FROM test ORDER BY id DESC", null);
            if (dt != null)
                if (dt.Rows.Count > 0)
                    txtAccess.Text = dt.Rows[0]["message"].ToString();
                else
                    txtAccess.Text = "no records";
            else
                txtAccess.Text = "error";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", "log.txt");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (SEALib.TCP.isConnected(server))
                SEALib.TCP.disconnect(server);
            else
            {
                SEALib.TCP.startListening(server, onAccept, onDisconnect, onReceive, byteSize);
                updateTxt(txtServer, "listening", true);
            }
        }

        private void onAccept(string name)
        {
            switch (name)
            {
                case server:
                    updateTxt(btnServer, "Disconnect", false);
                    updateTxt(txtServer, "+", true);
                    break;
                case client:
                    updateTxt(btnClient, "Disconnect", false);
                    updateTxt(txtClient, "+", true);
                    break;
            }
        }

        private void onDisconnect(string name)
        {
            switch (name)
            {
                case server:
                    updateTxt(btnServer, "Listen", false);
                    updateTxt(txtServer, "-", true);
                    break;
                case client:
                    updateTxt(btnClient, "Connect", false);
                    updateTxt(txtClient, "-", true);
                    break;
            }
        }

        private void onReceive(string name, byte[] bytes, int bytesRec)
        {
            switch (name)
            {
                case server:
                    updateTxt(txtServer, "R", true);
                    break;
                case client:
                    updateTxt(txtClient, "R", true);
                    break;
            }
        }

        private void updateTxt(Control c, string text, bool concatenate)
        {
            try
            {
                if (c.InvokeRequired)
                    if (concatenate)
                        c.Invoke(new MethodInvoker(delegate { c.Text += text; }));
                    else
                        c.Invoke(new MethodInvoker(delegate { c.Text = text; }));
                else
                    if (concatenate)
                        c.Text += text;
                    else
                        c.Text = text;
            }
            catch { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (SEALib.TCP.isConnected(client))
                SEALib.TCP.disconnect(client);
            else
            {
                SEALib.TCP.startConnecting(client, onAccept, onDisconnect, onReceive, byteSize);
                updateTxt(txtClient, "connecting", true);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SEALib.TCP.startSend(server, onSend, Encoding.UTF8.GetBytes("test"));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SEALib.TCP.startSend(client, onSend, Encoding.UTF8.GetBytes("test"));
        }

        private void onSend(string name)
        {
            switch (name)
            {
                case server:
                    updateTxt(txtServer, "S", true);
                    break;
                case client:
                    updateTxt(txtClient, "S", true);
                    break;
            }
        }
    }
}

