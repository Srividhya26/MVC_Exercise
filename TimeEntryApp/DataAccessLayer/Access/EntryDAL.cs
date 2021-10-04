using BusinessObjectLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Access
{
    public class EntryDAL
    {
        private readonly TimeEntryAppContext _db;
        public EntryDAL(TimeEntryAppContext db)
        {
            this._db = db;
        }

        public List<TimeEntry> GetEntry()
        {
            var entries = _db.TimeEntries.ToList();

            return entries;
        }

        public void SetEntry(TimeEntry entry)
        {
            _db.TimeEntries.Add(entry);
        }

        public void SetBreak(IList<Break> brks)
        {

            foreach (var brk in brks)
            {
                _db.Breaks.Add(brk);
            }
        }
    }
}
