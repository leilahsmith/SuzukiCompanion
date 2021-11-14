using Microsoft.AspNet.Identity;
using SuzukiCompanion.Data;
using SuzukiCompanion.Models;
using SuzukiCompanion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SuzukiCompanion.WebMVC.Controllers
{
    public class JourneyController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Journey/Start
        [Authorize]
        public ActionResult Start()
        {
            return View("~/Views/Journey/Start.cshtml");
        }

        // Get: Details
        public ActionResult Details(int? lessonId)
        {
            if (lessonId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Lesson lesson = _db.Lessons.Find(lessonId);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }
        private JourneyService CreateJourneyService()
        {
        var userId = Guid.Parse(User.Identity.GetUserId());
        var service = new JourneyService(userId);
        return service;
        }
    }
   
}