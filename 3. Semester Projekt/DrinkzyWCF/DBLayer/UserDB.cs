using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;

namespace DBLayer
{
    public class UserDB
    {
        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void CreateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    var salt = HashingHelper.GenerateSalt();
                    string saltedHash = HashingHelper.HashPassword(user.Password, salt);

                    cmd.CommandText = "Insert Into dbo.DrinkzyUser(UserName, FirstName, LastName, Gender, Birthday, userPassword, Salt, Email, Phone ) values(@UserName, @FirstName, @LastName, @Gender, @Birthday, @userPassword, @Salt, @Email, @Phone)";
                    //cmd.Parameters.AddWithValue("id", entity.Id);
                    cmd.Parameters.AddWithValue("UserName", user.UserName);
                    cmd.Parameters.AddWithValue("FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("LastName", user.LastName);
                    cmd.Parameters.AddWithValue("Gender", user.Gender);
                    cmd.Parameters.AddWithValue("Birthday", user.Birthday);
                    cmd.Parameters.AddWithValue("userPassword", saltedHash);
                    cmd.Parameters.AddWithValue("salt", salt);
                    cmd.Parameters.AddWithValue("Email", user.Email);
                    cmd.Parameters.AddWithValue("Phone", user.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public User GetUser(int id)
        {
            FavoritesDB fDB = new FavoritesDB();
            User user = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From DrinkzyUser Where id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        user = new User
                        {
                            ID = (int)Reader["id"],
                            UserName = (string)Reader["userName"],
                            FirstName = (string)Reader["firstName"],
                            LastName = (string)Reader["lastName"],
                            Gender = (string)Reader["gender"],
                            Birthday = (DateTime)Reader["birthday"],
                            Password = (string)Reader["userPassword"],
                            Email = (string)Reader["email"],
                            Phone = (string)Reader["phone"],
                            FavoritesDrinks = fDB.GetAllDrinksByUser(fDB.GetFavoritesByUserID((int)Reader["id"]).ID)
                        };
                    }
                }
            }
            return user;
        }

        public IEnumerable<User> getAllUsers()
        {
            List<User> UserList = new List<User>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM DrinkzyUser";
                    var Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        User u = new User
                        {
                            ID = (int)Reader["id"],
                            UserName = (string)Reader["UserName"],
                            FirstName = (string)Reader["FirstName"],
                            LastName = (string)Reader["LastName"],
                            Gender = (string)Reader["Gender"],
                            Birthday = (DateTime)Reader["Birthday"],
                            Password = (string)Reader["userPassword"],
                            Email = (string)Reader["Email"],
                            Phone = (string)Reader["Phone"]

                        };
                        UserList.Add(u);
                    }
                }

            }
            return UserList;
        }
        public void UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Update DrinkzyUser SET userName =@userName, firstName = @firstName, lastName = @lastName, gender = @gender, birthday = @birthday, userPassword = @userPassword, email = @email, phone = @phone WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", user.ID);
                    cmd.Parameters.AddWithValue("userName", user.UserName);
                    cmd.Parameters.AddWithValue("firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("lastName", user.LastName);
                    cmd.Parameters.AddWithValue("gender", user.Gender);
                    cmd.Parameters.AddWithValue("birthday", user.Birthday);
                    cmd.Parameters.AddWithValue("userPassword", user.Password);
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("phone", user.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteUser(int UserID)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Delete From dbo.DrinkzyUser Where id = @id";
                    cmd.Parameters.AddWithValue("id", UserID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool Login(string username, string password)
        {
            bool loggedIn = false;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    string sql = "SELECT * FROM DrinkzyUser WHERE userName=@userName";
                    cmd.Parameters.AddWithValue("userName", username);

                    cmd.CommandText = sql;
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string currentSalt = rdr.GetString(rdr.GetOrdinal("Salt"));
                        string currentSaltedHash = rdr.GetString(rdr.GetOrdinal("userPassword"));
                        if (HashingHelper.CheckPassword(password, currentSalt, currentSaltedHash))
                        {
                            loggedIn = true;
                        }
                    }
                }
            }
            return loggedIn;
        }
    }
}

    


