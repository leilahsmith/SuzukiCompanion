using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Models
{
    public class LessonCreate
    {
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Lesson Name")]
        public string LessonName { get; set; }
        [Required]
        public string Contents { get; set; }
        public string ImagePath { get; set; }
    }
}
