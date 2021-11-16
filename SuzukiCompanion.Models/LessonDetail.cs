﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Models
{
    public class LessonDetail
    {  
        [ForeignKey("LesssonId")]
        public int LessonId { get; set; }
        [Display(Name = "Lesson Title")]
        public string LessonName { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public string Contents { get; set; }
  
    }
}
