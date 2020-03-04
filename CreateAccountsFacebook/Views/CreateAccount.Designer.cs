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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSoLuong = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lbApkPath = new System.Windows.Forms.Label();
            this.tbxApkPath = new System.Windows.Forms.TextBox();
            this.tbxLdPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.tbxHostName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxTimeCreate = new System.Windows.Forms.TextBox();
            this.tbxTimeRun = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxTimeRestart = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxTimeInstall = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxTimeConfig = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập số luồng";
            // 
            // tbxSoLuong
            // 
            this.tbxSoLuong.Location = new System.Drawing.Point(98, 122);
            this.tbxSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.tbxSoLuong.Name = "tbxSoLuong";
            this.tbxSoLuong.Size = new System.Drawing.Size(360, 20);
            this.tbxSoLuong.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(177, 165);
            this.btnRun.Margin = new System.Windows.Forms.Padding(2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(76, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lbApkPath
            // 
            this.lbApkPath.AutoSize = true;
            this.lbApkPath.Location = new System.Drawing.Point(18, 95);
            this.lbApkPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbApkPath.Name = "lbApkPath";
            this.lbApkPath.Size = new System.Drawing.Size(48, 13);
            this.lbApkPath.TabIndex = 3;
            this.lbApkPath.Text = "ApkPath";
            // 
            // tbxApkPath
            // 
            this.tbxApkPath.Location = new System.Drawing.Point(98, 92);
            this.tbxApkPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbxApkPath.Name = "tbxApkPath";
            this.tbxApkPath.Size = new System.Drawing.Size(360, 20);
            this.tbxApkPath.TabIndex = 4;
            // 
            // tbxLdPath
            // 
            this.tbxLdPath.Location = new System.Drawing.Point(98, 63);
            this.tbxLdPath.Margin = new System.Windows.Forms.Padding(2);
            this.tbxLdPath.Name = "tbxLdPath";
            this.tbxLdPath.Size = new System.Drawing.Size(360, 20);
            this.tbxLdPath.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "LD Path";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(292, 165);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tbxHostName
            // 
            this.tbxHostName.Location = new System.Drawing.Point(98, 35);
            this.tbxHostName.Margin = new System.Windows.Forms.Padding(2);
            this.tbxHostName.Name = "tbxHostName";
            this.tbxHostName.Size = new System.Drawing.Size(360, 20);
            this.tbxHostName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
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
            this.groupBox1.Location = new System.Drawing.Point(473, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 176);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ConfigDevice";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "TimeCreateDevice";
            // 
            // tbxTimeCreate
            // 
            this.tbxTimeCreate.Location = new System.Drawing.Point(122, 23);
            this.tbxTimeCreate.Margin = new System.Windows.Forms.Padding(2);
            this.tbxTimeCreate.Name = "tbxTimeCreate";
            this.tbxTimeCreate.Size = new System.Drawing.Size(110, 20);
            this.tbxTimeCreate.TabIndex = 11;
            // 
            // tbxTimeRun
            // 
            this.tbxTimeRun.Location = new System.Drawing.Point(122, 48);
            this.tbxTimeRun.Margin = new System.Windows.Forms.Padding(2);
            this.tbxTimeRun.Name = "tbxTimeRun";
            this.tbxTimeRun.Size = new System.Drawing.Size(110, 20);
            this.tbxTimeRun.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 51);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "TimeRunDevice";
            // 
            // tbxTimeRestart
            // 
            this.tbxTimeRestart.Location = new System.Drawing.Point(122, 77);
            this.tbxTimeRestart.Margin = new System.Windows.Forms.Padding(2);
            this.tbxTimeRestart.Name = "tbxTimeRestart";
            this.tbxTimeRestart.Size = new System.Drawing.Size(110, 20);
            this.tbxTimeRestart.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "TimeRestartDevice";
            // 
            // tbxTimeInstall
            // 
            this.tbxTimeInstall.Location = new System.Drawing.Point(122, 107);
            this.tbxTimeInstall.Margin = new System.Windows.Forms.Padding(2);
            this.tbxTimeInstall.Name = "tbxTimeInstall";
            this.tbxTimeInstall.Size = new System.Drawing.Size(110, 20);
            this.tbxTimeInstall.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 110);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "TimeInstallApp";
            // 
            // tbxTimeConfig
            // 
            this.tbxTimeConfig.Location = new System.Drawing.Point(122, 134);
            this.tbxTimeConfig.Margin = new System.Windows.Forms.Padding(2);
            this.tbxTimeConfig.Name = "tbxTimeConfig";
            this.tbxTimeConfig.Size = new System.Drawing.Size(110, 20);
            this.tbxTimeConfig.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 137);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "TimeConfigDevice";
            // 
            // CreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 209);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbxHostName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.tbxLdPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxApkPath);
            this.Controls.Add(this.lbApkPath);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbxSoLuong);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateAccount";
            this.Text = "CreateAccount";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSoLuong;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lbApkPath;
        private System.Windows.Forms.TextBox tbxApkPath;
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