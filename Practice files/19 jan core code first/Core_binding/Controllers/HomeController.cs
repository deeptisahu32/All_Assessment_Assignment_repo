using System.Diagnostics;
using Core_binding.CustomBindings;
using Core_binding.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_binding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //check model bindings
        [HttpGet]
        public IActionResult GetDetails([ModelBinder(typeof(CommonSeparatedModel))]List<int>Ids)
        {
            return Ok(Ids);
        }

        [HttpGet]
        public IActionResult GetDates([ModelBinder(typeof(DateRangeModelBinder))] DateRange range)
        {
            return Ok($"From {range.StartDate} to {range.EndDate}");
        }

        public IActionResult Index()
        {
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
