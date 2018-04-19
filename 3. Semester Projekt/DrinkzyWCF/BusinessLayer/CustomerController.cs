using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using ModelLayer;

namespace BusinessLayer
{
    public class CustomerController
    {
        CustomerDB cDb;

        public CustomerController()
        {
            cDb = new CustomerDB();
        }

        public void CreateCustomer(Customer customer)
        {
            cDb.CreateCustomer(customer);
        }

        public Customer GetCustomer(int id)
        {
            return cDb.GetCustomer(id);
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return cDb.GetAllCustomers();
        }


        public void UpdateCustomer(Customer customer)
        {
            cDb.UpdateCustomer(customer);
        }

        public void DeleteCustomer(int customerID)
        {
            cDb.DeleteCustomer(customerID);
        }
            
        public IEnumerable<Customer> searchCustomer(string search)
        {
            List<Customer> customers = new List<Customer>();
            string search2 = search.ToLower().Trim();

            foreach (Customer c in cDb.GetAllCustomers())
            {
                if (c.CusName.ToLower().Contains(search2) || c.Region.ToLower().Contains(search2))
                {
                    customers.Add(c);
                }
            }

            return customers;
        }

        public bool Login(string cusEmail, string cusPassword)
        {
            return cDb.Login(cusEmail, cusPassword);
        }
    }
}

