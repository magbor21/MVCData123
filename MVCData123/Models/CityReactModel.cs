using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Models
{
    public class CityReactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CityReactModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
