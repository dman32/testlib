namespace testlib
{
    partial class testlib
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtConfiguration = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAccess = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pnlClient = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.pnlServer = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConfiguration);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // txtConfiguration
            // 
            this.txtConfiguration.Location = new System.Drawing.Point(87, 12);
            this.txtConfiguration.Multiline = true;
            this.txtConfiguration.Name = "txtConfiguration";
            this.txtConfiguration.Size = new System.Drawing.Size(307, 82);
            this.txtConfiguration.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 48);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "Read";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Write";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ErrorMessages";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "msg",
            "warning",
            "critical",
            "decision"});
            this.comboBox1.Location = new System.Drawing.Point(93, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Show";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(247, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(170, 82);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logging";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(26, 46);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(118, 23);
            this.button7.TabIndex = 0;
            this.button7.Text = "Open";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(26, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Write";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtAccess);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Location = new System.Drawing.Point(12, 206);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(405, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Access";
            // 
            // txtAccess
            // 
            this.txtAccess.Location = new System.Drawing.Point(87, 12);
            this.txtAccess.Multiline = true;
            this.txtAccess.Name = "txtAccess";
            this.txtAccess.Size = new System.Drawing.Size(307, 82);
            this.txtAccess.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 48);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Read";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Write";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button11);
            this.groupBox5.Controls.Add(this.button8);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Location = new System.Drawing.Point(423, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(374, 135);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "TCP Communication";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(6, 19);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 5;
            this.button8.Text = "Connect";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pnlClient);
            this.groupBox6.Controls.Add(this.button10);
            this.groupBox6.Location = new System.Drawing.Point(193, 48);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(170, 76);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "TCP Server";
            // 
            // pnlClient
            // 
            this.pnlClient.Location = new System.Drawing.Point(87, 13);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(68, 51);
            this.pnlClient.TabIndex = 1;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 19);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 0;
            this.button10.Text = "Send";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.pnlServer);
            this.groupBox7.Controls.Add(this.button9);
            this.groupBox7.Location = new System.Drawing.Point(6, 48);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(170, 76);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "TCP Server";
            // 
            // pnlServer
            // 
            this.pnlServer.Location = new System.Drawing.Point(87, 13);
            this.pnlServer.Name = "pnlServer";
            this.pnlServer.Size = new System.Drawing.Size(68, 51);
            this.pnlServer.TabIndex = 1;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(6, 19);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 0;
            this.button9.Text = "Send";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(199, 19);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 5;
            this.button11.Text = "Connect";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // testlib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 315);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "testlib";
            this.Text = "testlib";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtConfiguration;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtAccess;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel pnlServer;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
    }
}