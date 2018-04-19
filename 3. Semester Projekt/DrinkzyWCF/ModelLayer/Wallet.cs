using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    public class Wallet
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public decimal Balance { get; set; }
        [DataMember]
        public decimal MaxBalance { get; set; }
        [DataMember]
        public decimal MinBalance { get; set; }
        [DataMember]
        public DateTime LockTime { get; set; }
        [DataMember]
        public User User { get; set; }

        public Wallet() { }
        public Wallet(int ID, decimal Balance, decimal MaxBalance, decimal MinBalance, DateTime LockTime, User User)
        {
            this.ID = ID;
            this.Balance = Balance;
            this.MaxBalance = MaxBalance;
            this.MinBalance = MinBalance;
            this.LockTime = LockTime;
            this.User = User;
        }
    }
}
