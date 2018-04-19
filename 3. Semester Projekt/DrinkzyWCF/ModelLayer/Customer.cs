using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CusName { get; set; }
        [DataMember]
        public string Img { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string CusPassword { get; set; }

        public Customer(int ID, string CusName, string img, string Region, string Adress, string Phone, string Email, string cusPassword)
        {
            this.ID = ID;
            this.CusName = CusName;
            this.Img = Img;
            this.Region = Region;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.CusPassword = cusPassword;
        }

        public Customer()
        {

        }
    }
}
