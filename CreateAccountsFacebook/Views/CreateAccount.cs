using ControlLdPlayer.Repositories;
using ControlLdPlayer.Services;
using CreateAccountsProject.Controllers;
using CreateAccountsProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateAccountsProject.Views
{
    public partial class CreateAccount : Form
    {
        private ManagementController manaCtrl = new ManagementController();
        public CreateAccount()
        {
            InitializeComponent();
            DeviceVariablesService.Initial();
            TestDb.Initial();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // Đọc số luồng nhập vào và đưa vào biến static
            int thread = Int16.Parse(tbxSoLuong.Text);
            DeviceVariablesService.MaxThread = thread;
            manaCtrl.StartManagement();
        }
    }
}
