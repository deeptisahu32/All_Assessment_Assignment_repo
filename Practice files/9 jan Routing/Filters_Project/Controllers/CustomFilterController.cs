using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters_Project.Custom_Filter;

namespace Filters_Project.Controllers
{
    public class CustomFilterController : Controller
    {
        // GET: CustomFilter
        public string Index()
        {
            return "Index Action of custom controller Invoked";
            //return View();
        }
        //2. testing the custom filter trackexecutions

        [TrackExecutions]
        public string Welcome()
        {
            throw new Exception("Exception Occurred");
        }
    }
}