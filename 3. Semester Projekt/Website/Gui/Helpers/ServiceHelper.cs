using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gui.ServiceSecurityRef;
using Gui.AuthServiceRef;

namespace Gui.Helpers
{
    public static class ServiceHelper
    {
        public static SecurityServiceClient GetServiceClientWithCredentials(string username, string password)
        {
            SecurityServiceClient client = new SecurityServiceClient("WSHttpBinding_ISecurityService");
            client.ClientCredentials.UserName.UserName = username;
            client.ClientCredentials.UserName.Password = password;
            return client;
        }

        public static AuthServiceClient GetAuthServiceClient()
        {
            return new AuthServiceClient("WSHttpBinding_IAuthService");
        }
    }
}