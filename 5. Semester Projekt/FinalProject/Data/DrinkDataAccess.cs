using Data.Models;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public class DrinkDataAccess : BaseDataAccess, IDataAccess<Drink>
    {
        public DrinkDataAccess(string connection) : base(connection)
        {
        }

        /// <summary>
        /// Gets all the drinks from the database.
        /// </summary>
        /// <returns>A list of all drinks</returns>
        public async Task<List<Drink>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Drink] as d", connection);
                await connection.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();
                List<Drink> drinks = new List<Drink>();

                //Gets the drinks and add them immideatly to the drinks list.
                while (reader.Read())
                {
                    drinks.Add(new Drink()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Image = reader.GetString(2),
                        Description = reader.GetString(3)
                    });
                }
                return drinks;
            };
        }

        /// <summary>
        /// Gets a Drink with a specified id.
        /// </summary>
        /// <param name="id">The unique drink ID</param>
        /// <returns>the specified drink</returns>
        public async Task<Drink> GetAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Drink] as d WHERE d.id = @id", connection);
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                await connection.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();
                Drink drink = new Drink();
                //Gets the drinks
                while (reader.Read())
                {
                    drink = new Drink()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Image = reader.GetString(2),
                        Description = reader.GetString(3)
                    };
                }
                return drink;
            };
        }

        /// <summary>
        /// Searched for a drink in the drinks description, with a specifed string.
        /// </summary>
        /// <param name="search">The specified string for searching</param>
        /// <returns>A list of drinks</returns>
        public async Task<List<Drink>> SearchAsync(string search)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Drink] as d WHERE d.DriDescription LIKE @search", connection);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                await connection.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();
                List<Drink> drinks = new List<Drink>();
                while (reader.Read())
                {
                    drinks.Add(new Drink()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Image = reader.GetString(2),
                        Description = reader.GetString(3)
                    });
                }
                return drinks;
            }; 
        }

        public Task<List<Drink>> GetListWhereAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Drink> InsertAsync(Drink item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Drink item)
        {
            throw new NotImplementedException();
        }
    }
}
