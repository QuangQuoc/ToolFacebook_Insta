using CreateAccountsProject.Repositories;
using CreateAccountsProject.Services;
using CreateAccountsProject.Services.VariableServices;
using CreateAccountsProject.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreateAccountsProject.Models;
using System.Threading;

namespace CreateAccountsProject.Views
{
    public partial class CreateAccount : Form
    {
        private ManagementController manaCtrl = new ManagementController();
        private DevicesRepository deviceRepo = new DevicesRepository();
        public CreateAccount()
        {
            InitializeComponent();
            DeviceVariablesService.Initial();
            BMPVariablesService.Initial();
            SimVariablesService.Initial();
            TestDb.Initial();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //TEST

            // Đọc số luồng nhập vào và đưa vào biến static
            int thread = Int16.Parse(tbxSoLuong.Text);
            DeviceVariablesService.MaxThread = thread;
            if (tbxLdPath.Text != "")
            {
                DeviceVariablesService.LdDirectory = tbxLdPath.Text;
            }
            if (tbxHostName.Text != "")
            {
                DeviceVariablesService.MyHostName = tbxHostName.Text;
            }
            if (tbxTimeRun.Text != "")
            {
                try
                {
                    DeviceVariablesService.TimeRunDevice = Int16.Parse(tbxTimeRun.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Điền chữ số vào đây", "Error Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
            }
            if (tbxTimeRestart.Text != "")
            {
                try
                {
                    DeviceVariablesService.TimeRestartDevice = Int16.Parse(tbxTimeRestart.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Điền chữ số vào đây", "Error Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (tbxTimeCreate.Text != "")
            {
                try
                {
                    DeviceVariablesService.TimeCreateDevice = Int16.Parse(tbxTimeCreate.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Điền chữ số vào đây", "Error Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (tbxTimeInstall.Text != "")
            {
                try
                {
                    DeviceVariablesService.TimeInstallApp = Int16.Parse(tbxTimeInstall.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Điền chữ số vào đây", "Error Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (tbxTimeConfig.Text != "")
            {
                try
                {
                    DeviceVariablesService.TimeConfigDevice = Int16.Parse(tbxTimeConfig.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Điền chữ số vào đây", "Error Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Thread createThread = new Thread(manaCtrl.StartManagement);
            //manaCtrl.StartManagement();
            createThread.Start();
            DeviceVariablesService.ThreadsRunning.Add(createThread);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopProject();
        }

        private void CreateAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopProject();
        }

        private void StopProject()
        {
            DeviceVariablesService.CreateBotLive = false;
            foreach (var thread in DeviceVariablesService.ThreadsRunning)
            {
                try
                {
                    thread.Abort();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    ErrorService.AbortThread();
                }
            }
        }

        private void CreateAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeviceVariablesService.CreateBotLive = false;
            foreach (var thread in DeviceVariablesService.ThreadsRunning)
            {
                try
                {
                    thread.Abort();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    ErrorService.AbortThread();
                }
            }
        }
    }
}
