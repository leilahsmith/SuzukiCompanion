using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Data
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }
        public DateTimeOffset BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
