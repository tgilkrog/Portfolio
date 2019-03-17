using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserDataAccess : BaseDataAccess, IDataAccess<User>
    {
        SubscriptionDataAccess sda;
        public UserDataAccess(string connection) : base(connection)
        {
            CustomerDataAccess cda = new CustomerDataAccess(connection);
            sda = new SubscriptionDataAccess(connection);
        }

        /// <summary>
        /// Gets the user associated with the specified ID, with notifications, and subcriptions
        /// </summary>
        /// <param name="id">the unique user ID</param>
        /// <returns>A user</returns>
        public async Task<User> GetAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[DrinkUser] WHERE id = @id;" +
                    "SELECT TOP 10 * FROM [dbo].[Notifications] WHERE UserId = @id ORDER BY Id DESC", connection);
                await connection.OpenAsync();
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                var reader = await cmd.ExecuteReaderAsync();

                User user = new User();
                List<Subscription> subscriptions = new List<Subscription>();                
                
                //Gets the user 
                while (reader.Read())
                {
                    user = new User()
                    {
                        UserID = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                        Email = reader.GetString(4),
                        CusId = reader.GetInt32(5)
                    };
                    subscriptions = await sda.GetListWhereAsync(user.UserID);
                    user.Subscriptions = subscriptions;
                }
                
                reader.NextResult();
                List<Notification> notifications = new List<Notification>();
                
                //Gets the notifications
                while (reader.Read())
                {
                    notifications.Add( new Notification()
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        NoteText = reader.GetString(2)
                    });
                }
                user.Notifications = notifications;

                return user;
            }
        }

        /// <summary>
        /// Insert a User into the database, and salts a password.
        /// </summary>
        /// <param name="item">The user which will be inserted</param>
        /// <returns></returns>
        public async Task<User> InsertAsync(User item)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                //Create a salt and a salted password
                var salt = HashingHelper.GenerateSalt();
                string saltedHash = HashingHelper.HashPassword(item.Password, salt);

                var cmd = new SqlCommand("INSERT INTO [dbo].[DrinkUser] (Username, UserPassword, UserSalt, Email, CusId) "
                    + "VALUES (@username, @userPassword, @userSalt, @email, @cusId) ", connection);
                cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = item.Username;
                cmd.Parameters.AddWithValue("@userPassword", SqlDbType.VarChar).Value = saltedHash;
                cmd.Parameters.AddWithValue("@userSalt", SqlDbType.VarChar).Value = salt;
                cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = item.Email;
                cmd.Parameters.AddWithValue("@cusId", SqlDbType.Int).Value = 0;

                await connection.OpenAsync();
                int result = await cmd.ExecuteNonQueryAsync();
            }
            return item;
        }

        /// <summary>
        /// Method for getting a user, with a username and login, with help from hashinghelper.
        /// </summary>
        /// <param name="Username">The username for the specified user</param>
        /// <param name="Password">The password for the specified user</param>
        /// <returns>The user</returns>
        public async Task<User> Login(string Username, string Password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool loggedIn = false;

                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[DrinkUser] WHERE Username = @username", connection);
                cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar).Value = Username;
                await connection.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();

                User user = new User();
                while (reader.Read())
                {
                    //reads the salt and salted password
                    string currentSalt = reader.GetString(3);
                    string currentSaltedHash = reader.GetString(2);
                    if (HashingHelper.CheckPassword(Password, currentSalt, currentSaltedHash))
                    {
                        //if password and salt are correct, make loggedIn true
                        loggedIn = true;
                    }
                    if (loggedIn)
                    {
                        user = new User()
                        {
                            UserID = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Password = reader.GetString(2),
                            Email = reader.GetString(4),
                            CusId = reader.GetInt32(5)
                        };
                    }
                }
                return user;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetListWhereAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> SearchAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}
