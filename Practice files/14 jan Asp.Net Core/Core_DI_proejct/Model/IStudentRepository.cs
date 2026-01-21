namespace Core_DI_proejct.Model
{
    public interface IStudentRepository
    {

        List<Student> GetAllStudent();   // return all students
        Student GetStudentById(int id);


    }
}
