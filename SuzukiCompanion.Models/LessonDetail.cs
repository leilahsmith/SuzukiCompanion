using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Models
{
    public class LessonDetail
    {
        [Key]
        public int LessonId { get; set; }
        [Display(Name = "Lesson Title")]
        public string LessonName { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public string Contents { get; set; }
        public string Pdf { get; set; }
        public string Video { get; set; }
        public string Photo { get; set; }
    }
}
