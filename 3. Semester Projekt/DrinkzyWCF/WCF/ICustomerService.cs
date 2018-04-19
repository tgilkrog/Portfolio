using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ModelLayer;

namespace WCF
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        void CreateCustomer(Customer customer);
        [OperationContract]
        Customer GetCustomer(int id);

        [OperationContract]
        IEnumerable<Customer> GetAllCustomers();

        [OperationContract]
        void UpdateCustomer(Customer customer);

        [OperationContract]
        void DeleteCustomer(int customerID);

        [OperationContract]
        IEnumerable<Customer> SearchCustomer(string text);

        [OperationContract]
        bool Login(string cusEmail, string cusPassword);
    }
}
