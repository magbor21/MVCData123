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

            /*modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10001, Name = "Adam Bertilson", City = "Örebro", Phone = "010-1234567" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10002, Name = "Caesar Davidsson", City = "Ystad", Phone = "020-910020" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10003, Name = "Erijk Filipsson", City = "Ängelholm", Phone = "030-65433741" });
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10005, Name = "Gustav Helgesson", City = "Halmstad", Phone = "040-98765414" });
            */
        }
    }
}
