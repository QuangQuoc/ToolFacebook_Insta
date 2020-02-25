using CreateAccountsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAccountsProject.Repositories
{
    public static class TestDb
    {
        public static List<Device> Devices { get; set; }
        public static List<Host> Hosts { get; set; }
        public static void Initial()
        {
            Devices = new List<Device>();
            Hosts = new List<Host>();
        }
    }
}
