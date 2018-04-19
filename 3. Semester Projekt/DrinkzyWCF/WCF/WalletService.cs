using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using BusinessLayer;

namespace WCF
{
    public class WalletService : IWalletService
    {
        WalletController wCtr;

        public WalletService()
        {
            wCtr = new WalletController();
        }
        public void CreateWallet(Wallet wallet)
        {
            wCtr.CreateWallet(wallet);
        }

        public IEnumerable<Wallet> GetAllWallet()
        {
            return wCtr.GetAllWallets();
        }

        public Wallet GetWallet(int id)
        {
            return wCtr.GetWallet(id);
        }

        public void UpdateBalanceByUserId(decimal Balance, int userID)
        {
            wCtr.UpdateBalanceByUserID(Balance, userID);
        }
        public User GetUserById(int id)
        {
            return wCtr.getUserById(id);
        }

        public Wallet getWalletByUsername(string name)
        {
            return wCtr.getWalletByUsername(name);
        }
    }
}
