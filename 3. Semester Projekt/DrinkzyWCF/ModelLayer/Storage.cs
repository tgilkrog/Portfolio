using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
   [DataContract]
   public class Storage
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public int MaxAmount { get; set; }
        [DataMember]
        public int MinAmount { get; set; }
        [DataMember]
        public SuperAlchohol Drink { get; set; }
        [DataMember]
        public Customer Customer { get; set; }

        public Storage() { }

        public Storage(int ID, int Amount, int MaxAmount, int MinAmount, SuperAlchohol Drink, Customer Customer)
        {
            this.ID = ID;
            this.Amount = Amount;
            this.MaxAmount = MaxAmount;
            this.MinAmount = MinAmount;
            this.Drink = Drink;
            this.Customer = Customer;
        }
    }

    
}
