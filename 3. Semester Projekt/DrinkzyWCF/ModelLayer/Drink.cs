using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    [KnownType(typeof(SuperAlchohol))]
    public class Drink : SuperAlchohol
    {
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public List<Ingredient> Ingredients  { get; set; }

        public Drink(int ID, string Name, string Description, decimal Price, string Img)
        {
            base.ID = ID;
            base.Name = Name;
            this.Description = Description;
            base.Price = Price;
            base.Img = Img;
            Ingredients = new List<Ingredient>();
        }

        public Drink()
        {

        }
    }
}
