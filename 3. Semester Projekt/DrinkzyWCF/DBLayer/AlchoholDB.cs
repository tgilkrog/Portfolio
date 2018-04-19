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
    public class AlchoholDB
    {
        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void CreateAlchohol(Alchohol alchohol)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.Alchohol(alcName, alcProcent, alcPrice, alcImg) values(@alcName, @alcProcent, @alcPrice, @alcImg)";
                    //cmd.Parameters.AddWithValue("id", entity.Id);
                    cmd.Parameters.AddWithValue("alcName", alchohol.Name);
                    cmd.Parameters.AddWithValue("alcPrice", alchohol.Price);
                    cmd.Parameters.AddWithValue("alcImg", alchohol.Img);
                    cmd.Parameters.AddWithValue("alcProcent", alchohol.Procent);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public Alchohol GetAlchohol(int id)
        {
            Alchohol alchohol = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From Alchohol Where id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        alchohol = new Alchohol
                        {
                            ID = (int)Reader["id"],
                            Name = (string)Reader["alcName"],
                            Procent = (decimal)Reader["alcProcent"],
                            Price = (decimal)Reader["alcPrice"],
                            Img = (string)Reader["alcImg"]
                        };
                    }
                }
            }
            return alchohol;
        }

        public IEnumerable<Alchohol> GetAllAlchohols()
        {
            List<Alchohol> alchoholList = new List<Alchohol>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Alchohol";
                    var Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        Alchohol a = new Alchohol
                        {
                            ID = (int)Reader["id"],
                            Name = (string)Reader["alcName"],
                            Procent = (decimal)Reader["alcProcent"],
                            Price = (decimal)Reader["alcPrice"],
                            Img = (string)Reader["alcImg"]
                        };
                        alchoholList.Add(a);
                    }
                }

            }
            return alchoholList;
        }
    }
}
