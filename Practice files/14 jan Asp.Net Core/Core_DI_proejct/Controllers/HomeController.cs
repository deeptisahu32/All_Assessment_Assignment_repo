using Core_DI_proejct.Model;
using Microsoft.AspNetCore.Mvc;

namespace Core_DI_proejct.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public HomeController(IStudentRepository repo) // DI in constructor 
        {
            _studentRepository = repo;
        }
        public JsonResult Index([FromServices]IStudentRepository srepo)  //di in method when we wrote that from services
        {
            //StudentRepository studentRepository = new StudentRepository();

            //List<Student>? AllStudent = _studentRepository?.GetAllStudent();
            List<Student>? AllStudent = srepo?.GetAllStudent();


            return Json(AllStudent);
        }
        public JsonResult Studentdetails(int id)
        {
            //StudentRepository stdrepo=new StudentRepository();
            Student? student = _studentRepository?.GetStudentById(id);
            return Json(student);           
        }
    }
}
