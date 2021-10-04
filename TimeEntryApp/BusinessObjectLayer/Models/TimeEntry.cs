using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObjectLayer.Models
{
    public partial class TimeEntry
    {
        public TimeEntry()
        {
            Breaks = new HashSet<Break>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Break> Breaks { get; set; }
    }
}
