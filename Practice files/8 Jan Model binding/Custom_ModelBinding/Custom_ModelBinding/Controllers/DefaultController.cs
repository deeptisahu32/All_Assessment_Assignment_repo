using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Custom_ModelBinding.Models;
using Custom_ModelBinding.CustomsBinding;

namespace Custom_ModelBinding.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([ModelBinder(typeof(CustomBinder))]CustomModel cm)
        {
           ViewBag.ctitle=cm.Title;
            ViewBag.dt = cm.Date;
            return View(cm);
        }

        //bundling script
        public ActionResult Bundling_minify()
        {
            return View();
        }
    }
}