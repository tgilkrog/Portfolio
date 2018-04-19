using ModelLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class OrderDB
    {
        UserDB uDB = new UserDB();
        CustomerDB cDB = new CustomerDB();
        OrderLineDB olDB = new OrderLineDB();
        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void CreateOrder(Order Order)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.DrinkzyOrder(totalprice, discount, orderDate, orderStatus, userID, customerID) values(@totalprice, @discount, @orderDate, @orderStatus, @userID, @customerID)";
                    //cmd.Parameters.AddWithValue("id", Order.ID);
                    cmd.Parameters.AddWithValue("totalprice", Order.TotalPrice);
                    cmd.Parameters.AddWithValue("discount", Order.Discount);
                    cmd.Parameters.AddWithValue("orderDate", Order.Date);
                    cmd.Parameters.AddWithValue("orderStatus", Order.Status);
                    cmd.Parameters.AddWithValue("userID", Order.User.ID);
                    cmd.Parameters.AddWithValue("customerID", Order.Customer.ID);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Order GetOrder(int ID)
        {
            Order Order = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From DrinkzyOrder Where id = @id";
                    cmd.Parameters.AddWithValue("id", ID);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        Order = new Order
                        {
                            ID = (int)Reader["id"],
                            TotalPrice = (decimal)Reader["totalPrice"],
                            Discount = (decimal)Reader["discount"],
                            Date = (DateTime)Reader["orderDate"],
                            Status = (string)Reader["orderStatus"],
                            User = uDB.GetUser((int)Reader["userID"]),
                            Customer = cDB.GetCustomer((int)Reader["customerID"]),
                            OrderLines = olDB.GetAllOrderLinesByOrderID(ID)
                        };
                    }
                }
            }
            return Order;
        }

        public Order GetOrderByStatus(string status)
        {
            Order Order = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From DrinkzyOrder Where orderStatus = @orderStatus";
                    cmd.Parameters.AddWithValue("orderStatus", status);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        Order = new Order
                        {
                            ID = (int)Reader["id"],
                            TotalPrice = (decimal)Reader["totalPrice"],
                            Discount = (decimal)Reader["discount"],
                            Date = (DateTime)Reader["orderDate"],
                            Status = (string)Reader["orderStatus"],
                            User = uDB.GetUser((int)Reader["userID"]),
                            Customer = cDB.GetCustomer((int)Reader["customerID"]),
                        };
                    }
                }
            }
            return Order;
        }
        public void DeleteOrderByID(int ID)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Delete From dbo.DrinkzyOrder Where id = @id";
                    cmd.Parameters.AddWithValue("id", ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IEnumerable<Order> GetAllOrders()
        {
            List<Order> OrderList = new List<Order>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    Order Order = null;
                    cmd.CommandText = "Select * From DrinkzyOrder";
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        Order = new Order
                        {
                            ID = (int)Reader["id"],
                            TotalPrice = (decimal)Reader["totalPrice"],
                            Discount = (decimal)Reader["discount"],
                            Date = (DateTime)Reader["orderDate"],
                            Status = (string)Reader["orderStatus"],
                            User = uDB.GetUser((int)Reader["userID"]),
                            Customer = cDB.GetCustomer((int)Reader["customerID"]),
                            OrderLines = olDB.GetAllOrderLinesByOrderID((int)Reader["id"])
                        };
                        OrderList.Add(Order);
                    }
                }

            }
            return OrderList;
        }

        public void CompleteOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Update DrinkzyOrder SET orderStatus = @orderStatus WHERE id=@id";
                    cmd.Parameters.AddWithValue("id", order.ID);
                    cmd.Parameters.AddWithValue("orderStatus", order.Status);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void updateTotalPrice(Order order, decimal price)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Update DrinkzyOrder SET totalPrice = @totalPrice WHERE id=@id";
                    cmd.Parameters.AddWithValue("id", order.ID);
                    cmd.Parameters.AddWithValue("totalPrice", price);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
