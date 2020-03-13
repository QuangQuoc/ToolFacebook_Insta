using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAccountsProject.Models
{
    public class Avatar
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public int UsingNumber { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
