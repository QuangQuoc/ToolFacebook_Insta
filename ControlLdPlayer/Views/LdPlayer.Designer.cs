namespace ControlLdPlayer.Views
{
    partial class LdPlayer
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbxPackageName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnKillApp = new System.Windows.Forms.Button();
            this.btnRunApp = new System.Windows.Forms.Button();
            this.btnUnInstall = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.tbxFileApk = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnQuitAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.tbxImei = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxMemory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxCpu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxResolution = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnQuitAll);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnQuit);
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxName);
            this.groupBox1.Location = new System.Drawing.Point(44, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(621, 374);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ControlLdPlayer";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbxPackageName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnKillApp);
            this.groupBox3.Controls.Add(this.btnRunApp);
            this.groupBox3.Controls.Add(this.btnUnInstall);
            this.groupBox3.Controls.Add(this.btnInstall);
            this.groupBox3.Controls.Add(this.tbxFileApk);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(311, 145);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(293, 217);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Application";
            // 
            // tbxPackageName
            // 
            this.tbxPackageName.Location = new System.Drawing.Point(68, 74);
            this.tbxPackageName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxPackageName.Name = "tbxPackageName";
            this.tbxPackageName.Size = new System.Drawing.Size(211, 22);
            this.tbxPackageName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "PkName";
            // 
            // btnKillApp
            // 
            this.btnKillApp.Location = new System.Drawing.Point(183, 171);
            this.btnKillApp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKillApp.Name = "btnKillApp";
            this.btnKillApp.Size = new System.Drawing.Size(81, 28);
            this.btnKillApp.TabIndex = 5;
            this.btnKillApp.Text = "Kill App";
            this.btnKillApp.UseVisualStyleBackColor = true;
            this.btnKillApp.Click += new System.EventHandler(this.btnKillApp_Click);
            // 
            // btnRunApp
            // 
            this.btnRunApp.Location = new System.Drawing.Point(84, 171);
            this.btnRunApp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRunApp.Name = "btnRunApp";
            this.btnRunApp.Size = new System.Drawing.Size(77, 28);
            this.btnRunApp.TabIndex = 4;
            this.btnRunApp.Text = "Run App";
            this.btnRunApp.UseVisualStyleBackColor = true;
            this.btnRunApp.Click += new System.EventHandler(this.btnRunApp_Click);
            // 
            // btnUnInstall
            // 
            this.btnUnInstall.Location = new System.Drawing.Point(183, 134);
            this.btnUnInstall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUnInstall.Name = "btnUnInstall";
            this.btnUnInstall.Size = new System.Drawing.Size(81, 28);
            this.btnUnInstall.TabIndex = 3;
            this.btnUnInstall.Text = "UnInstall";
            this.btnUnInstall.UseVisualStyleBackColor = true;
            this.btnUnInstall.Click += new System.EventHandler(this.btnUnInstall_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(84, 134);
            this.btnInstall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(77, 28);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // tbxFileApk
            // 
            this.tbxFileApk.Location = new System.Drawing.Point(68, 34);
            this.tbxFileApk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxFileApk.Name = "tbxFileApk";
            this.tbxFileApk.Size = new System.Drawing.Size(211, 22);
            this.tbxFileApk.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "FileApk";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnQuitAll
            // 
            this.btnQuitAll.Location = new System.Drawing.Point(444, 86);
            this.btnQuitAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuitAll.Name = "btnQuitAll";
            this.btnQuitAll.Size = new System.Drawing.Size(71, 28);
            this.btnQuitAll.TabIndex = 6;
            this.btnQuitAll.Text = "Quit All";
            this.btnQuitAll.UseVisualStyleBackColor = true;
            this.btnQuitAll.Click += new System.EventHandler(this.btnQuitAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSetting);
            this.groupBox2.Controls.Add(this.tbxImei);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbxMemory);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbxCpu);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbxResolution);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 145);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(263, 217);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Property Setting";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(97, 175);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(100, 28);
            this.btnSetting.TabIndex = 8;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // tbxImei
            // 
            this.tbxImei.Location = new System.Drawing.Point(97, 143);
            this.tbxImei.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxImei.Name = "tbxImei";
            this.tbxImei.Size = new System.Drawing.Size(132, 22);
            this.tbxImei.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 146);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Imei";
            // 
            // tbxMemory
            // 
            this.tbxMemory.Location = new System.Drawing.Point(97, 107);
            this.tbxMemory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxMemory.Name = "tbxMemory";
            this.tbxMemory.Size = new System.Drawing.Size(132, 22);
            this.tbxMemory.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Memory";
            // 
            // tbxCpu
            // 
            this.tbxCpu.Location = new System.Drawing.Point(97, 70);
            this.tbxCpu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxCpu.Name = "tbxCpu";
            this.tbxCpu.Size = new System.Drawing.Size(132, 22);
            this.tbxCpu.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cpu";
            // 
            // tbxResolution
            // 
            this.tbxResolution.Location = new System.Drawing.Point(97, 34);
            this.tbxResolution.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxResolution.Name = "tbxResolution";
            this.tbxResolution.Size = new System.Drawing.Size(132, 22);
            this.tbxResolution.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Resolution ";
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(337, 86);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(65, 28);
            this.btnQuit.TabIndex = 5;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(232, 86);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(64, 28);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(128, 86);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(65, 28);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxName.Location = new System.Drawing.Point(64, 34);
            this.tbxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(539, 30);
            this.tbxName.TabIndex = 0;
            this.tbxName.TextChanged += new System.EventHandler(this.tbxName_TextChanged);
            // 
            // LdPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 438);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LdPlayer";
            this.Text = "CreateLdPlayer";
            this.Load += new System.EventHandler(this.LdPlayer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnQuitAll;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox tbxMemory;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tbxCpu;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tbxResolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSetting;
        public System.Windows.Forms.TextBox tbxImei;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TextBox tbxFileApk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnKillApp;
        private System.Windows.Forms.Button btnRunApp;
        private System.Windows.Forms.Button btnUnInstall;
        private System.Windows.Forms.Button btnInstall;
        public System.Windows.Forms.TextBox tbxPackageName;
        private System.Windows.Forms.Label label7;
    }
}