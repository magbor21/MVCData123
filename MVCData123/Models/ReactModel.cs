using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Models
{
    public class ReactModel
    {
        
        public List<PersonReactModel> ReactPeople { get; set; }

        public List<CityReactModel> ReactCities { get; set; }
    }
}

