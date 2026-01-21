
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core_CodeFirts.Models
{
    public class Employee
    {
        [Key]
        public int EmpId {  get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; } = null;
        public string? Position {  get; set; }

        [DisplayName("Deaprtment Name")]
        public int DeptId {  get; set; }

        public Deaprtment ? Departments { get; set; }
    }
}
