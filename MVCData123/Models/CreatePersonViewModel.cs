using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCData123.Models
{
    public class CreatePersonViewModel
    {

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        

    }
}
