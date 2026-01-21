using System.Security.Cryptography.X509Certificates;

namespace Core_DI_proejct.Model
{
    public class StudentRepository:IStudentRepository
    {
        public List<Student> Studentdata()
        {
            return new List<Student>()
            {
                new Student{StudentId=1,Name="Pooja",Branch="CSE",Gender="Female"},                
                new Student{StudentId=2,Name="Komal",Branch="IT",Gender="Female"},        
                new Student{StudentId=3,Name="Raj",Branch="EEE",Gender="male"},                 
            };

            
        }
        public Student GetStudentById(int id)
        {
            return Studentdata().FirstOrDefault(s => s.StudentId == id) ?? new Student();
        }
        public List<Student> GetAllStudent()
        {
            return Studentdata();         
        }
    }
}
