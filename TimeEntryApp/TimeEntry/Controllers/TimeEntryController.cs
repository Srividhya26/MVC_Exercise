using BusinessLogic;
using BusinessObjectLayer.Models;
using BusinessObjectLayer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entry.Controllers
{
    public class TimeEntryController : Controller
    {
        private readonly EntryBL _entryBL;
        public TimeEntryController(AccountBL accBL, EntryBL entryBL)
        {
            _entryBL = entryBL;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateEntry()
        {
            EntryView_Model entry = new EntryView_Model();
            entry.BreakList.Add(new Break() { TimeEntryId = 1 });
            return View(entry);
        }
        [HttpPost]
        public IActionResult CreateEntry(EntryView_Model model)
        {
            var breakList = model.BreakList;

            _entryBL.SetBreak(breakList);

            BusinessObjectLayer.Models.TimeEntry entry = new BusinessObjectLayer.Models.TimeEntry
            {
                Date = model.Date,
                InTime = model.InTime,
                OutTime = model.OutTime,
            };

            _entryBL.SetEntry(entry);

            return View("Index");
        }
    }
}
