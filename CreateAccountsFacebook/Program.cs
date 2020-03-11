using CreateAccountsProject.Services;
using CreateAccountsProject.Services.VariableServices;
using CreateAccountsProject.Views;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateAccountsProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //TEST
            DeviceVariablesService.Initial();
            BMPVariablesService.Initial();
            SimVariablesService.Initial();
            RentCodeService sim = new RentCodeService();
            //sim.CreateRequest();
            //sim.GetNumber();
            sim.GetSms();
            //Application.Run(new CreateAccount());

        }
    }
}
