using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MVCData123.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCData123.Data
{
    public class PersonContext : IdentityDbContext<ApplicationUser>
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {

        }
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<PersonModel>()
                .HasOne(pm => pm.CurrentCity)
                .WithMany(c => c.Citizens)
                .HasForeignKey(pm => pm.CurrentCityID);

            modelbuilder.Entity<City>()
                .HasOne(c=> c.CurrentCountry)
                .WithMany(co => co.Cities)
                .HasForeignKey(c => c.CurrentCountryID);

            
            modelbuilder.Entity<PersonLanguage>()
                .HasKey(pl => new { pl.PersonId, pl.LanguageId });

            modelbuilder.Entity<PersonLanguage>()
                .HasOne(x => x.Person)
                .WithMany(y => y.PersonLanguages)
                .HasForeignKey(y => y.PersonId);

            modelbuilder.Entity<PersonLanguage>()
                .HasOne(x => x.Language)
                .WithMany(y => y.PersonLanguages)
                .HasForeignKey(y => y.LanguageId);

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
            modelbuilder.Entity<PersonModel>().HasData(new PersonModel { Id = 10005, Name = "Adam of Eternia", CurrentCityID = 10007, Phone = "010-123456777" });

            modelbuilder.Entity<Language>().HasData(new Language { Id = 10001, Name = "Norwegian" });
            modelbuilder.Entity<Language>().HasData(new Language { Id = 10002, Name = "Danish" });
            modelbuilder.Entity<Language>().HasData(new Language { Id = 10003, Name = "Finnish" });
            modelbuilder.Entity<Language>().HasData(new Language { Id = 10004, Name = "English" });
            modelbuilder.Entity<Language>().HasData(new Language { Id = 10005, Name = "Swedish" });
         

            modelbuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 10001, LanguageId = 10001 });
            modelbuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 10002, LanguageId = 10001 });
            modelbuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 10003, LanguageId = 10001 });
            modelbuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 10004, LanguageId = 10001 });
            modelbuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 10005, LanguageId = 10001 });
            modelbuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 10005, LanguageId = 10002 });
            modelbuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 10005, LanguageId = 10003 });
            modelbuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 10005, LanguageId = 10004 });
            modelbuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { PersonId = 10005, LanguageId = 10005 });


            string roleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();

            modelbuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
            modelbuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"
            });

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelbuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "password"),
                FirstName = "Admin",
                LastName = "Adminsson",
                Birthday = new DateTime(2000,1,1)
            });

            modelbuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });

            userId = Guid.NewGuid().ToString();

            modelbuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "user@user.com",
                NormalizedEmail = "USER@USER.COM",
                UserName = "UserNo1",
                NormalizedUserName = "UserNo1",
                PasswordHash = hasher.HashPassword(null, "password"),
                FirstName = "Usher",
                LastName = "Raymond IV",
                Birthday = new DateTime(2001, 2, 3)
            });

            modelbuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = userRoleId,
                UserId = userId
            });

        }
    }
}
