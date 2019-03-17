using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    public class SubscriptionController : Controller
    {
        private ISubscriptionService subscriptionMediator;
        public SubscriptionController(IServiceProvider serviceProvider)
        {
            subscriptionMediator = (ISubscriptionService)serviceProvider.GetService(typeof(ISubscriptionService));
        }

        /// <summary>
        /// Gets a list of subscriptions based on an ID
        /// </summary>
        /// <param name="id">A unique user ID</param>
        /// <returns>List of subscriptions</returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<List<Subscription>> Get(int id)
        {
            return await subscriptionMediator.GetSubscription(id);
        }

        /// <summary>
        /// Posts a subscription into the database
        /// </summary>
        /// <param name="subscription">The specified subscription</param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody]delSub subscription)
        {
            if (subscription != null)
            {
                Subscription sub = new Subscription
                {
                    ID = subscription.UserID,
                    Customer = new Customer
                    {
                        Id = subscription.CustomerID
                    },
                    Notification = subscription.Notification
                };
                subscriptionMediator.CreateSubscription(sub);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Deletes a subscription with a specified ID
        /// </summary>
        /// <param name="id">A unique subscription ID</param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            subscriptionMediator.DeleteSubscription(id);
        }

        /// <summary>
        /// Posts an evenUser to the database
        /// </summary>
        /// <param name="eventUser">The specified eventUser</param>
        [HttpPost]
        [Route("insertEventUser")]
        public void InsertEventUser([FromBody]EventUser eventUser)
        {
            if (eventUser != null)
            {
                EventUser eventU = new EventUser
                {
                    EventId = eventUser.EventId,
                    UserId = eventUser.UserId
                };
                subscriptionMediator.InsertEventUser(eventU);
            }
        }

        /// <summary>
        /// Gets a lists of CustomerEvents with an user ID
        /// </summary>
        /// <param name="userId">A unique user ID</param>
        /// <returns>List of customerevents</returns>
        [HttpGet("{userId}")]
        [Route("getList/{userId}")]
        public async Task<List<CustomerEvents>> getListOfEventByUser(int userId)
        {
            return await subscriptionMediator.GetListOfEventsByUser(userId);
        }
    }

    /// <summary>
    /// Class used for posting a subscription
    /// </summary>
    public class delSub
    {
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public bool Notification { get; set; }
    }
}