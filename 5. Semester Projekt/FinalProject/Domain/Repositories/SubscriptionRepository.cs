using Data;
using Data.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private SubscriptionDataAccess subscriptionDataAccess;

        public SubscriptionRepository(string connection)
        {
            subscriptionDataAccess = new SubscriptionDataAccess(connection);
        }

        public async Task<Subscription> CreateSubscription(Subscription subscription)
        {
            return await subscriptionDataAccess.InsertAsync(subscription);
        }

        public async Task<List<Subscription>> GetSubscription(int id)
        {
            return await subscriptionDataAccess.GetListWhereAsync(id);
        }

        public async Task<bool> DeleteSubscription(int id)
        {
            return await subscriptionDataAccess.DeleteAsync(id);
        }

        public async Task<EventUser> InsertEventUser(EventUser eventUser)
        {
            return await subscriptionDataAccess.InsertEventUser(eventUser);
        }

        public async Task<List<CustomerEvents>> GetListOfEventsByUser(int userId)
        {
            return await subscriptionDataAccess.GetListOfEventsByUser(userId);
        }
    }
}
