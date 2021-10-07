
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

        public void CreateEntry(ApplicationUser user, TimeEntry entry)
        {
            _appDb.Users.FirstOrDefault(x => x.Id == user.Id).Entries.Add(entry);
            _appDb.SaveChanges();
        }

        //creating breaks
        public void CreateBreak(ApplicationUser user,int id, Break @break)
        {
            _appDb.Entries.FirstOrDefault(x => x.Id == id).Breaks.Add(@break);
            _appDb.SaveChanges();
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

        public void DeleteEntry(ApplicationUser user, int? id)
        {

            var entry = _appDb.Entries.FirstOrDefault(x => x.Id == id);
            if (entry != null)
            {
                _appDb.Users.FirstOrDefault(x => x.Id == user.Id).Entries.Remove(entry);
                _appDb.SaveChanges();

            }
        }

        public void DeleteBreak(ApplicationUser user,int? id)
        {
            var breaks = _appDb.Breaks.FirstOrDefault(x => x.BreakID == id);
            if(breaks != null)
            {
                _appDb.Breaks.Remove(breaks);
                _appDb.SaveChanges();
            }
        }
    }
}
