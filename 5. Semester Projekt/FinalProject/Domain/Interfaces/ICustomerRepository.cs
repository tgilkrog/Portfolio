using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetCustomersByPostalName(int postal, string name);
        Task<Customer> getCustomerById(int id);
        Task<List<Customer>> GetCustomersByName(string name);
        Task<CustomerEvents> InsertEvent(CustomerEvents cusEvent, int cusId);
        Task<List<Notification>> InsertNotifications(List<Notification> notifications);
        Task<CustomerNews> InsertNews(CustomerNews cusNews, int cusId);
    }
}
