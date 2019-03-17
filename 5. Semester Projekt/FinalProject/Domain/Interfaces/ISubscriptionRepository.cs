using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<Subscription> CreateSubscription(Subscription subscription);
        Task<List<Subscription>> GetSubscription(int id);
        Task<bool> DeleteSubscription(int id);
        Task<EventUser> InsertEventUser(EventUser eventUser);
        Task<List<CustomerEvents>> GetListOfEventsByUser(int userId);
    }
}
