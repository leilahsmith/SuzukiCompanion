using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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
        public string LessonName { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public string Contents { get; set; }
        public string Pdf { get; set; }
        public string Video { get; set; }
        public string Photo { get; set; }
        public string ImagePath { get; set; }
    }
}
    

