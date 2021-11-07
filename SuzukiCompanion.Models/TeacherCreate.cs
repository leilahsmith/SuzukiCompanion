using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Models
{
    public class TeacherCreate
    {
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }
        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email Address")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}

