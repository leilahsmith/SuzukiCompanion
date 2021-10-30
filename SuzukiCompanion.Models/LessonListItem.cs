using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Models
{
    public class LessonListItem
    {
        [Key]
        public int LessonId { get; set; }
        [Required]
        [Display(Name = "Lesson Name")]
        public string LessonName { get; set; }
        [Required]
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Edited Date")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public string Contents { get; set; }
    }
}

