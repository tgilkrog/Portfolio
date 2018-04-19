using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    public class SecurityService : ISecurityService
    {
        public UserController UserController { get; set; }
        public SecurityService()
        {
            UserController = new UserController();
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public string GetData(int value)
        {
            var found = UserController.GetUser(1);
            return string.Format("Pssst, the data you requested back was: {0}, hi {1}, you are allowed to know!", value, OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name);
        }
    }
}
