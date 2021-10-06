using BusinessLogic;
using BusinessObjectLayer.Models;
using BusinessObjectLayer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Entry.Controllers
{
    public class TimeEntryController : Controller
    {
        private readonly EntryBL _entryBL;
        private readonly AccountBL _accountBL;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public TimeEntryController(EntryBL entryBL, AccountBL accountBL, UserManager<ApplicationUser> userManager)
        {
            _entryBL = entryBL;
            _accountBL = accountBL;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<BusinessObjectLayer.Models.TimeEntry> entries = new List<BusinessObjectLayer.Models.TimeEntry>();

            ApplicationUser user;

            var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (id != null)
            {
                user = await this._userManager.FindByIdAsync(id);
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    entries = _entryBL.GetId(user);
                }
            }

            return View(entries);
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

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            BusinessObjectLayer.Models.TimeEntry entry = new BusinessObjectLayer.Models.TimeEntry
            {
                Date = model.Date,
                InTime = model.InTime,
                OutTime = model.OutTime,
            };

            _entryBL.SetEntry(entry);

            return View("Index");
        }

        [Authorize]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
