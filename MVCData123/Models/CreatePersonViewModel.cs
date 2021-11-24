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

        [Display(Name="Full Name")]
        [Required(ErrorMessage = "Name is required")] //Only 3 fields are required for adding people
        [RegularExpression(@"^[^0-9]*",
         ErrorMessage = "No numbers in the name")]
        public string Name { get; set; }

        [Display(Name="Phone number")] 
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[^A-Za-z]*",
         ErrorMessage = "No letters in the phone number")]
        public string Phone { get; set; }

        [Display(Name="City /Location")]
        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[^0-9]*",
         ErrorMessage = "No numbers in the city name")]
        public string City { get; set; }


        public string SearchTerm { get; set; } //Filter list
        public string SortBy { get; set; } // Sort

        public PeopleViewModel pvm = new PeopleViewModel();
        public Person person;

        public string DeleteID { get; set; } // Delete one
        public string DeleteALL { get; set; } // Clear the list

       
    }
}
