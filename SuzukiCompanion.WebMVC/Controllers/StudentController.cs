using Microsoft.AspNet.Identity;
using SuzukiCompanion.Models;
using SuzukiCompanion.Services;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StudentService(userId);
            var model = service.GetStudents();

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
            if (!ModelState.IsValid) return View(model);

            var service = CreateStudentService();

            if (service.CreateStudent(model))
            {
                TempData["SaveResult"] = "Your student was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your student could not be created.");
            return View(model);
        }

        //GET: Student/Details
        public ActionResult Details(int id)
        {
            var svc = CreateStudentService();
            var model = svc.GetStudentById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateStudentService();
            var detail = service.GetStudentById(id);
            var model =
                new StudentEdit
                {
                    StudentId = detail.StudentId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Email = detail.Email,
                    Age = detail.Age,
                    PhoneNumber = detail.PhoneNumber,
                    Location = detail.Location,
                    ModifiedUtc = detail.ModifiedUtc,
                };
            return View(model);
        }

        // Helper Method
        private StudentService CreateStudentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StudentService(userId);
            return service;
        }
    }
}