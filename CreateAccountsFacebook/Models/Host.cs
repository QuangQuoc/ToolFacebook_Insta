using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAccountsProject.Models
{
    public class Host
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Device> Devices { get; set; }

        public Host()
        {
            Devices = new List<Device>();
        }

        public Host(string name) : this()
        {
            Name = name;
        }

        public Host(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
