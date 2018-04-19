using DBLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class WalletController
    {
        WalletDB wDb;
        UserController uCtr;

        public WalletController()
        {
            wDb = new WalletDB();
            uCtr = new UserController();
        }

        public void CreateWallet(Wallet wallet)
        {
            wDb.CreateWallet(wallet);
        }

        public Wallet GetWallet(int id)
        {
            return wDb.GetWallet(id);
        }
        public IEnumerable<Wallet> GetAllWallets()
        {
            return wDb.GetAllWallets();
        }

        public void UpdateBalanceByUserID(decimal Balance, int userID)
        {
            wDb.updateBalanceByUserID(Balance, userID);
        }
        public User getUserById(int id)
        {
            return uCtr.GetUser(id);
        }

        public Wallet getWalletByUsername(string name)
        {
            Wallet wallet = GetWallet(uCtr.GetUserByUserName(name).ID);

            //foreach(Wallet w in GetAllWallets())
            //{
            //    if (w.User.UserName.Equals(name))
            //    {
            //        wallet = w;
            //    }
            //    else
            //    {
            //        wallet = null;
            //    }
            //}

            return wallet;
        }
    }
}
