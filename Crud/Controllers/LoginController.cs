using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    public class LoginController : Controller
    {
        protected readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Login login)
        {
            var loggedIn = _context.EmployeeRegister.FirstOrDefault(e => e.EmployeeEmail == login.EmployeeEmail && e.Password == login.Password);
            if (loggedIn != null)
            {
                login.isLoggedIn = true;
                HttpContext.Session.SetString("EmployeeEmail", login.EmployeeEmail);
                return RedirectToAction("Index", "SecuredPage");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }

        //GET: Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            //HttpContext.Response.Headers.Add("Cache-Control", "no-store, no-cache, must-revalidate");
            //HttpContext.Response.Headers.Add("Pragma", "no-cache");
            //HttpContext.Response.Headers.Add("Expires", "-1");
            
            return RedirectToAction("Index");
        }
    }
}
