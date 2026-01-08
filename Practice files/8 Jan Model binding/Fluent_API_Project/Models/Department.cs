using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Fluent_API_Project.Models
{
    public class Department
    {
        [Key]
        public int  DeptID {  get; set; }
        public string DeptName {  get; set; }
        public ICollection<Employee> employees { get; set; }
    }
}