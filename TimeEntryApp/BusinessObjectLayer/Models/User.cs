using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectLayer.Models
{
    public partial class User
    {
        public User()
        {
            TimeEntries = new HashSet<TimeEntry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Dob { get; set; }
        public string Address { get; set; }

        public virtual ICollection<TimeEntry> TimeEntries { get; set; }
    }
}
