using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using System.Data.SqlClient;

namespace DBLayer
{
    public class MenuCardDB
    {
        private DrinkDB ddb = new DrinkDB();
        private AlchoholDB adb = new AlchoholDB();
        private HelFlaskDB hfDB = new HelFlaskDB();
        private CustomerDB cusDB = new CustomerDB();

        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void CreateMenuCard(int CuID)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.MenuCard(customerID) values(@customerID)";
                    //cmd.Parameters.AddWithValue("id", OrderLine.ID);
                    cmd.Parameters.AddWithValue("customerID", CuID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddDrink(MenuCard menuCard, int drinkID)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.MenucardDrinks(menuID, drinkid) values(@menuID, @drinkid)";
                    //cmd.Parameters.AddWithValue("id", OrderLine.ID);
                    cmd.Parameters.AddWithValue("menuID", menuCard.ID);
                    cmd.Parameters.AddWithValue("drinkid", drinkID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public MenuCard GetMenuCardByCustomerID(int id)
        {
            MenuCard menuCard = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From MenuCard Where customerID = @customerID";
                    cmd.Parameters.AddWithValue("customerID", id);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        menuCard = new MenuCard
                        {
                            ID = (int)Reader["id"],
                            Customer = cusDB.GetCustomer((int)Reader["customerID"]),
                            Drinks = GetAllDrinksByCustomer((int)Reader["id"]),
                            alchohols = GetAllAlchoholsByMenu((int)Reader["id"]),
                            helflasks = GetAllHellflaskByMenu((int)Reader["id"])
                        };
                    }
                }
            }
            return menuCard;
        }

        public List<Drink> GetAllDrinksByCustomer(int cusId)
        {
            List<Drink> DrinksList = new List<Drink>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM MenucardDrinks WHERE menuID = @menuID";
                    cmd.Parameters.AddWithValue("menuID", cusId);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        Drink drink = ddb.GetDrink((int)Reader["drinkID"]);
                        DrinksList.Add(drink);
                    }
                }
            }
            return DrinksList;
        }

        public List<Alchohol> GetAllAlchoholsByMenu(int menuId)
        {
            List<Alchohol> AlchoholList = new List<Alchohol>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM MenucardAlchohol WHERE menuID = @menuID";
                    cmd.Parameters.AddWithValue("menuID", menuId);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        Alchohol drink = adb.GetAlchohol((int)Reader["alchoholID"]);
                        AlchoholList.Add(drink);
                    }
                }
            }
            return AlchoholList;
        }

        public List<HelFlask> GetAllHellflaskByMenu(int menuId)
        {
            List<HelFlask> HelflaskList = new List<HelFlask>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM MenucardHelflask WHERE menuID = @menuID";
                    cmd.Parameters.AddWithValue("menuID", menuId);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        HelFlask drink = hfDB.GetHelFlask((int)Reader["helflaskID"]);
                        HelflaskList.Add(drink);
                    }
                }
            }
            return HelflaskList;
        }

        public void DeleteDrinkFromMenu(int menuID, int drinkid)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Delete From dbo.MenucardDrinks Where menuID = @menuID AND drinkid = @drinkid";
                    cmd.Parameters.AddWithValue("menuID", menuID);
                    cmd.Parameters.AddWithValue("drinkid", drinkid);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
