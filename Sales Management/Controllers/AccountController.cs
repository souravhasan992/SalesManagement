using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales_Management.Data.Models;
using Sales_Management.Data;
using System.Linq;

namespace Sales_Management.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLogin model)
        {
            AppDbContext db = _context;
            var oUserLogin = db.UserLogins.Where(o => o.UserName == model.UserName && o.UserPass == model.UserPass).FirstOrDefault();
            if (oUserLogin != null)
            {
                HttpContext.Session.SetString("UserName", oUserLogin.UserName);
                HttpContext.Session.SetInt32("UserType", (int)oUserLogin.UserType);
                if (oUserLogin.UserType == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
