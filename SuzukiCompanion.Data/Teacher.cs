using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Data
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Edited Date")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
