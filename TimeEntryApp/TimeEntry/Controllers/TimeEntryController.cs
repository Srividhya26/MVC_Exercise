using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeEntry.Controllers
{
    public class TimeEntryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
