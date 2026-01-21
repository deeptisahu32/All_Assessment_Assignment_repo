using System.ComponentModel.DataAnnotations;

namespace Core_CodeFirts.Models
{
    public class Deaprtment
    {
        [Key]
        public int DeptId {  get; set; }
        public string? DeptName { get; set; }

        public List<Employee>? Employees { get; set; }
    }
}
