using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using ModelLayer;

namespace WCF
{
    class CustomerService : ICustomerService
    {
        CustomerController cusCtr;
        public CustomerService()
        {
            cusCtr = new CustomerController();
        }
        public void CreateCustomer(Customer customer)
        {
            cusCtr.CreateCustomer(customer);
        }

        public Customer GetCustomer(int id)
        {
            return cusCtr.GetCustomer(id);
        }
       
        public IEnumerable<Customer> GetAllCustomers()
        {
            return cusCtr.GetAllCustomers();
        }

        public void UpdateCustomer(Customer customer)
        {
            cusCtr.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int customerID)
        {
            cusCtr.DeleteCustomer(customerID);
        }

        public IEnumerable<Customer> SearchCustomer(string text)
        {
            return cusCtr.searchCustomer(text);
        }

        public bool Login(string cusEmail, string cusPassword)
        {
            return cusCtr.Login(cusEmail, cusPassword);
        }
    }
}
