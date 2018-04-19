using BusinessLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    public class AuthService : IAuthService
    {
        UserController uCtr = new UserController();
        public bool Login(string username, string password)
        {
            Boolean found = uCtr.Login(username, password);

            return found;
        }
    }
}
