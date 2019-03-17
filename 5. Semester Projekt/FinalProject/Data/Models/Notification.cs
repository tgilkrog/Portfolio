using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NoteText { get; set; }
    }
}
