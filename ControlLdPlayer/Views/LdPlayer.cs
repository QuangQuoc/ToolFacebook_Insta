using ControlLdPlayer.Controllers;
using ControlLdPlayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLdPlayer.Views
{
    public partial class LdPlayer : Form
    {
        private LdPlayerController controller; 
        public LdPlayer()
        {
            InitializeComponent();
            controller = new LdPlayerController(this);
        }

        public string ReadtbxName()
        {
            return this.tbxName.Text.ToString(); 
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            controller.Create();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            controller.Run();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            controller.Quit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnQuitAll_Click(object sender, EventArgs e)
        {
            controller.QuitAll();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            controller.PropertySetting();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnUnInstall_Click(object sender, EventArgs e)
        {
            string packageName = tbxPackageName.Text.ToString();
            controller.UnInstallApp(packageName);
        }

        private void LdPlayer_Load(object sender, EventArgs e)
        {

        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            string fileName = tbxFileApk.Text.ToString();
            controller.InstallApp(fileName);
        }

        private void btnRunApp_Click(object sender, EventArgs e)
        {
            string packageName = tbxPackageName.Text.ToString();
            controller.RunApp(packageName);
        }

        private void btnKillApp_Click(object sender, EventArgs e)
        {
            string packageName = tbxPackageName.Text.ToString();
            controller.KillApp(packageName);
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
