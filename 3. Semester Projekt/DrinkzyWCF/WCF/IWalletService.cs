using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    [ServiceContract]
    public interface IWalletService
    {
        [OperationContract]
        void CreateWallet(Wallet wallet);

        [OperationContract]
        Wallet GetWallet(int id);

        [OperationContract]
        IEnumerable<Wallet> GetAllWallet();

        [OperationContract]
        void UpdateBalanceByUserId(decimal Balance, int userID);

        [OperationContract]
        User GetUserById(int id);

        [OperationContract]
        Wallet getWalletByUsername(string name);
    }
}
