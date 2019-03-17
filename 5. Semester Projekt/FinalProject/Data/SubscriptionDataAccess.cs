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
    public class SubscriptionDataAccess : BaseDataAccess, IDataAccess<Subscription>
    {
        public SubscriptionDataAccess(string connection) : base(connection)
        {
        }

        /// <summary>
        /// Deletes a Subscription with a specified ID.
        /// </summary>
        /// <param name="id">The unique subscription ID</param>
        /// <returns>A true</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Subscription WHERE id = @id", connection);
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                await connection.OpenAsync();
                int result = await cmd.ExecuteNonQueryAsync();
            }
            return true;
        }

        /// <summary>
        /// Gets a list of subscriptions with a specified User ID, and subscriped customer info.
        /// </summary>
        /// <param name="id">The unique User ID</param>
        /// <returns>A list of subscriptions</returns>
        public async Task<List<Subscription>> GetListWhereAsync(int id)
        {
            List<Subscription> subscriptions = new List<Subscription>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM[dbo].[Subscription], [dbo].[Customer] WHERE drinkUserID = " +
                    "@drinkUserID AND customerID = Customer.id", connection);
                cmd.Parameters.AddWithValue("@drinkUserID", SqlDbType.Int).Value = id;
                await connection.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();

                Subscription subscription = new Subscription();
                Customer customer = new Customer();
                
                //Gets the subscription together with the customer.
                while (reader.Read())
                {
                    subscription = new Subscription
                    {
                        ID = reader.GetInt32(0),
                        Customer = new Customer {
                            Id = reader.GetInt32(4),
                            Name = reader.GetString(5),
                            Image = reader.GetString(6),
                            City = reader.GetString(7),
                            Address = reader.GetString(8),
                            Postal = reader.GetInt32(9),
                            Phone = reader.GetString(10),
                            Email = reader.GetString(11)
                        },
                        Notification = reader.GetBoolean(3)
                    };
                    //adds the subscription to the list
                    subscriptions.Add(subscription);
                }

            }
            return subscriptions;
        }

        /// <summary>
        /// Inserts a subscription, with a specified subscription.
        /// </summary>
        /// <param name="subscription">The specified subscription object</param>
        /// <returns>The subscription</returns>
        public async Task<Subscription> InsertAsync(Subscription subscription)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[Subscription] (drinkUserID, customerID, subNotification) "
                    + "VALUES (@drinkUserID, @customerID, @subNotification)", connection);
                cmd.Parameters.AddWithValue("@drinkUserID", SqlDbType.Int).Value = subscription.ID;
                cmd.Parameters.AddWithValue("@customerID", SqlDbType.Int).Value = subscription.Customer.Id;
                cmd.Parameters.AddWithValue("@subNotification", SqlDbType.Bit).Value = subscription.Notification;

                await connection.OpenAsync();
                int result = await cmd.ExecuteNonQueryAsync();
            }
            return subscription;
        }

        /// <summary>
        /// Inserts an eventUser, when a user signs on to an event
        /// </summary>
        /// <param name="eventUser">The specified eventUser</param>
        /// <returns>An EventUser</returns>
        public async Task<EventUser> InsertEventUser(EventUser eventUser)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[UserEvent] (EventId, UserId) VALUES (@eventId, @userId)", connection);
                cmd.Parameters.AddWithValue("@eventId", SqlDbType.Int).Value = eventUser.EventId;
                cmd.Parameters.AddWithValue("@userId", SqlDbType.Int).Value = eventUser.UserId;

                await connection.OpenAsync();
                int result = await cmd.ExecuteNonQueryAsync();
            }

            return eventUser;
        }

        /// <summary>
        /// Gets a list of events by a users ID.
        /// </summary>
        /// <param name="userId">The unique user ID</param>
        /// <returns>A list of Events</returns>
        public async Task<List<CustomerEvents>> GetListOfEventsByUser(int userId)
        {
            List<CustomerEvents> list = new List<CustomerEvents>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cmd = new SqlCommand("SELECT cusEvent.id, cusEvent.Title, cusEvent.EventDescription, " +
                    "cusEvent.EventDate, cusEvent.customerID FROM[dbo].[CustomerEvents] as cusEvent " +
                    "INNER JOIN dbo.UserEvent as usEvent ON usEvent.EventId = cusEvent.id WHERE usEvent.UserId = @userId", connection);

                cmd.Parameters.AddWithValue("@userId", SqlDbType.Int).Value = userId;
                await connection.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();

                //Gets the events
                while (reader.Read())
                {
                    //Adds the event immediately to the list.
                    list.Add(new CustomerEvents()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        Date = reader.GetDateTime(3)
                    });
                }
            }
            return list;
        }

        public Task<List<Subscription>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Subscription> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subscription>> SearchAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Subscription item)
        {
            throw new NotImplementedException();
        }
    }
}
