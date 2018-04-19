using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    public class Favorites
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public List<SuperAlchohol> Drinks { get; set; }
        [DataMember]
        public User User { get; set; }

        public Favorites() { }

        public Favorites(User User)
        {
            this.User = User;
            Drinks = new List<SuperAlchohol>();
        }
    }
}
