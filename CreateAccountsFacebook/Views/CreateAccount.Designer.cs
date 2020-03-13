namespace CreateAccountsProject.Views
{
    partial class CreateAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccount));
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSoLuong = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.tbxLdPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.tbxHostName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxTimeConfig = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxTimeInstall = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxTimeRestart = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxTimeRun = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxTimeCreate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập số luồng";
            // 
            // tbxSoLuong
            // 
            this.tbxSoLuong.Location = new System.Drawing.Point(131, 114);
            this.tbxSoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxSoLuong.Name = "tbxSoLuong";
            this.tbxSoLuong.Size = new System.Drawing.Size(479, 22);
            this.tbxSoLuong.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(185, 171);
            this.btnRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(101, 28);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tbxLdPath
            // 
            this.tbxLdPath.Location = new System.Drawing.Point(131, 78);
            this.tbxLdPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxLdPath.Name = "tbxLdPath";
            this.tbxLdPath.Size = new System.Drawing.Size(479, 22);
            this.tbxLdPath.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "LD Path";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(353, 171);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 28);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tbxHostName
            // 
            this.tbxHostName.Location = new System.Drawing.Point(131, 43);
            this.tbxHostName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxHostName.Name = "tbxHostName";
            this.tbxHostName.Size = new System.Drawing.Size(479, 22);
            this.tbxHostName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Host Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbxTimeConfig);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbxTimeInstall);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbxTimeRestart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbxTimeRun);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbxTimeCreate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(631, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(341, 201);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ConfigDevice";
            // 
            // tbxTimeConfig
            // 
            this.tbxTimeConfig.Location = new System.Drawing.Point(163, 165);
            this.tbxTimeConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxTimeConfig.Name = "tbxTimeConfig";
            this.tbxTimeConfig.Size = new System.Drawing.Size(145, 22);
            this.tbxTimeConfig.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "TimeConfigDevice";
            // 
            // tbxTimeInstall
            // 
            this.tbxTimeInstall.Location = new System.Drawing.Point(163, 132);
            this.tbxTimeInstall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxTimeInstall.Name = "tbxTimeInstall";
            this.tbxTimeInstall.Size = new System.Drawing.Size(145, 22);
            this.tbxTimeInstall.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "TimeInstallApp";
            // 
            // tbxTimeRestart
            // 
            this.tbxTimeRestart.Location = new System.Drawing.Point(163, 95);
            this.tbxTimeRestart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxTimeRestart.Name = "tbxTimeRestart";
            this.tbxTimeRestart.Size = new System.Drawing.Size(145, 22);
            this.tbxTimeRestart.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "TimeRestartDevice";
            // 
            // tbxTimeRun
            // 
            this.tbxTimeRun.Location = new System.Drawing.Point(163, 59);
            this.tbxTimeRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxTimeRun.Name = "tbxTimeRun";
            this.tbxTimeRun.Size = new System.Drawing.Size(145, 22);
            this.tbxTimeRun.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "TimeRunDevice";
            // 
            // tbxTimeCreate
            // 
            this.tbxTimeCreate.Location = new System.Drawing.Point(163, 28);
            this.tbxTimeCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxTimeCreate.Name = "tbxTimeCreate";
            this.tbxTimeCreate.Size = new System.Drawing.Size(145, 22);
            this.tbxTimeCreate.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "TimeCreateDevice";
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 222);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbxHostName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.tbxLdPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbxSoLuong);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CreateAccount";
            this.Text = "Create Facebook Accounts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateAccount_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSoLuong;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox tbxLdPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox tbxHostName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxTimeRun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxTimeCreate;
        private System.Windows.Forms.TextBox tbxTimeRestart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxTimeInstall;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxTimeConfig;
        private System.Windows.Forms.Label label8;
    }
}