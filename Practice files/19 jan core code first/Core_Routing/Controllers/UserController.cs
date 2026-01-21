using Microsoft.AspNetCore.Mvc;
using Core_Routing.Models;
using Microsoft.Extensions.Primitives;
namespace Core_Routing.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult submitform()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult SubmitForm(Users user)
        //{
        //    if (user != null)
        //    {
        //        if(ModelState.IsValid)
        //        {
        //            ViewBag.Message=$"User Created : UserName : {user.UserName}," +
        //                $"User Email :{user.Email}";
        //            ModelState.Clear();
        //            return View("Index");
        //        }
        //    }
        //    return View("Index");
        //}

        public IActionResult SubmitForm(IFormCollection frmc)
        {
            //uses keys to get the collection of form values
            var Keys= frmc.Keys;

            //check if a key id existing
            if(frmc.ContainsKey("UserName") && frmc.ContainsKey("Email"))
            {
                if(frmc.TryGetValue("UserName",out StringValues username) && 
                    frmc.TryGetValue("Email",out StringValues email))
                {
                    ViewBag.Message = $"User Created : UserName : {username}," +
                     $"User Email :{email}";
                }
                else
                {
                    ViewBag.Message = "UserName or Email not Found";
                }
                
            }
            else
            {
                ViewBag.Message = "Forms does not contain any keys";
            }
            return View("Index");

        }

    }
}
