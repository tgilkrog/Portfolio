using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    public class Ingredient
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal Procent { get; set; }
        
        public Ingredient() { }

        public Ingredient(int ID, string Name, decimal Procent)
        {
            this.ID = ID;
            this.Name = Name;
            this.Procent = Procent;
        }
    }
}
