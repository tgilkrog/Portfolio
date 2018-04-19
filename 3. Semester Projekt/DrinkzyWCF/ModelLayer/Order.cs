using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
   public class Order
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public decimal TotalPrice { get; set; }
        [DataMember]
        public decimal Discount { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public User User { get; set; }
        [DataMember]
        public IEnumerable<OrderLine> OrderLines { get; set; }
        [DataMember]
        public Customer Customer { get; set; }


        public Order(int ID, decimal TotalPrice, decimal Discount, DateTime Date, string Status, User User, Customer Customer)
        {
            this.ID = ID;
            this.TotalPrice = TotalPrice;
            this.Discount = Discount;
            this.Date = Date;
            this.Status = Status;
            this.User = User;
            this.Customer = Customer;
            OrderLines = new List<OrderLine>();
        }
        public Order()
        {

        }
    }
}
