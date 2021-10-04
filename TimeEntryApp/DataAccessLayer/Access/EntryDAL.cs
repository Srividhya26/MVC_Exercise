using BusinessObjectLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public TimeEntry GetEntry(string id)
        {
            var entries = _db.TimeEntries.Find(id);

            return entries;
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

        public AspNetUser GetUser(string name)
        {
            SqlParameter pName = new SqlParameter("@Email", name);
            var existingUser = _db.AspNetUsers.FromSqlRaw($"select * from aspnetusers where Email = @Email", pName).FirstOrDefault();
            return existingUser;
        }
    }
}
