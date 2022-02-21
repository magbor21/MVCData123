using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Models
{
    public class PersonReactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
    }
}
