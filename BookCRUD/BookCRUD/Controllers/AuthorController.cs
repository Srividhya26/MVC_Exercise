using BookBL.Logics;
using BookDAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookPresentation.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorBL _authorBL;

        public AuthorController(AuthorBL authorBL)
        {
            this._authorBL = authorBL;
        }

        public IActionResult Index()
        {
            //IEnumerable<Author> empList = 

            return View();
        }

        public IActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                _authorBL.AddAuthor(author);

                return RedirectToAction("Index");
            }

            return View(author);
        }

        public IActionResult UpdateAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateAuthor(Author author,int id)
        {
           if(ModelState.IsValid)
            {
                _authorBL.UpdateAuthor(author, id);

                return RedirectToAction("Index");
            }

            return View(author);
        }
    }
}
