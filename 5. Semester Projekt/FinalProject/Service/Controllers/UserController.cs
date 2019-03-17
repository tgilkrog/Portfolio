using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService userMediator;

        public UserController(IServiceProvider serviceProvider)
        {
            this.userMediator = (IUserService)serviceProvider.GetService(typeof(IUserService));
        }

        /// <summary>
        /// Posts a user into the database
        /// </summary>
        /// <param name="user">The specified user</param>
        // POST: api/User
        [HttpPost]
        public void Post([FromBody]User user)
        {
            if (user != null)
            {
                this.userMediator.CreateUser(user);
            }
        }

        /// <summary>
        /// Gets a user by a specified ID
        /// </summary>
        /// <param name="id">A unique user ID</param>
        /// <returns>A User</returns>
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await userMediator.GetUserById(id);
        }

        /// <summary>
        /// Gets a user by a username and a password
        /// </summary>
        /// <param name="username">string for a username</param>
        /// <param name="password">string for a password</param>
        /// <returns>An User</returns>
        [HttpGet("{username}/{password}")]
        [Route("{username}/{password}")]
        public async Task<User> Login(string username, string password)
        {
            return await userMediator.Login(username, password);
        }
    }
}