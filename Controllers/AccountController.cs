using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MVCDBFirst.Data;
using MVCDBFirst.Models;

namespace MVCDBFirst.Controllers
{
    public class AccountController : Controller
    {
        private readonly Testdb123Context db;

        public AccountController(Testdb123Context db) { this.db = db; }
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            user.Role = "User";
            db.Users.Add(user);
            db.SaveChanges();
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignIn u)
        {
            var data = db.Users.Where(x => x.Email.Equals(u.Email)).SingleOrDefault();
            if (data != null)
            {
                bool v = data.Email.Equals(u.Email) && (data.Password).Equals(u.Password); 
                if (v)
                {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, u.Email) },
                CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                HttpContext.Session.SetString("Username", data.Email);

                return RedirectToAction("Home", "Dashboard");
                }                          
            
                else
                {
                    TempData["errorpassword"] = "Invalid Password";
                }
            }
            else
            {
                TempData["errorusername"] = "Invalid Username";

            }
            return View();

        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedcookies = Request.Cookies.Keys;
            foreach (var cookie in storedcookies)
            {
                Response.Cookies.Delete(cookie);
            }
            HttpContext.Session.Clear();

            return RedirectToAction("SignIn");

        }











    }
}
