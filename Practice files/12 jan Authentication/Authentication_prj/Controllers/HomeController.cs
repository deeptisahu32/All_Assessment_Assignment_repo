using Authentication_prj.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authentication_prj.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuthenticationFilter]  // using this without login user we can not access pages
        public ActionResult Index()
        {
            return View();
        }
        [CustomAuthenticationFilter]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [CustomAuthenticationFilter]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}