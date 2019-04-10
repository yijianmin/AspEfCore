using AspEfCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AspEfCore.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configurations

            modelBuilder.Entity<CityCompany>().HasKey(x => new { x.CityId, x.CompanyId });

            //modelBuilder.Entity<City>().HasOne(x => x.Province).WithMany(x => x.Cities).HasForeignKey(x => x.ProvinceId);

            modelBuilder.Entity<CityCompany>().HasOne(x => x.City).WithMany(x => x.CityCompanies).HasForeignKey(x => x.CityId);

            modelBuilder.Entity<CityCompany>().HasOne(x => x.Company).WithMany(x => x.CityCompanies).HasForeignKey(x => x.CompanyId);

            modelBuilder.Entity<Mayor>().HasOne(x => x.City).WithOne(x => x.Mayor).HasForeignKey<Mayor>(x => x.CityId);  

            #endregion

            modelBuilder.Entity<Province>().HasData(
                new Province
                {
                    Id = 1,
                    Name = "广东省",
                    Population = 90_000_111
                },
                new Province
                {
                    Id = 4,
                    Name = "四川省",
                    Population = 100_000_222
                },
                new Province
                {
                    Id = 6,
                    Name = "江苏省",
                    Population = 80_000_000
                });

            modelBuilder.Entity<City>().HasData(
                new { ProvinceId = 6,Id=61,Name="南京"},
                new { ProvinceId = 6,Id=62,Name="苏州"},
                new { ProvinceId = 6,Id=63,Name="连云港"},
                new { ProvinceId = 6,Id=64,Name="昆山"}
                );

            var studentId = new Guid("A1790C03-62FB-416B-AA1A-BE1ABBEC9F46");

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = studentId, Name = "李四"}
                );
        }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityCompany> CityCompanies { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
