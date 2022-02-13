using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[^0-9]*",
        ErrorMessage = "No numbers in the name")]
        [MaxLength(30, ErrorMessage = "Max name length 30")]
        public string FirstName { get; set; }

        
        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[^0-9]*",
        ErrorMessage = "No numbers in the name")]
        [MaxLength(30, ErrorMessage = "Max name length 30")]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
    }
}
