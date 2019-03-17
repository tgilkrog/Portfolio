using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Subscription> Subscriptions { get; set; }
        public int CusId { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
