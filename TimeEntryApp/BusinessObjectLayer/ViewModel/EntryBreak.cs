using BusinessObjectLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer.ViewModel
{
    public class EntryBreak
    {
        public int Id { get; set; }
        public IList<TimeEntry> entries { get; set; }
        public IList<Break> breaks { get; set; }
    }
}
