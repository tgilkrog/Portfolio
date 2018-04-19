using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    [KnownType(typeof(Drink))]
    [KnownType(typeof(Alchohol))]
    [KnownType(typeof(HelFlask))]
    public abstract class SuperAlchohol
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public string Img { get; set; }
    }
}
