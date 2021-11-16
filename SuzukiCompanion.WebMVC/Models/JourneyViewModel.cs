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
        public JourneyViewModel()
        {
           Values = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Values { get; set; }
        public JourneyViewModel Add(string key, string value)
        {
            Values.Add(key, value);
            return this;
        }



        [Required]
        public int UserId { get; set; }
        public int LessonName { get; set; }
        //public int LessonId { get; set; }

        public IEnumerable<SelectListItem> Lessons { get; set; } = new List<SelectListItem>();
    }
}