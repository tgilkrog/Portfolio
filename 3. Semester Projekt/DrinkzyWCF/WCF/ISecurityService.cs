using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    [ServiceContract]
    public interface ISecurityService
    {
        [OperationContract]
        string GetData(int value);

    }
}
