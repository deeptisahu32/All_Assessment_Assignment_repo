using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelState_Prj.Models;

namespace ModelState_Prj.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //1. If validation succeeds
        public ActionResult UserStatus()
        {
            ViewBag.Status = "Validation Successful";
            return View();
        }

        //2.Add a user
        [HttpGet]
        public ActionResult AddUser()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            if (string.IsNullOrEmpty(user.Lname))
            {
                ModelState.AddModelError(nameof(user.Lname),"Please Enter the Last Name");
            }
            if(user.age<21 || user.age > 45)
            {
                ModelState.AddModelError("age", "only 21 to 45 years are accepted");
            }
            if(ModelState.IsValid)
            {
                return RedirectToAction("UserStatus");               
            }
            else
            {
                TempData["lastname"] = user.Lname;
                TempData["age"]=user.age;
                TempData.Keep();
                return View(user);
            }
        }
    }
}