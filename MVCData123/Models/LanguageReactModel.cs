using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Models
{
    public class LanguageReactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public LanguageReactModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
