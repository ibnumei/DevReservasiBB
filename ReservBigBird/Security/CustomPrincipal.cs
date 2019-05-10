using ReservBigBird.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace ReservBigBird.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private Account account;
        private AccountModel accountModel = new AccountModel();

        public CustomPrincipal(Account Account)
        {
            this.account = Account;
            this.Identity = new GenericIdentity(Account.Username);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            foreach (string r in roles)
            {
                var roleAccounts = this.account.Role_Account.ToList();
                foreach (var roleAccount in roleAccounts)
                {
                    if (roleAccount.Role.Name.Contains(r.Trim()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}