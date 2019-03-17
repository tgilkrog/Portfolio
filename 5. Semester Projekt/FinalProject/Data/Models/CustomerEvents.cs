using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class CustomerEvents
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfUsers { get; set; }
    }
}
