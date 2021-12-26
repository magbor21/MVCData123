using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")] 
        [RegularExpression(@"^[^0-9]*",
         ErrorMessage = "No numbers in the name")]
        [MaxLength(30, ErrorMessage = "Max name length 30")]
        public string Name { get; set; }

        public Country CurrentCountry { get; set; }
        public int CurrentCountryID { get; set; }

        public ICollection<PersonModel> Citizens  { get; set; }

    }
}
