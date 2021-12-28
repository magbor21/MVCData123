using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Language")]
        [Required(ErrorMessage = "Language is required")]
        [RegularExpression(@"^[^0-9]*",
            ErrorMessage = "No numbers in the language name")]
        [MaxLength(30, ErrorMessage = "Max name length 30")]
        public string Name { get; set; }

        public virtual IEnumerable<PersonLanguage> PersonLanguages { get; set; }

    }
}

