using System.Diagnostics;
using Core_CodeFirts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_CodeFirts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Employee employee = new Employee()
            {
                EmpId = 2,
                Name = "Komal",
                Email = "Komal@gmail.com",
                Position = "QE",
                DeptId = 2,
            };
            ViewData["emp"] = employee;

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
