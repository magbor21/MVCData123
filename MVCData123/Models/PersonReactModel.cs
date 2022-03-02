using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Models
{
    public class PersonReactModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CityName { get; set; }
        public string CityId { get; set; }

        public List<LanguageReactModel> Languages { get; set; }
        public PersonReactModel()
        {

        }

        public PersonReactModel(string id, string name, string phone, string cityName, string CityId, List<LanguageReactModel> languages)
        {
            Id = id;
            Name = name;
            Phone = phone;
            CityName = cityName;
            Languages = languages;
        }
    }
}
