using Microsoft.EntityFrameworkCore;
using MVCData123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Data
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {

        }
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        



        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<PersonModel>()
                .HasOne(pm => pm.CurrentCity)
                .WithMany(c => c.Citizens)
                .HasForeignKey(pm => pm.CurrentCityID);

            modelbuilder.Entity<City>()
                .HasOne(c=> c.CurrentCountry)
                .WithMany(co => co.Cities)
                .HasForeignKey(c => c.CurrentCountryID);

            modelbuilder.Entity<Country>().HasData(new Country { Id = 10001, Name = "Norway" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = 10002, Name = "Denmark" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = 10003, Name = "Finland" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = 10004, Name = "Canada" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = 10005, Name = "France" });

            modelbuilder.Entity<City>().HasData(new City { Id = 10001, Name = "Olso", CurrentCountryID = 10001 });
            modelbuilder.Entity<City>().HasData(new City { Id = 10002, Name = "Bergen", CurrentCountryID = 10001 });
            modelbuilder.Entity<City>().HasData(new City { Id = 10003, Name = "Copenhagen", CurrentCountryID = 10002 });
            modelbuilder.Entity<City>().HasData(new City { Id = 10004, Name = "Tornio", CurrentCountryID = 10003 });
            modelbuilder.Entity<City>().HasData(new City { Id = 10005, Name = "Turku", CurrentCountryID = 10003 });
            modelbuilder.Entity<City>().HasData(new City { Id = 10006, Name = "Vancouver", CurrentCountryID = 10004 });
            modelbuilder.Entity<City>().HasData(new City { Id = 10007, Name = "Paris", CurrentCountryID = 10005 });



            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10001, Name = "Adam Bertilson", CurrentCityID = 10007, Phone = "010-1234567" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10002, Name = "Caesar Milan", CurrentCityID = 10006, Phone = "010-123456" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10003, Name = "Adam Buxton", CurrentCityID = 10005, Phone = "010-12345" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10004, Name = "Tom Delonge", CurrentCityID = 10004, Phone = "010-1234" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10006, Name = "Miike Snow", CurrentCityID = 10003, Phone = "010-123" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10007, Name = "Red Forman", CurrentCityID = 10002, Phone = "010-12" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10008, Name = "Nick Frost", CurrentCityID = 10001, Phone = "010-1" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10009, Name = "Adam of Eternia", CurrentCityID = 10007, Phone = "010-123456777" });

        }
    }
}
