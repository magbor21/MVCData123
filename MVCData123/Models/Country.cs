using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")] 
        [RegularExpression(@"^[^0-9]*",
         ErrorMessage = "No numbers in the name")]
        [MaxLength(30, ErrorMessage = "Max name length 30")]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

    }
}
