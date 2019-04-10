using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspEfCore.Web.Models;
using AspEfCore.Domain;
using AspEfCore.Data;
using Microsoft.EntityFrameworkCore;

namespace AspEfCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;
        private readonly MyContext _context2;

        public HomeController(MyContext context,MyContext context2)
        {
            this._context = context;
            this._context2 = context2;
        }

        public IActionResult Index()
        {
            //查询

            //var param = "北京";
            //var province = _context.Provinces
            //    .OrderBy(x=>x.Id)
            //    .LastOrDefault(x => EF.Functions.Like(x.Name, param));  //last lastordefault 必须结合orderby使用

            //EF.Functions.Like()
            // Name like '%Bei%'


            //var provinces2 =
            //    (from p in _context.Provinces
            //     where p.Name == "北京"
            //     select p).ToList();

            //var province = new Province
            //{
            //    Name = "天津",
            //    Population  = 800_000
            //};

            //var company = new Company
            //{
            //    Name = "Taida",
            //    EstablishDate = new DateTime(1990, 1, 1),
            //    LegalPerson = "Secret Man"
            //};

            //_context.AddRange(province, company);

            //_context.Provinces.AddRange(province, province1, province2);
            //_context.Provinces.AddRange(new List<Province>
            //{
            //    province,province1,province2
            //});

            //_context.Provinces.Add(province);
            // _context is now Tracking province object

            //_context.SaveChanges();

            //_context.Add(province);



            //修改

            //var id = 8;

            //var province = _context.Provinces.Find(id);

            ////var result = _context.Database.ExecuteSqlCommand($"delete from Provinces where id = {id}");
            //var result = _context.Provinces.FromSql($"select * from Provinces where id = {id}").FirstOrDefault();





            //_context.Provinces.Remove(province);

            //_context.SaveChanges();



            //保存关联数据

            //var province = new Province
            //{
            //    Name = "Liaoning",
            //    Population = 40_000_000,
            //    Cities = new List<City>
            //    {
            //        new City{ AreaCode = "024",Name = "Shenyang"},
            //        new City{ AreaCode = "0411",Name="Dalian" }
            //    }
            //};
            //_context.Provinces.Add(province);
            //_context.SaveChanges();

            //var province = _context.Provinces.Single(x => x.Name == "Liaoning");
            //province.Cities.Add(new City
            //{
            //    AreaCode = "0412",
            //    Name = "鞍山"
            //});

            //离线情况下，使用外键！

            //var city = new City
            //{
            //    ProvinceId = 12,
            //    AreaCode = "0412",
            //    Name = "鞍山"
            //};

            //var provinces =
            //    _context.Provinces
            //    .Include(x => x.Cities)
            //    .ThenInclude(x => x.CityCompanies)
            //    .ThenInclude(x => x.Company)
            //    .ToList();

            //var cities = _context.Cities.Where(x=>x.Name == "鞍山")
            //    .Include(x => x.Province)
            //    .Include(x => x.CityCompanies)
            //    .Include(x => x.Mayor)
            //    .ToList();

            //var provincesInfo = _context.Provinces
            //    .Where(x => x.Cities.Any(y => y.Name == "Shenyang"))
            //    .ToList();


            //修改关联数据
            var provincesInfo = _context.Provinces
                .Include(x => x.Cities)
                .First(x => x.Cities.Any());

            var city = provincesInfo.Cities[0];
            city.Name += " Updated";

            _context2.Entry(city).State = EntityState.Modified;

            _context.SaveChanges();


            return View();
        }

        public struct ProvinceInfo
        {
            public ProvinceInfo(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public int Id;
            public string Name;
        }
        

        private bool FilterBeijing(Province p)
        {
            return p.Name == "北京";
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
