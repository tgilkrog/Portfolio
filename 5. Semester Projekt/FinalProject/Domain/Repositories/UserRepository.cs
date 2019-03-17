using Data;
using Data.Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserDataAccess userDataAccess;

        public UserRepository(string connection)
        {
            userDataAccess = new UserDataAccess(connection);
        }

        public async Task<User> CreateUser(User user)
        {
            return await userDataAccess.InsertAsync(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await userDataAccess.GetAsync(id);
        }

        public async Task<User> Login(string Username, string Password)
        {
            return await userDataAccess.Login(Username, Password);
        }
    }
}
