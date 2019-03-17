using Data;
using Data.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerDataAccess customerDataAccess;

        public CustomerRepository(string connection)
        {
            customerDataAccess = new CustomerDataAccess(connection);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await customerDataAccess.GetAllAsync();
        }

        public async Task<Customer> getCustomerById(int id)
        {
            return await customerDataAccess.GetAsync(id);
        }

        public async Task<List<Customer>> GetCustomersByName(string name)
        {
            return await customerDataAccess.SearchAsync(name);
        }

        public async Task<List<Customer>> GetCustomersByPostalName(int postal, string name)
        {
            return await customerDataAccess.getListByPostalName(postal, name);
        }

        public async Task<CustomerEvents> InsertEvent(CustomerEvents cusEvent, int cusId)
        {
            return await customerDataAccess.InsertEvent(cusEvent, cusId);
        }

        public async Task<CustomerNews> InsertNews(CustomerNews cusNews, int cusId)
        {
            return await customerDataAccess.InsertNews(cusNews, cusId);
        }

        public async Task<List<Notification>> InsertNotifications(List<Notification> notifications)
        {
            return await customerDataAccess.InsertBulk(notifications);
        }
    }
}
