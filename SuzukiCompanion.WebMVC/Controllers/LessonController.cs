using Microsoft.AspNet.Identity;
using SuzukiCompanion.Data;
using SuzukiCompanion.Models;
using SuzukiCompanion.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuzukiCompanion.WebMVC.Controllers
{
    public class LessonController : Controller
    {
       
        // GET: Lesson
        [Authorize]
        public ActionResult Index()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LessonService(userId);
            var model = service.GetLessons();

            return View(model);
        }

        // GET: Lesson/Create
        //This is a request to get the "Create" view.
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lesson/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LessonCreate model)
        {

            if (!ModelState.IsValid) return View(model);

            var service = CreateLessonService();

            if (service.CreateLesson(model))
            {
                TempData["SaveResult"] = "Your lesson was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your lesson could not be created.");
            return View(model);
        }

        private LessonService CreateLessonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LessonService(userId);
            return service;
        }


    }
}
//    // POST: Lesson/Create
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public ActionResult Create(LessonCreate model)
//    {
//        if (!ModelState.IsValid) return View(model);

//        var service = CreateLessonService();

//        if (service.CreateLesson(model))
//        {
//            TempData["SaveResult"] = "Your lesson was created.";
//            return RedirectToAction("Index");
//        };

//        ModelState.AddModelError("", "Your lesson could not be created.");
//        return View(model);
//    }

//    //GET: Student/Details
//    public ActionResult Details(int id)
//    {
//        var svc = CreateLessonService();
//        var model = svc.GetLessonById(id);

//        return View(model);
//    }

//    public ActionResult Edit(int id)
//    {
//        var service = CreateLessonService();
//        var detail = service.GetLessonById(id);
//        var model =
//            new LessonEdit
//            {
//                StudentId = detail.StudentId,
//                FirstName = detail.FirstName,
//                LastName = detail.LastName,
//                Email = detail.Email,
//                Age = detail.Age,
//                PhoneNumber = detail.PhoneNumber,
//                Location = detail.Location,
//                ModifiedUtc = detail.ModifiedUtc,
//            };
//        return View(model);
//    }
//    //POST: Lesson/Edit
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public ActionResult Edit(int id, LessonEdit model)
//    {
//        if (!ModelState.IsValid) return View(model);

//        if (model.LessonId != id)
//        {
//            ModelState.AddModelError("", "Id Mismatch");
//            return View(model);
//        }

//        var service = CreateLessonService();

//        if (service.UpdateLesson(model))
//        {
//            TempData["SaveResult"] = "Your lesson was updated.";
//            return RedirectToAction("Index");
//        }

//        ModelState.AddModelError("", "Your lesson could not be updated.");
//        return View(model);
//    }

//    //GET: Lesson/Delete
//    [ActionName("Delete")]
//    public ActionResult Delete(int id)
//    {
//        var svc = CreateLessonService();
//        var model = svc.GetLessonById(id);

//        return View(model);
//    }

//    //POST: Lesson/Delete
//    [HttpPost]
//    [ActionName("Delete")]
//    [ValidateAntiForgeryToken]
//    public ActionResult DeleteLesson(int id)
//    {
//        var service = CreateLessonService();

//        service.DeleteLesson(id);

//        TempData["SaveResult"] = "Your lesson was deleted";

//        return RedirectToAction("Index");
//    }

//    // Helper Method
//    private LessonService CreateLessonService()
//    {
//        var userId = Guid.Parse(User.Identity.GetUserId());
//        var service = new LessonService(userId);
//        return service;
//    }
//}

