using System.Diagnostics;
using Core_Routing.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_Routing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("MyHome")]
        [Route("MyHome/Index")]

        public string Index()
        {
            return "This is Index of Home";
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [Route("Home/Details/{id?}")]  // or id=4 default value
        public string Details(int id)
        {
            return "Details of Home " + id;
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
