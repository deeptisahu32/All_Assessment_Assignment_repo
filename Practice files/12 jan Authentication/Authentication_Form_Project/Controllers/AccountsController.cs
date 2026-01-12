using Authentication_Form_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Authentication_Form_Project.Models;


namespace Authentication_Form_Project.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            using(Authentication_MVCEntities context = new Authentication_MVCEntities())
            {
                bool IsValidUser = context.Users.Any(user => user.UserName.ToLower() ==
                model.UserName.ToLower() && user.UserName == model.Userpassword);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User model)
        {
            using (Authentication_MVCEntities context = new Authentication_MVCEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        //logoff
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}