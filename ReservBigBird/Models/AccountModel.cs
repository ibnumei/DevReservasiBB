using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservBigBird.Models
{
    public class AccountModel
    {
        private devbigbirdEntities db = new devbigbirdEntities();

        public Account find(string username)
        {
            return db.Accounts.SingleOrDefault(acc => acc.Username.Equals(username));
        }

        public Account login(string username, string password)
        {
            return db.Accounts.SingleOrDefault(acc => acc.Username.Equals(username) && acc.Password.Equals(password));
        }
    }
}