using Microsoft.AspNet.Identity;
using SuzukiCompanion.Data;
using SuzukiCompanion.Models;
using SuzukiCompanion.Services;
using SuzukiCompanion.WebMVC.Models;
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
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Journey/Start
        [Authorize]
        public ActionResult Start()
        {
            return View("~/Views/Journey/Start.cshtml");
        }

        public ActionResult Detail()
        {
            var model = new LessonListItem();

               
            return View(model);
        }

   
    }

}