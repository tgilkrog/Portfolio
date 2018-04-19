using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using ModelLayer;

namespace BusinessLayer
{
    public class OrderController
    {
        OrderDB oDb;
        UserController usCtr;
        CustomerController cuCtr;

        public OrderController()
        {
            oDb = new OrderDB();
            usCtr = new UserController();
            cuCtr = new CustomerController();
        }
        /*Denne metode tager en order ind i som parameter og kalder videre til database lageret med den givne order*/
        public void CreateOrder(Order order)
        {
            oDb.CreateOrder(order);
        }

        /*Denne metode tager et int kaldet ID in som parameter, kalderen metode i database lageret*/
        public Order GetOrder(int ID)
        {
            return oDb.GetOrder(ID);
        }

        /*Denne metode returner en liste af orders*/
        public IEnumerable<Order> getAllOrders()
        {
            return oDb.GetAllOrders();
        }

        /*Denne metode kalder getAllOrders() i database lagert og vælger dem ud som har det bestemte userID*/
        public IEnumerable<Order> GetOrdersByUserID(int userID)
        {
            List<Order> userOrders = new List<Order>();
            foreach(var order in oDb.GetAllOrders())
            {
                if(order.User.ID == userID)
                {
                    userOrders.Add(order);
                }
            }
            return userOrders;
        }

        /*Denne metode bruges til at ændre status på order til complete*/
        public void CompleteOrder(Order order)
        {
            oDb.CompleteOrder(order);
        }

        /*Denne metode henter en user med username og kalder metoden i user controller, dette gøres da vi skal bruge denne metode
         og det kan give problemer i websitet hvis den kaldes i en anden service reference*/
        public User getUser(string username)
        {
            return usCtr.GetUserByUserName(username);
        }

        public Customer getCustomer(int id)
        {
            return cuCtr.GetCustomer(id);
        }

        public Order GetOrderByStatus(string status)
        {
            return oDb.GetOrderByStatus(status);
        }
        public void DeleteOrderByID(int ID)
        {
           oDb.DeleteOrderByID(ID);
        }

        public void UpdatePrice(Order order, decimal price)
        {
            oDb.updateTotalPrice(order, price);
        }

        /*Denne metode henter antallet af ting i en order, ved at logge alle orderlines amount sammen, denne bruges til websitet
         ved siden af indkøbskurven*/
        public int getAmountOfItemsInOrder(string Username)
        {
            int j = 0;
            List<Order> orders = GetOrdersByUserID(getUser(Username).ID).ToList();

            if (orders.Count() > 0)
            {
                int i = orders.Count() - 1;
               

                if (orders[i].Status.Equals("Incomplete"))
                {
                    foreach (var item in orders[i].OrderLines)
                    {
                        j = j + item.Amount;

                    }
                } 
            }
           return j;
        }

        public int getLastOrderIDByUser(string Username)
        {
            int id = 0;
            List<Order> orders = GetOrdersByUserID(getUser(Username).ID).ToList();
            if (orders.Count() > 0)
            {
                int i = orders.Count() - 1;
                id = orders[i].ID;
            }
            return id;
        }
    }
}

    

