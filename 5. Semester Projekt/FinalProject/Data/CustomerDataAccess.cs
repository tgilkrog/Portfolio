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
    public class CustomerDataAccess : BaseDataAccess, IDataAccess<Customer>
    {
        public CustomerDataAccess(string connection) : base(connection)
        {
        }

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>A list with all customers</returns>
        public async Task<List<Customer>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Customer] as c " +
                    "INNER JOIN dbo.CustomerFilters AS filters ON filters.customerId = c.id " +
                    "INNER JOIN dbo.CustomerType AS cusType ON cusType.Id = c.CusTypeId", connection);
                await connection.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();
                List<Customer> customersList = new List<Customer>();
                CustomerFilters filter = new CustomerFilters();
                
                //Gets the customer
                while (reader.Read())
                {
                    //Gets the customer filters.
                    filter = new CustomerFilters()
                    {
                        Id = reader.GetInt32(9),
                        Gambling = reader.GetBoolean(11),
                        Dancing = reader.GetBoolean(12),
                        Sleep = reader.GetBoolean(13),
                        Food = reader.GetBoolean(14)
                    };
                    //Gets a customer
                    Customer cus = new Customer()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Image = reader.GetString(2),
                        City = reader.GetString(3),
                        Address = reader.GetString(4),
                        Postal = reader.GetInt32(5),
                        Phone = reader.GetString(6),
                        Email = reader.GetString(7),
                        Filters = new CustomerFilters(),
                        Type = reader.GetString(16)
                    };
                    //Adds the filters to the customer
                    cus.Filters = filter;
                    //Add the customer to the list
                    customersList.Add(cus);
                }
                return customersList;
            }
        }

        /// <summary>
        /// Gets a list of customers by a specified postalcode or city name
        /// </summary>
        /// <param name="postal">The specified postal code</param>
        /// <param name="city">The specified city name</param>
        /// <returns>A list of custuomers</returns>
        public async Task<List<Customer>> getListByPostalName(int postal, string city)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Customer] as c " +
                    "INNER JOIN dbo.CustomerFilters AS filters ON filters.customerId = c.id " +
                    "INNER JOIN dbo.CustomerType AS cusType ON cusType.Id = c.CusTypeId " +
                    "WHERE c.CusPostal = @postal OR c.CusCity = @city", connection);

                cmd.Parameters.AddWithValue("@postal", SqlDbType.Int).Value = postal;
                cmd.Parameters.AddWithValue("@city", SqlDbType.VarChar).Value = city;
                await connection.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();
                List<Customer> customerList = new List<Customer>();
                CustomerFilters filter = new CustomerFilters();

                while (reader.Read())
                {
                    //Gets the filters for customer
                    filter = new CustomerFilters()
                    {
                        Id = reader.GetInt32(9),
                        Gambling = reader.GetBoolean(11),
                        Dancing = reader.GetBoolean(12),
                        Sleep = reader.GetBoolean(13),
                        Food = reader.GetBoolean(14)
                    };
                    //Gets the customer
                    Customer cus = new Customer()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Image = reader.GetString(2),
                        City = reader.GetString(3),
                        Address = reader.GetString(4),
                        Postal = reader.GetInt32(5),
                        Phone = reader.GetString(6),
                        Email = reader.GetString(7),
                        Filters = new CustomerFilters(),
                        Type = reader.GetString(16)
                    };
                    //Adds the filters to the customer
                    cus.Filters = filter;
                    //Adds the customer to the list
                    customerList.Add(cus);
                }
                return customerList;
            }
        }

        /// <summary>
        /// Gets a customer by a specified ID
        /// </summary>
        /// <param name="id">The unique customer ID</param>
        /// <returns>A customer</returns>
        public async Task<Customer> GetAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //First it gets the customer
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Customer] as cus WHERE cus.Id = @id; " +
                    
                    //Gets the customers menucard, and the menucard drinks
                    "SELECT menu.id, drink.id, drink.DriName, drink.DriIMG, drink.DriDescription FROM dbo.Customer AS cus " +
                    "INNER JOIN dbo.MenuCard AS menu ON menu.customerID = cus.id " +
                    "INNER JOIN dbo.MenucardDrinks AS menuDrink ON menuDrink.menuID = menu.id " +
                    "INNER JOIN dbo.Drink AS drink ON drink.id = menuDrink.drinkid " +
                    "WHERE cus.id = @id; " +

                    //Gets the customers events
                    "SELECT cusEvent.id, cusEvent.Title, cusEvent.EventDescription, cusEvent.EventDate, cusEvent.customerID" +
                    ", count(usEvent.UserId) " +
                    "FROM dbo.CustomerEvents as cusEvent " +
                    "LEFT JOIN dbo.UserEvent as usEvent on usEvent.EventId = cusEvent.id " +
                    "WHERE cusEvent.customerID = @id " + 
                    "GROUP BY cusEvent.id, cusEvent.Title, cusEvent.EventDescription, cusEvent.EventDate, cusEvent.customerID; " +
                    
                    //Gets the customer news
                    "SELECT * FROM dbo.CustomerNews AS cusNews WHERE cusNews.customerID = @id; " +

                    //Gets the user ID's and emails for users who are signed the events
                    "SELECT subs.drinkUserID, dUser.Email FROM dbo.Subscription as subs " +
                    "LEFT JOIN dbo.DrinkUser as dUser on dUser.id = subs.drinkUserID " +
                    "WHERE subs.customerID = @id; ", connection);

                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                await connection.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();
                Customer customer = new Customer();

                while (reader.Read())
                {
                    //Gets the customer
                    customer = new Customer
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Image = reader.GetString(2),
                        City = reader.GetString(3),
                        Address = reader.GetString(4),
                        Postal = reader.GetInt32(5),
                        Phone = reader.GetString(6),
                        Email = reader.GetString(7)
                    };
                }

                reader.NextResult();
                Menucard menucard = new Menucard();
                menucard.Drinks = new List<Drink>();
                while (reader.Read())
                {
                    //Gets the menucard
                    menucard.Id = reader.GetInt32(0);

                    //Gets the drinks and adds them to a list
                    menucard.Drinks.Add(new Drink()
                    {
                        Id = reader.GetInt32(1),
                        Name = reader.GetString(2),
                        Image = reader.GetString(3),
                        Description = reader.GetString(4)
                    });
                }
                customer.Menucard = menucard;

                reader.NextResult();
                List<CustomerEvents> events = new List<CustomerEvents>();
                while (reader.Read())
                {
                    //Gets the customer events
                    events.Add(new CustomerEvents()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        Date = reader.GetDateTime(3),
                        NumberOfUsers = reader.GetInt32(5)
                    });
                }
                customer.Events = events;

                reader.NextResult();
                List<CustomerNews> news = new List<CustomerNews>();
                while (reader.Read())
                {
                    //Gets the customer news
                    news.Add(new CustomerNews()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        Date = reader.GetDateTime(3)
                    });
                }
                customer.News = news;

                reader.NextResult();
                List<int> subsIds = new List<int>();
                while (reader.Read())
                {
                    //Gets the subscripted user Id's
                    subsIds.Add(reader.GetInt32(0));
                }
                customer.SubsId = subsIds;
                return customer;
            }
        }
        
        /// <summary>
        /// Seach for a customer by a string.
        /// </summary>
        /// <param name="search">The specified string for searching with</param>
        /// <returns>A list of customers</returns>
        public async Task<List<Customer>> SearchAsync(string search)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Customer] AS cus WHERE cus.CusName LIKE @search", connection);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                await connection.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();
                List<Customer> customers = new List<Customer>();
                //Gets the customer
                while (reader.Read())
                {
                    customers.Add( new Customer
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Image = reader.GetString(2),
                        City = reader.GetString(3),
                        Address = reader.GetString(4),
                        Postal = reader.GetInt32(5),
                        Phone = reader.GetString(6),
                        Email = reader.GetString(7)
                    });
                }
                return customers;
            }
        }

        /// <summary>
        /// Inserts an Event for a specified customer
        /// </summary>
        /// <param name="cusEvent">The event to be inserted</param>
        /// <param name="cusId">The unique customer ID</param>
        /// <returns>An event</returns>
        public async Task<CustomerEvents> InsertEvent(CustomerEvents cusEvent, int cusId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[CustomerEvents] (Title, EventDescription, EventDate, customerId) "
                    + "VALUES (@title, @eventDescription, @eventDate, @customerId)", connection);
                cmd.Parameters.AddWithValue("@title", SqlDbType.VarChar).Value = cusEvent.Title;
                cmd.Parameters.AddWithValue("@eventDescription", SqlDbType.VarChar).Value = cusEvent.Description;
                cmd.Parameters.AddWithValue("@eventDate", SqlDbType.Date).Value = cusEvent.Date;
                cmd.Parameters.AddWithValue("@customerId", SqlDbType.Int).Value = cusId;

                await connection.OpenAsync();
                int result = await cmd.ExecuteNonQueryAsync();
            }
            return cusEvent;
        }

        /// <summary>
        /// Inserts a news for a specified customer
        /// </summary>
        /// <param name="cusNews">The news to be inserted</param>
        /// <param name="cusId">The unique customer ID</param>
        /// <returns>A news</returns>
        public async Task<CustomerNews> InsertNews(CustomerNews cusNews, int cusId)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO [dbo].[CustomerNews] (Title, NewsDescription, NewsDate, customerId) "
                    + "VALUES (@title, @newsDescription, @newsDate, @customerId)", connection);
                cmd.Parameters.AddWithValue("@title", SqlDbType.VarChar).Value = cusNews.Title;
                cmd.Parameters.AddWithValue("@newsDescription", SqlDbType.VarChar).Value = cusNews.Description;
                cmd.Parameters.AddWithValue("@newsDate", SqlDbType.Date).Value = cusNews.Date;
                cmd.Parameters.AddWithValue("@customerId", SqlDbType.Int).Value = cusId;

                await connection.OpenAsync();
                int result = await cmd.ExecuteNonQueryAsync();
            }
            return cusNews;
        }

        /// <summary>
        /// A bulk insert for notifications for users who a subscribed to the customer
        /// </summary>
        /// <param name="notifications">The notifications to be inserted</param>
        /// <returns>List of notifications</returns>
        public async Task<List<Notification>> InsertBulk(List<Notification> notifications)
        {
            //Creates a datatable with the specified method with notifications
            DataTable disTable = Converteren(notifications);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //Inserts into the database with the bulk insert
                using (var bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.BatchSize = disTable.Rows.Count;
                    bulkCopy.DestinationTableName = "dbo.Notifications";

                    bulkCopy.WriteToServer(disTable);
                }
            }
            return notifications;
        }

        /// <summary>
        /// Creates the datatable to be inserted with bulk insert
        /// </summary>
        /// <param name="notifications">The list of notifications to be inserted</param>
        /// <returns>A Data table</returns>
        public DataTable Converteren(List<Notification> notifications)
        {
            //Creates a new datatable with the specified columns
            DataTable newTable = new DataTable();
            newTable.Columns.Add("Id");
            newTable.Columns.Add("UserId");
            newTable.Columns.Add("NoteText");

            //insert the notifications into the rows of the datatable
            foreach (var item in notifications)
            {
                DataRow row = newTable.NewRow();
                row["Id"] = item.Id;
                row["UserId"] = item.UserId;
                row["NoteText"] = item.NoteText;

                newTable.Rows.Add(row);
            }
            return newTable;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetListWhereAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> InsertAsync(Customer item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Customer item)
        {
            throw new NotImplementedException();
        }

    }
}
