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

        public IActionResult AddSpEmp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSpEmp(Emp e)
        {
            db.Database.ExecuteSqlRaw($"exec InsertEmployee'{e.Name}','{e.Email}',{e.Salary}" );

            TempData["Success"] = "Emp Add Using Stored Procedure Success";
            return RedirectToAction("AddSpEmp");
        }



    }
}
