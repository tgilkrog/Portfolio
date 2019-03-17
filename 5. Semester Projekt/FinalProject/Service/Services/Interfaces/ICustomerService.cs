using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetCustomersByPostalName(int postal, string name);
        Task<Customer> GetCustomerById(int id);
        Task<List<Customer>> GetCustomersByName(string name);
        Task<CustomerEvents> InsertEvent(CustomerEvents cusEvent, int cusId);
        Task<CustomerNews> InsertNews(CustomerNews cusNews, int cusId);
        Task<List<Notification>> InsertNotification(List<Notification> notifications);
    }
}
