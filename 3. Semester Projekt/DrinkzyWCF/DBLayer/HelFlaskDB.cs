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
    public class HelFlaskDB
    {
        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void CreateHelFlask(HelFlask helflask)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.Alchohol(alcName, alcProcent, alcPrice, alcImg) values(@alcName, @alcProcent, @alcPrice, @alcImg)";
                    //cmd.Parameters.AddWithValue("id", entity.Id);
                    cmd.Parameters.AddWithValue("helName", helflask.Name);
                    cmd.Parameters.AddWithValue("helPrice", helflask.Price);
                    cmd.Parameters.AddWithValue("helImg", helflask.Img);
                    cmd.Parameters.AddWithValue("helProcent", helflask.Procent);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public HelFlask GetHelFlask(int id)
        {
            HelFlask helflask = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From Helflask Where id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        helflask = new HelFlask
                        {
                            ID = (int)Reader["id"],
                            Name = (string)Reader["helName"],
                            Procent = (decimal)Reader["helProcent"],
                            Price = (decimal)Reader["helPrice"],
                            Img = (string)Reader["HelImg"]
                        };
                    }
                }
            }
            return helflask;
        }

        public IEnumerable<HelFlask> GetAllHelflasks()
        {
            List<HelFlask> helflaskList = new List<HelFlask>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Helflask";
                    var Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        HelFlask a = new HelFlask
                        {
                            ID = (int)Reader["id"],
                            Name = (string)Reader["helName"],
                            Procent = (decimal)Reader["helProcent"],
                            Price = (decimal)Reader["helPrice"],
                            Img = (string)Reader["helImg"]
                        };
                        helflaskList.Add(a);
                    }
                }

            }
            return helflaskList;
        }
    }
}
