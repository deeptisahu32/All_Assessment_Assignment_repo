using Microsoft.AspNetCore.Mvc;

namespace MVC_Services.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "This is index action of home";
        }
    }
}
