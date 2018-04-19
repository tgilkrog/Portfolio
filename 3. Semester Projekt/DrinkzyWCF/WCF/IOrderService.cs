using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace WCF
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        void CreateOrder(Order order);

        [OperationContract]
        Order GetOrder(int ID);

        [OperationContract]
        IEnumerable<Order> GetAllOrders();

        [OperationContract]
        IEnumerable<Order> GetOrdersByUserId(int userID);

        [OperationContract]
        void CompleteOrder(Order order);

        [OperationContract]
        Order GetOrderByStatus(string status);

        [OperationContract]
        User GetUser(string username);

        [OperationContract]
        Customer GetCustomer(int id);

        [OperationContract]
        void DeleteOrderByID(int ID);

        [OperationContract]
        void UpdatePrice(Order order, decimal price);

        [OperationContract]
        int getAmountOfItemsInOrder(string username);

        [OperationContract]
        int getLastOrderIDByUser(string Username);
    }
}
