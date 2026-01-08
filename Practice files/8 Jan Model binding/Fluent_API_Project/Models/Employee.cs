using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Fluent_API_Project.Models
{
    public class Employee
    {
        public int EmployeeId {  get; set; }
        public string EmployeeName {  get; set; }
        public decimal Salary {  get; set; }
        public virtual Department Departments {  get; set; }
    }
}