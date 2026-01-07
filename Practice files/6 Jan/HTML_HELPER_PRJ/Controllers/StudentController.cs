using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTML_HELPER_PRJ.Models;

namespace HTML_HELPER_PRJ.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        //1. stronglytyped helper
        public ActionResult Strongly_Typed_Helper()
        {
            return View();
        }

        //2. templater helper individiual
        public ActionResult TemplatedHelper_ind()
        {
            return View();
        }

        //3. templated helper for the entire model (editor template)
        public ActionResult TemplateforModel()
        {
            return View();
        }

        //4. Display template

        public ActionResult StudentDisplay()
        {
            Students students = new Students()
            {
                RNo=1,
                Name="Rahul",
                Address="Chennai"
            };
            ViewData["stddata"] = students;
            return View(students);
        }

        //5. Standard helper

        public ActionResult StandardHelper()
        {
            return View();
        }
    }
}