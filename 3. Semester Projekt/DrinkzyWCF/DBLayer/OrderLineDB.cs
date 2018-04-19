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
    public class OrderLineDB
    {
        DrinkDB ddb = new DrinkDB();
        HelFlaskDB hfdb = new HelFlaskDB();
        AlchoholDB aDB = new AlchoholDB();
        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void CreateOrderLine(OrderLine OrderLine, int orderID)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.OrderLine(amount, totalPrice, drinkID, orderID) values(@amount, @totalPrice, @drinkID, @orderID)";
                    //cmd.Parameters.AddWithValue("id", OrderLine.ID);
                    cmd.Parameters.AddWithValue("amount", OrderLine.Amount);
                    cmd.Parameters.AddWithValue("totalPrice", OrderLine.TotalPrice);
                    cmd.Parameters.AddWithValue("drinkID", OrderLine.Drink.ID);
                    cmd.Parameters.AddWithValue("orderID", orderID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateOrderLineHelflask(OrderLine OrderLine, int orderID)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.OrderLineHelflask(amount, totalPrice, helflaskID, orderID) values(@amount, @totalPrice, @helflaskID, @orderID)";
                    //cmd.Parameters.AddWithValue("id", OrderLine.ID);
                    cmd.Parameters.AddWithValue("amount", OrderLine.Amount);
                    cmd.Parameters.AddWithValue("totalPrice", OrderLine.TotalPrice);
                    cmd.Parameters.AddWithValue("helflaskID", OrderLine.Drink.ID);
                    cmd.Parameters.AddWithValue("orderID", orderID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateOrderLineAlchohol(OrderLine OrderLine, int orderID)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.OrderLineAlchohol(amount, totalPrice, alchoholID, orderID) values(@amount, @totalPrice, @alchoholID, @orderID)";
                    //cmd.Parameters.AddWithValue("id", OrderLine.ID);
                    cmd.Parameters.AddWithValue("amount", OrderLine.Amount);
                    cmd.Parameters.AddWithValue("totalPrice", OrderLine.TotalPrice);
                    cmd.Parameters.AddWithValue("alchoholID", OrderLine.Drink.ID);
                    cmd.Parameters.AddWithValue("orderID", orderID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public OrderLine GetOrderLine(int ID)
        {
            OrderLine OrderLine = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From OrderLine Where id = @id";
                    cmd.Parameters.AddWithValue("id", ID);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        OrderLine = new OrderLine
                        {

                            ID = (int)Reader["id"],
                            Amount = (int)Reader["amount"],
                            TotalPrice = (decimal)Reader["totalPrice"],
                            Drink = ddb.GetDrink((int)Reader["drinkID"])
                        };
                    }
                }
            }
            return OrderLine;
        }
        public OrderLine GetOrderLineHelflask(int ID)
        {
            OrderLine OrderLine = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From OrderLineHelflask Where id = @id";
                    cmd.Parameters.AddWithValue("id", ID);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        OrderLine = new OrderLine
                        {

                            ID = (int)Reader["id"],
                            Amount = (int)Reader["amount"],
                            TotalPrice = (decimal)Reader["totalPrice"],
                            Drink = hfdb.GetHelFlask((int)Reader["helflaskID"])
                        };
                    }
                }
            }
            return OrderLine;
        }

        public OrderLine GetOrderLineAlchohol(int ID)
        {
            OrderLine OrderLine = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From OrderLineAlchohol Where id = @id";
                    cmd.Parameters.AddWithValue("id", ID);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        OrderLine = new OrderLine
                        {
                            ID = (int)Reader["id"],
                            Amount = (int)Reader["amount"],
                            TotalPrice = (decimal)Reader["totalPrice"],
                            Drink = aDB.GetAlchohol((int)Reader["alchoholID"])
                        };
                    }
                }
            }
            return OrderLine;
        }

        public IEnumerable<OrderLine> GetAllOrderLines()
        {
            List<OrderLine> OrderLineList = new List<OrderLine>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM OrderLine";
                    var Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        OrderLine ol = new OrderLine
                        {
                            ID = (int)Reader["id"],
                            Amount = (int)Reader["amount"],
                            TotalPrice = (decimal)Reader["TotalPrice"],
                            Drink = ddb.GetDrink((int)Reader["drinkID"])

                        };
                        OrderLineList.Add(ol);
                    }
                }
            }
            return OrderLineList;
        }

        public IEnumerable<OrderLine> GetAllOrderLinesByOrderID(int orderID)
        {
            List<OrderLine> OrderLineList = new List<OrderLine>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM OrderLine WHERE orderID = @orderID";
                    cmd.Parameters.AddWithValue("orderID", orderID);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        OrderLine ol = new OrderLine
                        {
                            ID = (int)Reader["id"],
                            Amount = (int)Reader["amount"],
                            TotalPrice = (decimal)Reader["TotalPrice"],
                            Drink = ddb.GetDrink((int)Reader["drinkID"])
                        };
                        OrderLineList.Add(ol);
                    }
                }
                connection.Close();

                connection.Open();
                using (SqlCommand cmd2 = connection.CreateCommand())
                {
                    cmd2.CommandText = "SELECT * FROM OrderLineHelflask WHERE orderID = @orderID";
                    cmd2.Parameters.AddWithValue("orderID", orderID);
                    var Reader2 = cmd2.ExecuteReader();
                    while (Reader2.Read())
                    {
                        OrderLine ol = new OrderLine
                        {
                            ID = (int)Reader2["id"],
                            Amount = (int)Reader2["amount"],
                            TotalPrice = (decimal)Reader2["TotalPrice"],
                            Drink = hfdb.GetHelFlask((int)Reader2["helflaskID"])
                        };
                        OrderLineList.Add(ol);
                    }
                }
                connection.Close();

                connection.Open();
                using (SqlCommand cmd2 = connection.CreateCommand())
                {
                    cmd2.CommandText = "SELECT * FROM OrderLineAlchohol WHERE orderID = @orderID";
                    cmd2.Parameters.AddWithValue("orderID", orderID);
                    var Reader2 = cmd2.ExecuteReader();
                    while (Reader2.Read())
                    {
                        OrderLine ol = new OrderLine
                        {
                            ID = (int)Reader2["id"],
                            Amount = (int)Reader2["amount"],
                            TotalPrice = (decimal)Reader2["TotalPrice"],
                            Drink = aDB.GetAlchohol((int)Reader2["alchoholID"])
                        };
                        OrderLineList.Add(ol);
                    }
                }
            }
            return OrderLineList;
        }

        public void DeleteOrderLineByID(int OrderLineId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Delete From dbo.OrderLine Where id = @id";
                    cmd.Parameters.AddWithValue("id", OrderLineId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAlchoholOrderLineByID(int OrderLineId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Delete From dbo.OrderLineAlchohol Where id = @id";
                    cmd.Parameters.AddWithValue("id", OrderLineId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteHelflaskOrderLineByID(int OrderLineId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Delete From dbo.OrderLineHelflask Where id = @id";
                    cmd.Parameters.AddWithValue("id", OrderLineId);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void EditOrderLine(OrderLine orderLine)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Update dbo.OrderLine SET amount = @amount, TotalPrice = @TotalPrice WHERE id=@id";
                    cmd.Parameters.AddWithValue("id", orderLine.ID);
                    cmd.Parameters.AddWithValue("amount", orderLine.Amount);
                    cmd.Parameters.AddWithValue("totalPrice", orderLine.TotalPrice);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditOrderLineHelflask(OrderLine orderLine)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Update dbo.OrderLineHelflask SET amount = @amount, TotalPrice = @TotalPrice WHERE id=@id";
                    cmd.Parameters.AddWithValue("id", orderLine.ID);
                    cmd.Parameters.AddWithValue("amount", orderLine.Amount);
                    cmd.Parameters.AddWithValue("totalPrice", orderLine.TotalPrice);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditOrderAlchohol(OrderLine orderLine)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Update dbo.OrderLineAlchohol SET amount = @amount, TotalPrice = @TotalPrice WHERE id=@id";
                    cmd.Parameters.AddWithValue("id", orderLine.ID);
                    cmd.Parameters.AddWithValue("amount", orderLine.Amount);
                    cmd.Parameters.AddWithValue("totalPrice", orderLine.TotalPrice);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
