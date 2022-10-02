using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _20499583HW5.Models;
using Microsoft.Extensions.Logging;
using _20499583HW5.Services;

namespace _20499583HW5.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private service services = service.getInstance();

        public StudentController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // GET: Student
       public ActionResult Student()
        {
            List<Student> student = services.getStudentss();
            return View(student);
        }
    }
}