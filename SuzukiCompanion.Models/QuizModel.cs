using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SuzukiCompanion.Models
{
    public enum Grades
    {
        A, B, C, D, F
    }
    //[DisplayFormat(NullDisplayText = "No grade")]
    //public Grades? Grades { get; set; }
    //[ForeignKey("Student")]
    //public int StudentId { get; set; }
}
