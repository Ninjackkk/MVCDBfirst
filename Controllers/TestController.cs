using Microsoft.AspNetCore.Mvc;
using MVCDBFirst.Data;
using MVCDBFirst.Models;

namespace MVCDBFirst.Controllers
{
    public class TestController : Controller
    {
        private readonly Testdb123Context db;

        public TestController(Testdb123Context db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEmp()
        {   
            return View();
        }
        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            //Random random = new Random();
            //int r = new Random().Next();
            db.Emps.Add(e);
            db.SaveChanges();
            TempData["Saved"] = "Data Saved";
            return RedirectToAction("AddEmp");
        }


  


    }
}
