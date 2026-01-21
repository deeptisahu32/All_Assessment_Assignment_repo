using Microsoft.AspNetCore.Mvc;
using Core_CodeFirts.Models;
using Core_CodeFirts.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core_CodeFirts.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly EmpDeptContext empDeptContext;


        public EmployeeController(IEmployeeRepository eRepo, EmpDeptContext Context)
        {
            _empRepo = eRepo;
            empDeptContext = Context;
        }
        public IActionResult Index()
        {
            var emp = _empRepo.GetAllEmployees();
            return View(emp);
        }

        public IActionResult GetEmpById(int id)
        {
            Employee e = _empRepo.GetEmployeeById(id);
            return View(e);
        }

        public ViewResult AddEmployee()
        {
            ViewData["DeptId"] = new SelectList(empDeptContext.Departments, "DeptId", "DeptName");
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _empRepo.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            ViewData["DeptId"] = new SelectList(empDeptContext.Departments, "DeptId", "DeptName",emp.DeptId);
            return View(emp);
        }

        public IActionResult DeleteEmployee(int id)
        {
            _empRepo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Employee e = _empRepo.GetEmployeeById(id);
            if (e == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(empDeptContext.Departments, "DeptId", "DeptName");
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _empRepo.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            ViewData["DeptId"] = new SelectList(empDeptContext.Departments, "DeptId", "DeptName", emp.DeptId);
            return View(emp);
        }
    }
}
