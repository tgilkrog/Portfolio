using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class CustomerFilters
    {
        public int Id { get; set; }
        public bool Gambling { get; set; }
        public bool Dancing { get; set; }
        public bool Food { get; set; }
        public bool Sleep { get; set; }
    }
}
