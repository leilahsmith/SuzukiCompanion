using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuzukiCompanion.Models
{
    public class StudentCreate
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }
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
