using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Models
{
    public class LessonCreate
    {
        
        [Required]
        [Display(Name = "Lesson Name")]
        public string LessonName { get; set; }
        [Required]
        public string Contents { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
