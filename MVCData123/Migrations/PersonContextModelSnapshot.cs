﻿// <auto-generated />
using MVCData123.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCData123.Migrations
{
    [DbContext(typeof(PersonContext))]
    partial class PersonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCData123.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentCountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("CurrentCountryID");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 10001,
                            CurrentCountryID = 10001,
                            Name = "Olso"
                        },
                        new
                        {
                            Id = 10002,
                            CurrentCountryID = 10001,
                            Name = "Bergen"
                        },
                        new
                        {
                            Id = 10003,
                            CurrentCountryID = 10002,
                            Name = "Copenhagen"
                        },
                        new
                        {
                            Id = 10004,
                            CurrentCountryID = 10003,
                            Name = "Tornio"
                        },
                        new
                        {
                            Id = 10005,
                            CurrentCountryID = 10003,
                            Name = "Turku"
                        },
                        new
                        {
                            Id = 10006,
                            CurrentCountryID = 10004,
                            Name = "Vancouver"
                        },
                        new
                        {
                            Id = 10007,
                            CurrentCountryID = 10005,
                            Name = "Paris"
                        });
                });

            modelBuilder.Entity("MVCData123.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 10001,
                            Name = "Norway"
                        },
                        new
                        {
                            Id = 10002,
                            Name = "Denmark"
                        },
                        new
                        {
                            Id = 10003,
                            Name = "Finland"
                        },
                        new
                        {
                            Id = 10004,
                            Name = "Canada"
                        },
                        new
                        {
                            Id = 10005,
                            Name = "France"
                        });
                });

            modelBuilder.Entity("MVCData123.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 10001,
                            Name = "Norwegian"
                        },
                        new
                        {
                            Id = 10002,
                            Name = "Danish"
                        },
                        new
                        {
                            Id = 10003,
                            Name = "Finnish"
                        },
                        new
                        {
                            Id = 10004,
                            Name = "English"
                        },
                        new
                        {
                            Id = 10005,
                            Name = "Swedish"
                        });
                });

            modelBuilder.Entity("MVCData123.Models.PersonLanguage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguages");

                    b.HasData(
                        new
                        {
                            PersonId = 10001,
                            LanguageId = 10001
                        },
                        new
                        {
                            PersonId = 10002,
                            LanguageId = 10001
                        },
                        new
                        {
                            PersonId = 10003,
                            LanguageId = 10001
                        },
                        new
                        {
                            PersonId = 10004,
                            LanguageId = 10001
                        },
                        new
                        {
                            PersonId = 10005,
                            LanguageId = 10001
                        },
                        new
                        {
                            PersonId = 10005,
                            LanguageId = 10002
                        },
                        new
                        {
                            PersonId = 10005,
                            LanguageId = 10003
                        },
                        new
                        {
                            PersonId = 10005,
                            LanguageId = 10004
                        },
                        new
                        {
                            PersonId = 10005,
                            LanguageId = 10005
                        });
                });

            modelBuilder.Entity("MVCData123.Models.PersonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentCityID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("CurrentCityID");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 10001,
                            CurrentCityID = 10007,
                            Name = "Adam Bertilson",
                            Phone = "010-1234567"
                        },
                        new
                        {
                            Id = 10002,
                            CurrentCityID = 10006,
                            Name = "Caesar Milan",
                            Phone = "010-123456"
                        },
                        new
                        {
                            Id = 10003,
                            CurrentCityID = 10005,
                            Name = "Adam Buxton",
                            Phone = "010-12345"
                        },
                        new
                        {
                            Id = 10004,
                            CurrentCityID = 10004,
                            Name = "Tom Delonge",
                            Phone = "010-1234"
                        },
                        new
                        {
                            Id = 10006,
                            CurrentCityID = 10003,
                            Name = "Miike Snow",
                            Phone = "010-123"
                        },
                        new
                        {
                            Id = 10007,
                            CurrentCityID = 10002,
                            Name = "Red Forman",
                            Phone = "010-12"
                        },
                        new
                        {
                            Id = 10008,
                            CurrentCityID = 10001,
                            Name = "Nick Frost",
                            Phone = "010-1"
                        },
                        new
                        {
                            Id = 10005,
                            CurrentCityID = 10007,
                            Name = "Adam of Eternia",
                            Phone = "010-123456777"
                        });
                });

            modelBuilder.Entity("MVCData123.Models.City", b =>
                {
                    b.HasOne("MVCData123.Models.Country", "CurrentCountry")
                        .WithMany("Cities")
                        .HasForeignKey("CurrentCountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCData123.Models.PersonLanguage", b =>
                {
                    b.HasOne("MVCData123.Models.Language", "Language")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCData123.Models.PersonModel", "Person")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCData123.Models.PersonModel", b =>
                {
                    b.HasOne("MVCData123.Models.City", "CurrentCity")
                        .WithMany("Citizens")
                        .HasForeignKey("CurrentCityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
