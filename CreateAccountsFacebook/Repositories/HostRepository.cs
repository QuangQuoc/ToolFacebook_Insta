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
        Context context = new Context();
        /// <summary>
        /// Đọc host theo hostName
        /// </summary>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public Host ReadHost(string hostName) // DOING
        {
            Host host = context.Hosts
                .Where(h => h.Name == hostName)             
                .FirstOrDefault();
            return host;
        }
        public Host AddHost(Host host)
        {
            context.Hosts.Add(host);
            context.SaveChanges();
            return host;
        }
    }
}
