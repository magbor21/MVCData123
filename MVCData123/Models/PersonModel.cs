using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Models
{
    public class PersonModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")] //Only 3 fields are required for adding people
        [RegularExpression(@"^[^0-9]*",
         ErrorMessage = "No numbers in the name")]
        [MaxLength(30, ErrorMessage = "Max name length 30")]
        public string Name { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^[^A-Za-z]*",
         ErrorMessage = "No letters in the phone number")]
        [MaxLength(15, ErrorMessage = "Max phone length 15")]
        public string Phone { get; set; }


        public City CurrentCity { get; set; }
        [Required(ErrorMessage = "City is required")]
        public int CurrentCityID { get; set; }


    }
}
