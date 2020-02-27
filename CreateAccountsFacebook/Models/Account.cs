using CreateAccountsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAccountsProject.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Fb2FACode { get; set; }
        public string BrowserName { get; set; }
        public string BrowserFileName { get; set; }
        public bool BrowserStatus { get; set; }
        public string FullName { get; set; }

        public DateTime BirthDay { get; set; }

        public Avatar Avatar { get; set; }
        public int? AvatarId { get; set; }

        public string GioiTinh { get; set; }

        public Account()
        {

        }
        public Account(string brName, string brFileName, bool brStatus = false)
        {
            BrowserName = brName;
            BrowserFileName = brFileName;
            BrowserStatus = BrowserStatus;
        }
    }
}
