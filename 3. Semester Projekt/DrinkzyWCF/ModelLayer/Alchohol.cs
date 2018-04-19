using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    public class Alchohol : SuperAlchohol
    {
        [DataMember]
        public decimal Procent { get; set; }

        public Alchohol(int ID, string Name, decimal Price, string Img, decimal Procent)
        {
            base.ID = ID;
            base.Name = Name;
            base.Price = Price;
            base.Img = Img;
            this.Procent = Procent;
        }

        public Alchohol() { }
    }
}
