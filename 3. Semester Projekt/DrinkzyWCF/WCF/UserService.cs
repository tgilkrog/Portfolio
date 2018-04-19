using System;
using BusinessLayer;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    public class UserService : IUserService
    {
        UserController UserCtr;

        public UserService()
        {
            UserCtr = new UserController();
        }
        public void CreateUser(User user)
        {
            UserCtr.CreateUser(user);
        }

        public User GetUser(int id)
        {
            return UserCtr.GetUser(id);
        }

        public User GetUserByUserName(string username)
        {
            return UserCtr.GetUserByUserName(username);
        }

        public IEnumerable<User> getAllUsers()
        {
            return UserCtr.getAllUsers();
        }

        public void UpdateUser(User user)
        {
            UserCtr.UpdateUser(user);
        }

        public void DeleteUser(int UserID)
        {
            UserCtr.DeleteUser(UserID);
        }

        public bool Login(string username, string password)
        {
            return UserCtr.Login(username, password);
        }

        public void createWalletAndFavorites(int userid)
        {
            UserCtr.createFavoritesAndWallet(userid);
        }
    }
}
