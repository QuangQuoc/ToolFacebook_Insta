using CreateAccountsProject.Models;
using CreateAccountsProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLdPlayer.Repositories
{
    public class AccountsRepository
    {
        Context context = new Context();

        public bool UpdateAccount(int id, Account acc)
        {
            Account accDb = context.Accounts
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (accDb != null)
            {
                accDb.Update(acc);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
