using BusinessObjectLayer.Models;
using DataAccessLayer.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EntryBL
    {
        private readonly EntryDAL _entryDAL;
        public EntryBL(EntryDAL entryDAL)
        {
            this._entryDAL = entryDAL;
        }

        public List<TimeEntry> GetEntry()
        {
            var entries = _entryDAL.GetEntry();

            return entries;
        }

        public void SetEntry(TimeEntry entry)
        {
            _entryDAL.SetEntry(entry);
        }

        public void SetBreak(IList<Break> brk)
        {
            _entryDAL.SetBreak(brk);
        }
    }
}
