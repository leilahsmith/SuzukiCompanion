using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Data
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
       
        public int QuizId { get; set; }
        public double Grade { get; set; }
    }
}
