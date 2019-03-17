using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Subscription
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public bool Notification { get; set; }
    }
}
