using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Postal { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Menucard Menucard { get; set; }
        public List<CustomerEvents> Events { get; set; }
        public List<CustomerNews> News { get; set; }
        public string Type { get; set; }
        public CustomerFilters Filters { get; set; }
        public List<int> SubsId { get; set; }
    }
}
