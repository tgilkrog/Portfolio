using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Data.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerService customerMediator;
        public CustomerController(IServiceProvider serviceProvider)
        {
            customerMediator = (ICustomerService)serviceProvider.GetService(typeof(ICustomerService));
        }

        /// <summary>
        /// Gets a list of all customers
        /// </summary>
        /// <returns>List of all customers</returns>
        // GET: api/Customer
        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await customerMediator.GetAllCustomers();
        }

        /// <summary>
        /// Gets a specified customer by an ID
        /// </summary>
        /// <param name="id">A unique customer ID</param>
        /// <returns>A customer</returns>
        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(int id)
        {
            return await customerMediator.GetCustomerById(id);
        }

        /// <summary>
        /// Gets a customer by a postalcode and/or city name
        /// </summary>
        /// <param name="postal">A number for postalcode</param>
        /// <param name="name">A string for city name</param>
        /// <returns>A list of customers</returns>
        [Route("get/{postal}/{name}")]
        [HttpGet("{postal}/{name}")]
        public async Task<List<Customer>> getCustomersByPostalName(int postal, string name)
        {
            return await customerMediator.GetCustomersByPostalName(postal, name);
        }

        /// <summary>
        /// Gets a list of customers by name
        /// </summary>
        /// <param name="name">A string</param>
        /// <returns>A list of customers</returns>
        // GET: api/Customer/name
        [Route("search/{name}")]
        [HttpGet("{name}")]
        public async Task<List<Customer>> GetName(string name)
        {
            return await customerMediator.GetCustomersByName(name);
        }
        
        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        /// <summary>
        /// Posts an Event into the database
        /// </summary>
        /// <param name="cusEvent">The specified event</param>
        [Route("postEvent")]
        [HttpPost]
        public void Post([FromBody]delCustEvent cusEvent)
        {
            if (cusEvent != null)
            {
                CustomerEvents sub = new CustomerEvents
                {
                    Title = cusEvent.Title,
                    Description = cusEvent.Description,
                    Date = cusEvent.Date
                };
                customerMediator.InsertEvent(sub, cusEvent.cusId);
            }
        }

        /// <summary>
        /// Posts a news to the database
        /// </summary>
        /// <param name="cusNews">The specified news to post</param>
        [Route("postNews")]
        [HttpPost]
        public void Post([FromBody]delCustNews cusNews)
        {
            if (cusNews != null)
            {
                CustomerNews sub = new CustomerNews
                {
                    Title = cusNews.Title,
                    Description = cusNews.Description,
                    Date = cusNews.Date
                };
                customerMediator.InsertNews(sub, cusNews.cusId);
            }
        }

        /// <summary>
        /// Posts a list notifications into the database
        /// </summary>
        /// <param name="notifications">The list of notifications</param>
        [Route("postNotifications")]
        [HttpPost]
        public void Post([FromBody]List<Notification> notifications)
        {
            customerMediator.InsertNotification(notifications);
        }

        /// <summary>
        /// A class used for posting events
        /// </summary>
        public class delCustEvent
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public int cusId { get; set; }
        }

        /// <summary>
        /// A class used to post news
        /// </summary>
        public class delCustNews
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public int cusId { get; set; }
        }
    }
}
