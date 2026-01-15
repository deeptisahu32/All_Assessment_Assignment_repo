using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {
        static List<Employee> employeelist = new List<Employee>()
        {
           new Employee{Id=1, EmpName = "Deepti", EmpJob = "Developer", Salary=66000},
           new Employee{Id=2, EmpName = "Jayant", EmpJob = "Tester", Salary=89000},
           new Employee{Id=3, EmpName = "Pooja", EmpJob = "Sales", Salary=90000},
            new Employee{Id=4, EmpName = "vaibhav", EmpJob = "Cloud", Salary=78000 },
            new Employee{Id=5, EmpName = "Komal", EmpJob = "HR", Salary=30000},
        };

        [HttpGet]
        [Route("All Employee")]
        public IEnumerable<Employee> Get()
        {
            return employeelist;
        }

        [HttpGet]
        [Route("Employee by msg")]
        public HttpResponseMessage ShowAllMsg()
        {
            HttpResponseMessage response=Request.CreateResponse(HttpStatusCode.OK,employeelist);
            return response;
        }

        [HttpGet]
        [Route("GetById")]
        public IHttpActionResult GetEmployeeById(int Eid)
        {
            string Ename = employeelist.Where(e=> e.Id == Eid).SingleOrDefault()?.EmpName;
            if (Ename == null)
            {
                return NotFound();
            }
            return Ok(Ename);
        }

        //post 1
        [HttpPost]
        [Route("AllPost")]
        public List<Employee> PostAll([FromBody] Employee employee)
        {
            employeelist.Add(employee);
            return employeelist;
        }

        //post 2


        [HttpPost]
        [Route("EmployeePost")]

        public IEnumerable<Employee> EmployeePost([FromUri] int id,string name,string job)
        {
            var Elist = employeelist[id - 1];
            Elist.Id = id;
            Elist.EmpName = name;
            Elist.EmpJob = job;
            employeelist.Add(Elist);
            return employeelist;
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public Employee Put(int eid, [FromUri] string name, string job, int sal)
        {
            var Elist = employeelist[eid - 1];
            Elist.Id = eid;
            Elist.EmpName = name;
            Elist.EmpJob = job;
            Elist.Salary = sal;
            return Elist;
        }

        //delete

        [HttpDelete]
        [Route("deleteEmployee")]
        public IEnumerable<Employee> Delete(int Eid)
        {
            employeelist.RemoveAt(Eid - 1);
            return employeelist;
        }
    }
}
