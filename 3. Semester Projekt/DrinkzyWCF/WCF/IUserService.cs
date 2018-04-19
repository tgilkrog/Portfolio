using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ModelLayer;
using System.Threading.Tasks;

namespace WCF
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        void CreateUser(User user);

        [OperationContract]
        User GetUser(int id);

        [OperationContract]
        User GetUserByUserName(string username);

        [OperationContract]
        IEnumerable<User> getAllUsers();

        [OperationContract]
        void UpdateUser(User user);

        [OperationContract]
        void DeleteUser(int UserID);

        [OperationContract]
        bool Login(string username, string password);

        [OperationContract]
        void createWalletAndFavorites(int userid);

    }
}
