using Microsoft.AspNetCore.Mvc;
using Core_Routing.Models;
namespace Core_Routing.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> studentsList = new List<Student>()
        {
            new Student {Id=1,Name="Shobha"},
            new Student{Id=2,Name="Preeti"},
            new Student{Id=3,Name="Ram"},
            new Student{Id=4,Name="Laxman"},
            new Student{Id=5,Name="Visnu"}

        };
        //1 to understand tag helpers
        public ViewResult Index()
        {
            return View(studentsList);
        }
        //2. std details
        public ViewResult StdDetails(int id)
        {
            var stddata=studentsList.FirstOrDefault(x => x.Id==id);
            return View(stddata);
        }

        //3. attribute routing
        [Route("Student/All")]
        public List<Student> GetAllStudents()
        {
            return studentsList;
        }

        [Route("Student/{sid}/Details")]
        public Student GetStudentById(int sid)
        {
            Student? studentdetails = studentsList.FirstOrDefault(s => s.Id ==sid);
            return studentdetails ?? new Student();
        }
        [Route("Student/{sid}/Courses")]
        public List<string>GetStudentCourses(int sid)
        {
            List<string>CourseList =new List<string>();
            if (sid ==1)
            {
                CourseList = new List<string> { "ASP.net Core", "C#.net", "SQL" };

            }
            else if(sid ==2) 
            {
                CourseList = new List<string> { "ASP.net Core", "ADO.net", "SQL" };
            }
            else if( sid ==3)
            {
                CourseList = new List<string> { "ASP.net CoreMVC", "Python", "SQL" };
            }
            else
            {
                CourseList = new List<string> { "Bootstrap", "JAVA", "JS" };
            }
            return CourseList;
        }
    }
}
