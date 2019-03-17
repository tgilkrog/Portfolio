using Data.Models;
using Domain.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {
            return await userRepository.CreateUser(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await userRepository.GetUserById(id);
        }

        public async Task<User> Login(string Username, string Password)
        {
            return await userRepository.Login(Username, Password);
        }
    }
}
