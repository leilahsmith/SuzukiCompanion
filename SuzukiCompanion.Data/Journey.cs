using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Data
{
    public class Journey
    {
        [Key]
        public int JourneyId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "Lesson Title")]
        public string LessonName { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    
    }
}
