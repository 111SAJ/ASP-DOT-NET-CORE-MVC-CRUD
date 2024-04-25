using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    public class EmployeeRegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        //List
        public IActionResult Index()
        {
            //var EmployeeList = _context.EmployeeRegister.OrderByDescending(e => e.EmployeeId).ToList();
            var EmployeeList = _context.EmployeeRegister.ToList();
            return View(EmployeeList);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            var newEmployee = new EmployeeRegister();
            return View(newEmployee);
        }

        [HttpPost]
        public IActionResult Create(EmployeeRegister employeeRegister)
        {
            if (ModelState.IsValid)
            {
                var existEmployee = _context.EmployeeRegister.FirstOrDefault(e => e.EmployeeEmail == employeeRegister.EmployeeEmail);
                if (existEmployee != null)
                {
                    ModelState.AddModelError("EmployeeEmail", "User already registered");
                    return View(employeeRegister);
                }

                _context.EmployeeRegister.Add(employeeRegister);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeRegister);
        }

        //Update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.EmployeeRegister.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeRegister employeeRegister)
        {
            if (ModelState.IsValid)
            {
                _context.Update(employeeRegister);
                _context.SaveChanges();

                return RedirectToAction(("Index"));
            }
            return View(employeeRegister);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _context.EmployeeRegister.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.EmployeeRegister.Find(id);

            if (employee != null)
            {
                _context.EmployeeRegister.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction(("Index"));
        }

        

    }
}
