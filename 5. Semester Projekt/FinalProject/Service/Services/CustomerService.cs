using Data.Models;
using Domain.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await customerRepository.GetAllCustomers();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await customerRepository.getCustomerById(id);
        }

        public async Task<List<Customer>> GetCustomersByName(string name)
        {
            return await customerRepository.GetCustomersByName(name);
        }

        public async Task<List<Customer>> GetCustomersByPostalName(int postal, string name)
        {
            return await customerRepository.GetCustomersByPostalName(postal, name);
        }

        public async Task<CustomerEvents> InsertEvent(CustomerEvents cusEvent, int cusId)
        {
            return await customerRepository.InsertEvent(cusEvent, cusId);
        }

        public async Task<CustomerNews> InsertNews(CustomerNews cusNews, int cusId)
        {
            return await customerRepository.InsertNews(cusNews, cusId);
        }

        public async Task<List<Notification>> InsertNotification(List<Notification> notifications)
        {
            return await customerRepository.InsertNotifications(notifications);
        }
    }
}
