using MVC_DATABASE_FIRST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DATABASE_FIRST.Controllers
{
    public class NavigationController : Controller
    {
        northwindEntities db=new northwindEntities();
        // GET: Navigation
        public ActionResult Index()
        {
            return View();
        }
        //1. Fetching data from multiple tables/objects using navigation property
        public ActionResult MultipleData()
        {
            return View(db.Orders.ToList());
        }
    }
}