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
    public class FavoritesDB
    {
        private DrinkDB ddb = new DrinkDB();
        private AlchoholDB aDB = new AlchoholDB();
        private HelFlaskDB hfDB = new HelFlaskDB();
        private UserDB userDB = new UserDB();

        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void CreateFavorites(int userID)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.Favorites(userID) values(@userID)";
                    //cmd.Parameters.AddWithValue("id", OrderLine.ID);
                    cmd.Parameters.AddWithValue("userID", userID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void AddDrink(int userId, int drinkId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.FavoritesDrinks(favoritesID, drinkID) values(@favoritesID, @drinkID)";
                    //cmd.Parameters.AddWithValue("id", OrderLine.ID);
                    cmd.Parameters.AddWithValue("favoritesID", GetFavoritesByUserID(userId).ID);
                    cmd.Parameters.AddWithValue("drinkID", drinkId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddAlchohol(int userId, int drinkId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.FavoritesAlchohol(favoritesID, alchoholID) values(@favoritesID, @alchoholID)";
                    //cmd.Parameters.AddWithValue("id", OrderLine.ID);
                    cmd.Parameters.AddWithValue("favoritesID", GetFavoritesByUserID(userId).ID);
                    cmd.Parameters.AddWithValue("alchoholID", drinkId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddHelflask(int userId, int drinkId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.FavoritesHelflask(favoritesID, helflaskID) values(@favoritesID, @helflaskID)";
                    //cmd.Parameters.AddWithValue("id", OrderLine.ID);
                    cmd.Parameters.AddWithValue("favoritesID", GetFavoritesByUserID(userId).ID);
                    cmd.Parameters.AddWithValue("helflaskID", drinkId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Favorites GetFavoritesByUserID(int id)
        {
            Favorites favorites = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From Favorites Where userID = @userID";
                    cmd.Parameters.AddWithValue("userID", id);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        favorites = new Favorites
                        {
                            ID = (int)Reader["id"]
                            //User = userDB.GetUser((int)Reader["userID"]),
                            //Drinks = GetAllDrinksByUser((int)Reader["id"])
                        };
                    }
                }
            }
            return favorites;
        }

        public List<SuperAlchohol> GetAllDrinksByUser(int favoritesID)
        {
            List<SuperAlchohol> DrinksList = new List<SuperAlchohol>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM FavoritesDrinks WHERE favoritesID = @favoritesID";
                    cmd.Parameters.AddWithValue("favoritesID", favoritesID);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        Drink drink = ddb.GetDrink((int)Reader["drinkID"]);
                        DrinksList.Add(drink);
                    }
                }
                connection.Close();

                connection.Open();
                using (SqlCommand cmd2 = connection.CreateCommand())
                {
                    cmd2.CommandText = "SELECT * FROM FavoritesAlchohol WHERE favoritesID = @favoritesID";
                    cmd2.Parameters.AddWithValue("favoritesID", favoritesID);
                    var Reader2 = cmd2.ExecuteReader();
                    while (Reader2.Read())
                    {
                        Alchohol drink = aDB.GetAlchohol((int)Reader2["alchoholID"]);
                        DrinksList.Add(drink);
                    }
                }
                connection.Close();

                connection.Open();
                using (SqlCommand cmd3 = connection.CreateCommand())
                {
                    cmd3.CommandText = "SELECT * FROM FavoritesHelflask WHERE favoritesID = @favoritesID";
                    cmd3.Parameters.AddWithValue("favoritesID", favoritesID);
                    var Reader3 = cmd3.ExecuteReader();
                    while (Reader3.Read())
                    {
                        HelFlask drink = hfDB.GetHelFlask((int)Reader3["helflaskID"]);
                        DrinksList.Add(drink);
                    }
                }
            }
            return DrinksList;
        }
    }
}
