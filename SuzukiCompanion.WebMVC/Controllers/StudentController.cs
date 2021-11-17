using Microsoft.AspNet.Identity;
using SuzukiCompanion.Data;
using SuzukiCompanion.Models;
using SuzukiCompanion.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuzukiCompanion.WebMVC.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // GET: Student
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = _service.GetStudents(User.Identity.GetUserId());
            return View(model);
        }


        // GET: Student/Create
        //This is a request to get the "Create" view.
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Create(StudentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.UserId = User.Identity.GetUserId();

            string path;
            path = "Content/img/";

            _service.CreateStudent(model, path);

            if (_service.CreateStudent(model, path))
            {
                TempData["SaveResult"] = "Your student was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Your student could not be created.");
            return View(model);
        }

        //GET: Student/Detail
        [Authorize(Roles = "Admin")]
        public ActionResult Detail(int lessonId)
        {
            var model = _service.GetStudentById(lessonId, User.Identity.GetUserId());
            return View(model);
        }

        //GET: Student/Edit
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int studentId)
        {
            var detail = _service.GetStudentById(studentId, User.Identity.GetUserId());
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

        //POST: Student/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Edit(int id, StudentEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            model.UserId = User.Identity.GetUserId();

            if (model.StudentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (_service.UpdateStudent(model))
            {
                TempData["SaveResult"] = "Your student was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your student could not be updated.");
            return View(model);
        }

        //GET: Student/Delete
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]

        public ActionResult Delete(int studentId)
        {
            var model = _service.GetStudentById(studentId, User.Identity.GetUserId());

            return View(model);
        }

        //POST: Student/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult DeleteStudent(int studentId)
        {
            _service.DeleteStudent(studentId, User.Identity.GetUserId());

            TempData["SaveResult"] = "Your student was deleted";

            return RedirectToAction("Index");
        }
    }
}
