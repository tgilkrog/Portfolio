using System;
using ModelLayer;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class CustomerDB
    {
        
            private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void CreateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    var salt = HashingHelper.GenerateSalt();
                    string saltedHash = HashingHelper.HashPassword(customer.CusPassword, salt);

                    cmd.CommandText = "Insert Into dbo.DrinkzyCustomer(CusName, CusImg, CusRegion, CusAddress, CusPhone, CusEmail, cusPassword, cusSalt) values(@CusName, @CusImg, @CusRegion, @CusAddress, @CusPhone, @CusEmail, @cusPassword, @cusSalt)";
                    //cmd.Parameters.AddWithValue("id", entity.Id);
                    cmd.Parameters.AddWithValue("CusName", customer.CusName);
                    cmd.Parameters.AddWithValue("CusImg", customer.Img);
                    cmd.Parameters.AddWithValue("CusRegion", customer.Region);
                    cmd.Parameters.AddWithValue("CusAddress", customer.Address);
                    cmd.Parameters.AddWithValue("CusPhone", customer.Phone);
                    cmd.Parameters.AddWithValue("CusEmail", customer.Email);
                    cmd.Parameters.AddWithValue("cusPassword", saltedHash);
                    cmd.Parameters.AddWithValue("cusSalt", salt);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From DrinkzyCustomer Where id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        customer = new Customer
                        {
                            ID = (int)Reader["id"],
                            CusName = (string)Reader["CusName"],
                            Img = (string)Reader["CusImg"],
                            Region = (string)Reader["CusRegion"],
                            Address = (string)Reader["CusAddress"],
                            Phone = (string)Reader["CusPhone"],
                            Email = (string)Reader["CusEmail"]
                        };
                    }
                }
            }
            return customer;
        }

    public IEnumerable<Customer> GetAllCustomers()
            {
                List<Customer> CustomerList = new List<Customer>();
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    using (SqlCommand cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM DrinkzyCustomer";
                        var Reader = cmd.ExecuteReader();

                        while (Reader.Read())
                        {
                            Customer c = new Customer
                            {
                                ID = (int)Reader["id"],
                                CusName = (string)Reader["CusName"],
                                Img = (string)Reader["CusImg"],
                                Region = (string)Reader["CusRegion"],
                                Address = (string)Reader["CusAddress"],
                                Phone = (string)Reader["CusPhone"],
                                Email = (string)Reader["CusEmail"]

                            };
                            CustomerList.Add(c);
                        }
                    }

                }
                return CustomerList;
            }
        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Update DrinkzyCustomer SET cusName = @cusName, cusIMG = @cusIMG, cusRegion = @cusRegion, cusAddress = @cusAddress, cusPhone = @cusPhone, cusEmail = @cusEmail WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", customer.ID);
                    cmd.Parameters.AddWithValue("cusName", customer.CusName);
                    cmd.Parameters.AddWithValue("cusIMG", customer.Img);
                    cmd.Parameters.AddWithValue("cusRegion", customer.Region);
                    cmd.Parameters.AddWithValue("cusAddress", customer.Address);
                    cmd.Parameters.AddWithValue("cusPhone", customer.Phone);
                    cmd.Parameters.AddWithValue("cusEmail", customer.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCustomer(int CustomerId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Delete From dbo.DrinkzyCustomer Where id = @id";
                    cmd.Parameters.AddWithValue("id", CustomerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool Login(string cusEmail, string cusPassword)
        {
            bool loggedIn = false;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    string sql = "SELECT * FROM DrinkzyCustomer WHERE CusEmail=@CusEmail";
                    cmd.Parameters.AddWithValue("CusEmail", cusEmail);

                    cmd.CommandText = sql;
                    var rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string currentSalt = rdr.GetString(rdr.GetOrdinal("cusSalt"));
                        string currentSaltedHash = rdr.GetString(rdr.GetOrdinal("cusPassword"));
                        if (HashingHelper.CheckPassword(cusPassword, currentSalt, currentSaltedHash))
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

