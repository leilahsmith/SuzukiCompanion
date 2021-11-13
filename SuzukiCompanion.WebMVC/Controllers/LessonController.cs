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
    public class LessonController : Controller
    {
        private readonly ILessonService _service;
        public LessonController(ILessonService service)
        {
            _service = service;
            service = _service;
        }
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Lesson
        [Authorize]
        public ActionResult Index()
        {

            var model = _service.GetLessons(User.Identity.GetUserId());
            return View(model);
        }

        // GET: Lesson/Create
        //This is a request to get the "Create" view.
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lesson/Create
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(LessonCreate model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.UserId = User.Identity.GetUserId();
                
                string rootedPath;
                string path;
                string fileName;

                if (file != null)
                {
                    fileName = Path.GetFileName(file.FileName);
                    path = "Content/img/" + fileName;

                    rootedPath = Path.Combine(Server.MapPath("~/Content/img"), fileName);
                    file.SaveAs(rootedPath);

                    _service.CreateLesson(model, path);

                    if (_service.CreateLesson(model, path))
                    {
                        TempData["SaveResult"] = "Your lesson was created.";
                        return RedirectToAction("Index");
                    };

                    ModelState.AddModelError("", "Your lesson could not be created.");
                }
               
            
                return View(model);

            //var service = CreateLessonService();
        }

        //GET: Lesson/Details
        public ActionResult Details(int id)
        {
            var model = _service.GetLessonById(id, User.Identity.GetUserId());
            return View(model);
        }

        //GET: Lesson/Edit
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            
            var detail = _service.GetLessonById(id, User.Identity.GetUserId());
            var model =
                 new LessonEdit
                 {
                     LessonId = detail.LessonId,
                     LessonName = detail.LessonName,
                     Contents = detail.Contents,
                     Pdf = detail.Pdf,
                     Video = detail.Video,
                     Photo = detail.Photo,
                 };
            return View(model);
        }
        //post: Lesson/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, LessonEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            model.UserId = User.Identity.GetUserId();
            if (model.LessonId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (_service.UpdateLesson(model))
            {
                TempData["SaveResult"] = "Congratulations. Your lesson was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Sorry, your lesson could not be updated.");
            return View(model);
        }

        //GET: Lesson/Delete
        [ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var model = _service.GetLessonById(id, User.Identity.GetUserId());

            return View(model);
        }

        // POST: Lesson/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteLesson(int id)
        {
            _service.DeleteLesson(id, User.Identity.GetUserId());
            TempData["SaveResult"] = "Your lesson was deleted";

            return RedirectToAction("Index");
        }
    }
}








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

