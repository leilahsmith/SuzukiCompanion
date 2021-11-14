using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuzukiCompanion.WebMVC.Models
{
    public class JourneyViewModel
    {
        [Required]
        public int UserId { get; set; }
        public int LessonName { get; set; }
        //public int TransactionID { get; set; }

        public IEnumerable<SelectListItem> Lessons { get; set; } = new List<SelectListItem>();
    }
}