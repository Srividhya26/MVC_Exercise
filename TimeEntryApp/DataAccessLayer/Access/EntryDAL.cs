
using BusinessObjectLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace DataAccessLayer.Access
{
    public class EntryDAL
    {
       
        private readonly AppDbContext _appDb;
        private readonly UserManager<ApplicationUser> _user;
        public EntryDAL(AppDbContext appDb, UserManager<ApplicationUser> user)
        {           
            _appDb = appDb;
            _user = user;
        }

        public TimeEntry GetEntry(string id)
        {
            var entries = _appDb.Entries.Find(id);

            return entries;
        }

        public List<TimeEntry> GetEntry()
        {
            var entries = _appDb.Entries.ToList();

            return entries;
        }

        public void SetEntry(TimeEntry entry)
        {
            _appDb.Entries.Add(entry);
        }

        public void SetBreak(IList<Break> brks)
        {

            foreach (var brk in brks)
            {
                _appDb.Breaks.Add(brk);
            }
        }

        public IEnumerable<TimeEntry> GetId(ApplicationUser values)
        {
            List<TimeEntry> entries = new List<TimeEntry>();
            _appDb.Entry(values).Collection(x => x.Entries).Load();
            foreach (TimeEntry entry in values.Entries)
            {
                List<Break> breaks = new List<Break>();
                _appDb.Entry(entry).Collection(em => em.Breaks).Load();
                foreach (Break b in entry.Breaks)
                {
                    breaks.Add(b);
                }

                entry.Breaks = breaks;
                entries.Add(entry);
            }

            return entries;
        }
    }
}
