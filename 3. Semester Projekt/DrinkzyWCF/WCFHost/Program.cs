using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF;

namespace WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(SecurityService));
            ServiceHost userHost = new ServiceHost(typeof(UserService));
            ServiceHost authhost = new ServiceHost(typeof(AuthService));

            host.Open();
            userHost.Open();
            authhost.Open();
                Console.WriteLine("Hosting the service...");
                Console.ReadLine();
            host.Close();
            userHost.Close();
            authhost.Close();

        }
    }
}
