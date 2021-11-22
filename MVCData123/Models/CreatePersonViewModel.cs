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

        [Required(ErrorMessage = "Name is required")] //Only 3 fields are required for adding people
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }


        public string SearchTerm { get; set; } //Filter list
        public string SortBy { get; set; } // Sort

        public PeopleViewModel pvm = new PeopleViewModel();
        public Person person;

        public string DeleteID { get; set; } // Delete one
        public string DeleteALL { get; set; } // Clear the list

       
    }
}
