using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using BusinessLayer;

namespace WCF
{
    public class OrderService : IOrderService
    {
        OrderController oCtr = new OrderController();
        public void CreateOrder(Order order)
        {
            oCtr.CreateOrder(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return oCtr.getAllOrders();
        }

        public IEnumerable<Order> GetOrdersByUserId(int userID)
        {
            return oCtr.GetOrdersByUserID(userID);
        }

        public Order GetOrder(int ID)
        {
            return oCtr.GetOrder(ID);
        }

        public void CompleteOrder(Order order)
        {
            oCtr.CompleteOrder(order);
        }

        public Order GetOrderByStatus(string status)
        {
            return oCtr.GetOrderByStatus(status);
        }
        public User GetUser(string username)
        {
            return oCtr.getUser(username);
        }

        public Customer GetCustomer(int id)
        {
            return oCtr.getCustomer(id);
        }

        public void DeleteOrderByID(int ID)
        {
            oCtr.DeleteOrderByID(ID);
        }

        public void UpdatePrice(Order order, decimal price)
        {
            oCtr.UpdatePrice(order, price);
        }

        public int getAmountOfItemsInOrder(string username)
        {
            return oCtr.getAmountOfItemsInOrder(username);
        }

        public int getLastOrderIDByUser(string Username)
        {
            return oCtr.getLastOrderIDByUser(Username);
        }
    }
}
