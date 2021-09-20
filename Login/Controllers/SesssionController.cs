using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{

    public class SesssionController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SesssionController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            var context = _httpContextAccessor.HttpContext;
            return View();
        }
    }
}
