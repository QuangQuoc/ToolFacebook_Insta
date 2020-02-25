using CreateAccountsProject.Repositories;
using CreateAccountsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAccountsProject.Repositories
{
    public class HostRepository
    {
        public Host ReadHost(string hostName) // DOING
        {
            int index = TestDb.Hosts.FindIndex(h => h.Name == hostName);
            if (index != -1)
            {
                return TestDb.Hosts[index];
            }
            return null; //DOING_DB
        }
        public Host AddHost(string hostName)
        {
            var host = new Host(1, hostName);
            TestDb.Hosts.Add(host);
            return host;
        }
    }
}
