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
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DrinkController : Controller
    {
        private IDrinkService drinkMediator;

        public DrinkController(IServiceProvider serviceProvider)
        {
            drinkMediator = (IDrinkService)serviceProvider.GetService(typeof(IDrinkService));
        }

        /// <summary>
        /// Gets all drinks from the database
        /// </summary>
        /// <returns>A list of all drinks</returns>
        // GET: api/Drink
        [HttpGet]
        public async Task<List<Drink>> Get()
        {
            return await drinkMediator.GetAllDrinks();
        }

        /// <summary>
        /// Gets a drink by an ID
        /// </summary>
        /// <param name="id">The unique drink ID</param>
        /// <returns>A Drink</returns>
        // GET: api/Drink/5
        [HttpGet("{id}")]
        public async Task<Drink> Get(int id)
        {
            return await drinkMediator.GetDrinkById(id);
        }

        /// <summary>
        /// Gets a list of drinks by a search string
        /// </summary>
        /// <param name="name">The string to search with</param>
        /// <returns>A list of drinks</returns>
        // GET: 
        [Route("search/{name}")]
        [HttpGet("{name}")]
        public async Task<List<Drink>> Get(string name)
        {
            return await drinkMediator.GetDrinksByName(name);
        }

        // POST: api/Drink
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Drink/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
