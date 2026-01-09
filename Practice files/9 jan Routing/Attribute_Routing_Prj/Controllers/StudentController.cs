using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Attribute_Routing_Prj.Models;

namespace Attribute_Routing_Prj.Controllers
{
    [RoutePrefix("Trainees")]
    public class StudentController : Controller
    {
        // GET: Student
        List<Student> students = new List<Student>()
        {
            new Student{Id=1,Name="Shobha"},
            new Student{Id=2,Name="Ram"},
            new Student{Id=3,Name="Kridhn"},
            new Student{Id=4,Name="pooja"},
            new Student{Id=5,Name="preeti"},
            new Student{Id=6,Name="jayant" }
        };
        public ActionResult Index()
        {
            return View();
        }

        //get all student
        [HttpGet]
        [Route()]
        public ActionResult GetAllStdudents()
        {
            return View(students);
        }

        // get by id
        //[Route("Student/{studentid}")]    // in url give ?studentid=3 it will work

        //[Route("{studentid:int}")]  // all id
        //[Route("{studentid:int:min(1):max(3)}")]  // in between 1 and 3
          [Route("{studentid:int:range(1,3)}")]  // id within range using constrains

        public ActionResult GetStudentDetails(int studentid)
        {
            Student student = students.FirstOrDefault(s=>s.Id==studentid);
            ViewBag.data = "Student Id";
            return View(student);
        }

        //get by name
        [HttpGet]
        //[Route("{stuname:alpha}")]  //every name will show
        [Route("{stuname:alpha:minlength(4)}")] // only that which len is 4

        public ActionResult GetStudentDetails(string stuname)
        {
            Student student = students.FirstOrDefault(s => s.Name == stuname);
            ViewBag.data = "Student Name";
            return View(student);
        }

        //get studentAources

        [HttpGet]
        [Route("{studentid}/courses")]
        public ActionResult GetStudentCourses(int studentid)
        {
            List<string> CourseList;
            if (studentid == 1)
            {
                CourseList= new List<string>()
                {
                    "ASP.NET","C#","SQL"
                };
            }
            else if(studentid == 2) 
            {
                CourseList = new List<string>()
                {
                    "ASP.NET","C#","Python"
                };
            }
            else if (studentid == 3)
            {
                CourseList = new List<string>()
                {
                    "WEB API","C#","JAVASCRIPT"
                };
            }
            else
            {
                CourseList = new List<string>()
                {
                    "BOOTSTRAP","JQUERY","REACT JS"
                };
            }
            ViewBag.courses = CourseList;
            return View(); ;
        }

        //this will followed by trainiees anf trainer is not part of trainies we will override
        //[Route("/Technial/trainers")]

        //populate the second object model trainer

        // ~ is used to override a routeprefix

        //[Route("~/Technial/trainers")]


        public ActionResult GetTrainers()
        {
            List<Trainer> trainers = new List<Trainer>()
            {
                new Trainer {Id=100,Name="Geeta"},
                new Trainer{Id=101,Name="Shobha"},
                new Trainer{Id=102,Name="Jamuna"},
                new Trainer{Id=104,Name="Pooja"}
            };
            return View(trainers);
        }
    }
}