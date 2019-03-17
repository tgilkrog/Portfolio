using Data.Models;
using Domain.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private ISubscriptionRepository subscriptionRepository;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            this.subscriptionRepository = subscriptionRepository;
        }

        public async Task<Subscription> CreateSubscription(Subscription subscription)
        {
            return await subscriptionRepository.CreateSubscription(subscription);
        }

        public async Task<List<Subscription>> GetSubscription(int id)
        {
            return await subscriptionRepository.GetSubscription(id);
        }

        public async Task<bool> DeleteSubscription(int id)
        {
            return await subscriptionRepository.DeleteSubscription(id);
        }

        public async Task<EventUser> InsertEventUser(EventUser eventUser)
        {
            return await subscriptionRepository.InsertEventUser(eventUser);
        }

        public async Task<List<CustomerEvents>> GetListOfEventsByUser(int userId)
        {
            return await subscriptionRepository.GetListOfEventsByUser(userId);
        }
    }
}
