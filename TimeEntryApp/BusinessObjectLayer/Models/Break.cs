using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BusinessObjectLayer.Models
{
    public partial class Break
    {
        public int Id { get; set; }
        [DataType(DataType.Time)]
        public DateTime? BreakIn { get; set; }
        [DataType(DataType.Time)]
        public DateTime? BreakOut { get; set; }
        public int TimeEntryId { get; set; }

        public virtual TimeEntry TimeEntry { get; set; }
    }
}
