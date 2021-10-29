using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Data
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Your Lesson Title")]
        public string LessonTitle { get; set; }
        //Needed? public bool isLocked { get; set; }
        //Needed? public string Contents { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
        public string Pdf { get; set; }
        public string Video { get; set; }
        public string Photo { get; set; }
    }
}
    

