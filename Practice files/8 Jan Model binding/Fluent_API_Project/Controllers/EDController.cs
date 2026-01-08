using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fluent_API_Project.Models;

namespace Fluent_API_Project.Controllers
{
    public class EDController : Controller
    {
        EDContext edContext = new EDContext();
        // GET: ED
        public ActionResult Index()
        {
            return View(edContext.employees.ToList());
        }

        //create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            edContext.employees.Add(e);
            edContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}