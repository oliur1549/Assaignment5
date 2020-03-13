using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyWebApplication.Areas.Admin.Models;

namespace MyWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BooksController : Controller
    {
        

        private readonly IConfiguration _configuration;
        public BooksController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var model = new BookModel(_configuration);
            return View(model);
        }

        public IActionResult GetBooks()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new BookModel(_configuration);
            var data = model.GetBooks(tableModel);
            return Json(data);
        }
    }
}