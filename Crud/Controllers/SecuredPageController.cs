using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    public class SecuredPageController : Controller
    {
        public IActionResult Index()
        {
            //Check if the Session Exist
            var employeeSession = HttpContext.Session.GetString("EmployeeEmail");

            if (employeeSession == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
