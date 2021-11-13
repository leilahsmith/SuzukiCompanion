using Microsoft.AspNet.Identity;
using SuzukiCompanion.Data;
using SuzukiCompanion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuzukiCompanion.WebMVC.Controllers
{
    public class JourneyController : Controller
    {

        private readonly ILessonService _service;
        public JourneyController(ILessonService service)
        {
            _service = service;
            service = _service;
        }
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Journey

        [Authorize]
        public ActionResult Index()
        {

            var model = _service.GetLessons(User.Identity.GetUserId());
            return View(model);
        }

        // Get: Details
        public ActionResult Details()
        {
            return View();
        }
    }
}