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
    public class IngredientsDB
    {
        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void CreateIngredient(Ingredient ingredient)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.Ingredient(ingName, Procent) values(@ingName, @Procent)";
                    //cmd.Parameters.AddWithValue("id", entity.Id);
                    cmd.Parameters.AddWithValue("ingName", ingredient.Name);
                    cmd.Parameters.AddWithValue("Procent", ingredient.Procent);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Ingredient GetIngredient(int id)
        {
            Ingredient ingredient = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From Ingredient Where id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        ingredient = new Ingredient
                        {
                            ID = (int)Reader["id"],
                            Name = (string)Reader["ingName"],
                            Procent = (decimal)Reader["Procent"]
                        };
                    }
                }
            }
            return ingredient;
        }
        public void DeleteIngredient(int IngID)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Delete From dbo.Ingredient Where id = @id";
                    cmd.Parameters.AddWithValue("id", IngID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateIngredient(Ingredient ingredient)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Update Ingredient SET ingName =@ingName, Procent = @Procent WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", ingredient.ID);
                    cmd.Parameters.AddWithValue("ingName", ingredient.Name);
                    cmd.Parameters.AddWithValue("Procent", ingredient.Procent);
                    cmd.ExecuteNonQuery();
                }
            }
        }


     public IEnumerable<Ingredient> GetAllIngredients()
        {
            List<Ingredient> IngredientList = new List<Ingredient>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Ingredient";
                    var Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        Ingredient a = new Ingredient
                        {
                            ID = (int)Reader["id"],
                            Name = (string)Reader["ingName"],
                            Procent = (decimal)Reader["Procent"]
                        };
                        IngredientList.Add(a);
                    }
                }

            }
            return IngredientList;
        }
    }
}