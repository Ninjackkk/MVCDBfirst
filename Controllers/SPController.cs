using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDBFirst.Data;
using MVCDBFirst.Models;

namespace MVCDBFirst.Controllers
{
    public class SPController : Controller // Using Sql queries in asp.net core
    {
        private readonly Testdb123Context db;
        public SPController(Testdb123Context db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
           var data= db.Emps.FromSqlRaw("exec FetchAllEmp").ToList();
           return View(data);
        }

        public IActionResult AddorUpd(Emp e)
        {
            
            db.Database.ExecuteSqlRaw($"exec Insertorupd {e.Id},'{e.Name}','{e.Email}','{e.Salary}'");
            if (e.Id == null)
            {
                TempData["Success"] = "Emp Add Using Stored Procedure Success";
            }
            else
            {
                TempData["Successupd"] = "Emp Updated Using Stored Procedure Success";
            }
            return View("AddSpEmp");
        }
        //public IActionResult AddSpEmp()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddSpEmp(Emp e)
        //{
        //    db.Database.ExecuteSqlRaw($"exec InsertEmployee'{e.Name}','{e.Email}',{e.Salary}" );

        //    TempData["Success"] = "Emp Add Using Stored Procedure Success";
        //    return RedirectToAction("AddSpEmp");
        //}

        //public IActionResult EditSpEmp(int id) 
        //{
        //   var d = db.Emps.FromSqlRaw($"exec fetchrecordbyid'{id}'").ToList().SingleOrDefault();
        //    return View(d);
        //}
        //[HttpPost]
        //public IActionResult EditSpEmp(Emp e)
        //{
        //    db.Database.ExecuteSqlRaw($"exec editemp'{e.Id}','{e.Name}','{e.Email}','{e.Salary}'");
        //    return RedirectToAction("Index");
        //}
    }
}
