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
        public const string server = "testserver", client = "testclient", ipaddress = "10.0.64.211";
        public const string logfile = "log.txt", cfgfile = "testlib.xml", dbfile = "test.accdb";
        public System.Timers.Timer tmrUpdate = new System.Timers.Timer(), tmrBlipServer = new System.Timers.Timer(), tmrBlipClient = new System.Timers.Timer();
        public testlib()
        {
            InitializeComponent();
            SEALib.Configuration.Init(cfgfile);
            SEALib.Logging.Init(logfile);
            SEALib.Database.OLEDB.Init(dbfile);
            SEALib.TCP.addServer(server, 2055, onAccept, onDisconnect, onReceive, byteSize);
            SEALib.TCP.addClient(client, System.Net.IPAddress.Parse(ipaddress), 2055, onAccept, onDisconnect, onReceive, byteSize);
            tmrUpdate.Interval = 200;
            tmrUpdate.Elapsed += new System.Timers.ElapsedEventHandler(tmrUpdate_Tick);
            tmrUpdate.Start();
            tmrBlipServer.Interval = 500;
            tmrBlipServer.AutoReset = false;
            tmrBlipServer.Elapsed += new System.Timers.ElapsedEventHandler(tmrBlipServer_Tick);
            tmrBlipClient.Interval = 500;
            tmrBlipClient.AutoReset = false;
            tmrBlipClient.Elapsed += new System.Timers.ElapsedEventHandler(tmrBlipClient_Tick);
        }

        void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (SEALib.TCP.isConnected(server))
            {
                if (pnlServer.BackColor != Color.GreenYellow && pnlServer.BackColor != Color.Green && pnlServer.BackColor != Color.Yellow)
                    updatePnl(pnlServer, Color.Green);
            }
            else if (SEALib.TCP.isListening(server))
                updatePnl(pnlServer, Color.Blue);
            else
                updatePnl(pnlServer, Color.Red);

            if (SEALib.TCP.isConnected(client))
            {
                if (pnlClient.BackColor != Color.GreenYellow && pnlClient.BackColor != Color.Green && pnlClient.BackColor != Color.Yellow)
                    updatePnl(pnlClient, Color.Green);
            }
            else if (SEALib.TCP.isListening(client))
                updatePnl(pnlClient, Color.Blue);
            else
                updatePnl(pnlClient, Color.Red);
            enableControl(button11,SEALib.TCP.isListening(server) || SEALib.TCP.isConnected(client));
            enableControl(button9, SEALib.TCP.isConnected(server));
            enableControl(button10, SEALib.TCP.isConnected(client));
        }
        void tmrBlipServer_Tick(object sender, EventArgs e)
        {
            updatePnl(pnlServer, Color.Green);
        }
        void tmrBlipClient_Tick(object sender, EventArgs e)
        {
            updatePnl(pnlClient, Color.Green);
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


        private void onAccept(string name)
        {
            switch (name)
            {
                case server:
                    break;
                case client:
                    break;
            }
        }

        private void onDisconnect(string name)
        {
            SEALib.ErrorMessages.ThrowError(name + " disconnected", "message", SEALib.ErrorMessages.Level.warning, null, null);

        }

        private void onReceive(string name, byte[] bytes, int bytesRec)
        {
            switch (name)
            {
                case server:
                    updatePnl(pnlServer, Color.GreenYellow);
                    tmrBlipServer.Start();
                    break;
                case client:
                    updatePnl(pnlClient, Color.GreenYellow);
                    tmrBlipClient.Start();
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

        private void updatePnl(Panel p, Color c)
        {
            if (p.InvokeRequired)
                p.Invoke(new MethodInvoker(delegate { p.BackColor = c; }));
            else
                p.BackColor = c;
        }

        private void enableControl(Control c, bool enable)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new MethodInvoker(delegate { c.Enabled = enable; }));
            }else
                c.Enabled = enable;
        }

        private void onSend(string name)
        {
            switch (name)
            {
                case server:
                    updatePnl(pnlServer, Color.Yellow);
                    tmrBlipServer.Start();
                    break;
                case client:
                    updatePnl(pnlClient, Color.Yellow);
                    tmrBlipClient.Start();
                    break;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (SEALib.TCP.isConnected(client))
                SEALib.TCP.disconnect(server);
            else
                SEALib.TCP.startListening(server);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (SEALib.TCP.isConnected(server))
                SEALib.TCP.startSend(server, onSend, Encoding.UTF8.GetBytes(DateTime.Now.ToShortTimeString()));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (SEALib.TCP.isConnected(client))
                SEALib.TCP.startSend(client, onSend, Encoding.UTF8.GetBytes(DateTime.Now.ToShortTimeString()));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (SEALib.TCP.isConnected(client))
                SEALib.TCP.disconnect(client);
            else
                if (SEALib.TCP.isListening(server))
                    SEALib.TCP.startConnecting(client);
        }
    }
}

