using SuzukiCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuzukiCompanion.WebMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [Authorize]
        public ActionResult Index()
        {
            var model = new StudentListItem[0];
            return View(model);
        }

        // GET: Student/Create
        //This is a request to get the "Create" view.
        public ActionResult Create()
        {
            return View();
        }
        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}