using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Areas.Admin.Models;

namespace MyWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            var model = new BookModel();
            return View(model);
        }
    }
}