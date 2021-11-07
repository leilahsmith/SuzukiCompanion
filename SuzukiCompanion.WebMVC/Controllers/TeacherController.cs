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
    public class TeacherController : Controller
    {
        // GET: Teacher
        [Authorize]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeacherService(userId);
            var model = service.GetTeachers();

            return View(model);
        }

        // GET: Teacher/Create
        //This is a request to get the "Create" view.
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        // POST: Teacher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(TeacherCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTeacherService();

            if (service.CreateTeacher(model))
            {
                TempData["SaveResult"] = "Your teacher was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your teacher could not be created.");
            return View(model);
        }

        //GET: Teacher/Details
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            var svc = CreateTeacherService();
            var model = svc.GetTeacherById(id);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var service = CreateTeacherService();
            var detail = service.GetTeacherById(id);
            var model =
                new TeacherEdit
                {
                    TeacherId = detail.TeacherId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Email = detail.Email,
                    PhoneNumber = detail.PhoneNumber,
                    Location = detail.Location,
                };
            return View(model);
        }
        //POST: Teacher/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, TeacherEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TeacherId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTeacherService();

            if (service.UpdateTeacher(model))
            {
                TempData["SaveResult"] = "Your teacher was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your teacher could not be updated.");
            return View(model);
        }

        //GET: Teacher/Delete
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTeacherService();
            var model = svc.GetTeacherById(id);

            return View(model);
        }

        //POST: Teacher/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTeacher(int id)
        {
            var service = CreateTeacherService();

            service.DeleteTeacher(id);

            TempData["SaveResult"] = "Your teacher was deleted";

            return RedirectToAction("Index");
        }

        // Helper Method
        private TeacherService CreateTeacherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeacherService(userId);
            return service;
        }
    }
}