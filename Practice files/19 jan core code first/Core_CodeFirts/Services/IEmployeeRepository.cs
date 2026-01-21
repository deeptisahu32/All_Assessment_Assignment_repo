using Core_CodeFirts.Models;

namespace Core_CodeFirts.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee emplchanges);
        Employee DeleteEmployee(int eid);
    }
}
