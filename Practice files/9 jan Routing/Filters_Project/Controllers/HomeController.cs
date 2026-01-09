using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters_Project.Models;

namespace Filters_Project.Controllers
{
    //[Authorize]  // 2. nothing will work

    //[AllowAnonymous]  // 1,2. if anything have authorize but due to this that autorized will not work

    //[HandleError(ExceptionType = typeof(DivideByZeroException), View = "DivideByZero")] // for throwing Exception which i build in views
    //[HandleError(ExceptionType = typeof(NullReferenceException), View = "NullRefrence")] // for throwing Exception which i build in views
    //[HandleError] // just checking how its work without giving any view name , but not worked , it is base class exception handeler

    //[LOGCUSTOM_EXCEPTION]      // custom exception  if you wrote in filter config so do not need to write here
    public class HomeController : Controller
    {
        //[Authorize]     // 1. index will not work 
        public ActionResult Index()
        {
            throw new Exception("something went wrong");  // do not need of return it will thorow exaption
            //return View();
        }
        public ActionResult TestMethod1()
        {
            throw new NullReferenceException();
        }
        public ActionResult TestMethod2()
        {
            throw new DivideByZeroException();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}