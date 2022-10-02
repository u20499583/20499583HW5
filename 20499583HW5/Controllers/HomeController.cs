using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Microsoft.AspNetCore.Mvc;
using _20499583HW5.Models;
using Microsoft.Extensions.Logging;
using _20499583HW5.Services;

namespace _20499583HW5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private service services = service.getInstance();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Book()
        {
            List<Book> book = services.getBook();
            return View(book);
        }
        public ActionResult Borrows(int bookId)
        {
            List<BookBorrowsVM> bookBorrows = services.getBorrowsOfBook(bookId);
           
           
            
            return View(bookBorrows);
        }

    }
}