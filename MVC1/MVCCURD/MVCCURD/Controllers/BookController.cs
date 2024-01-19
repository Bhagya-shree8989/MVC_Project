using MVCCURD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCURD.Controllers
{
    public class BookController : Controller
    {
        ADO_DBEntities dc = ADO_DBEntities();
            public ViewResult DisplayBooks()
            {
              var books = dc.Books.Where(b => b.Class == true);
              return View(books);
            }
        public ViewResult DisplayBook(int class)
        {
            var Emp = dc.Books.Find(class);
            return View(books);
        }
        public ViewResult AddBook()
        {
            ViewBag. = new SelectList(dc. "Class", "Name");
            return View();
        }
        [HttpPost]
        