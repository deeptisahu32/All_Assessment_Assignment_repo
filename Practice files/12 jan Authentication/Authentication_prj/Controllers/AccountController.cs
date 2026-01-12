using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Authentication_prj.Models;
using Authentication_prj.CustomFilters;

namespace Authentication_prj.Controllers
{
    //[CustomAuthenticationFilter]

    //[Authorize] // immediatly reject 
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //here we will check the values entered by the user
                if (model.UserName.ToLower()=="admin" && model.Password == "admin@123")
                {
                    //store the username in a session
                    Session["UserName"] = model.UserName;
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name or Password");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        
    }
}