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
    public class WalletDB
    {
        UserDB userDB = new UserDB();
        private readonly string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void CreateWallet(Wallet Wallet)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into dbo.Wallet(Balance, MaxBalance, MinBalance, LockTime, userId) values(@Balance, @MaxBalance, @MinBalance, @LockTime, @userId)";
                    //cmd.Parameters.AddWithValue("id", entity.Id);
                    cmd.Parameters.AddWithValue("Balance", Wallet.Balance);
                    cmd.Parameters.AddWithValue("MaxBalance", Wallet.MaxBalance);
                    cmd.Parameters.AddWithValue("MinBalance", Wallet.MinBalance);
                    cmd.Parameters.AddWithValue("LockTime", Wallet.LockTime);
                    cmd.Parameters.AddWithValue("userId", Wallet.User.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Wallet GetWallet(int id)
        {
            Wallet wallet = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From Wallet Where userId = @userId";
                    cmd.Parameters.AddWithValue("userId", id);
                    var Reader = cmd.ExecuteReader();
                    while (Reader.Read())
                    {
                        wallet = new Wallet
                        {
                            ID = (int)Reader["id"],
                            Balance = (decimal)Reader["Balance"],
                            MaxBalance = (decimal)Reader["MaxBalance"],
                            MinBalance = (decimal)Reader["MinBalance"],
                            LockTime = (DateTime)Reader["LockTime"],
                            User = userDB.GetUser((int)Reader["userId"])
                        };
                    }
                }
            }
            return wallet;
        }
        public IEnumerable<Wallet> GetAllWallets()
        {
            List<Wallet> WalletList = new List<Wallet>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Wallet";
                    var Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        Wallet wallet = new Wallet
                        {
                            ID = (int)Reader["id"],
                            Balance = (decimal)Reader["Balance"],
                            MaxBalance = (decimal)Reader["MaxBalance"],
                            MinBalance = (decimal)Reader["MinBalance"],
                            LockTime = (DateTime)Reader["LockTime"],
                            User = userDB.GetUser((int)Reader["userId"])
                        };
                        WalletList.Add(wallet);
                    }
                }

            }
            return WalletList;
        }

        public void updateBalanceByUserID(decimal balance, int userId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Update Wallet SET Balance = @Balance  WHERE userId = @userId";
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("Balance", balance);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

