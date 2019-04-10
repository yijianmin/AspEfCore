﻿// <auto-generated />
using System;
using AspEfCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspEfCore.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20190410151353_UpdateSeedData3")]
    partial class UpdateSeedData3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspEfCore.Domain.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AreaCode");

                    b.Property<string>("Name");

                    b.Property<int?>("ProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");

                    b.HasData(
                        new { Id = 61, Name = "南京", ProvinceId = 6 },
                        new { Id = 62, Name = "苏州", ProvinceId = 6 },
                        new { Id = 63, Name = "连云港", ProvinceId = 6 },
                        new { Id = 64, Name = "昆山", ProvinceId = 6 }
                    );
                });

            modelBuilder.Entity("AspEfCore.Domain.CityCompany", b =>
                {
                    b.Property<int>("CityId");

                    b.Property<int>("CompanyId");

                    b.HasKey("CityId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("CityCompanies");
                });

            modelBuilder.Entity("AspEfCore.Domain.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EstablishDate");

                    b.Property<string>("LegalPerson");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("AspEfCore.Domain.Mayor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("CityId");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("CityId")
                        .IsUnique();

                    b.ToTable("Mayor");
                });

            modelBuilder.Entity("AspEfCore.Domain.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Population");

                    b.HasKey("Id");

                    b.ToTable("Provinces");

                    b.HasData(
                        new { Id = 1, Name = "广东省", Population = 90000111 },
                        new { Id = 4, Name = "四川省", Population = 100000222 },
                        new { Id = 6, Name = "江苏省", Population = 80000000 }
                    );
                });

            modelBuilder.Entity("AspEfCore.Domain.City", b =>
                {
                    b.HasOne("AspEfCore.Domain.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId");
                });

            modelBuilder.Entity("AspEfCore.Domain.CityCompany", b =>
                {
                    b.HasOne("AspEfCore.Domain.City", "City")
                        .WithMany("CityCompanies")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AspEfCore.Domain.Company", "Company")
                        .WithMany("CityCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AspEfCore.Domain.Mayor", b =>
                {
                    b.HasOne("AspEfCore.Domain.City", "City")
                        .WithOne("Mayor")
                        .HasForeignKey("AspEfCore.Domain.Mayor", "CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
