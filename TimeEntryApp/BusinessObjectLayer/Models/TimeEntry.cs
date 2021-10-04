using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObjectLayer.Models
{
    public partial class TimeEntry
    {
        #nullable disable
        public TimeEntry()
        {
            Breaks = new HashSet<Break>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime? InTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime? OutTime { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Break> Breaks { get; set; }
    }
}
