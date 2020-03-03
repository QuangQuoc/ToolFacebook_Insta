﻿using CreateAccountsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAccountsProject.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DeviceIp { get; set; }
        public bool Status { get; set; }
        public Host Host { get; set; }
        public int? HostId { get; set; }
        public int ActivedAccounts { get; set; }
        public List<Account> Accounts { get; set; }
        public Device()
        {
            Accounts = new List<Account>();
            ActivedAccounts = 0;
        }
    }
}
