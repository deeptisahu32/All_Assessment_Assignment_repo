using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Threading;

namespace Fluent_API_Project.Models
{
    public class EDContext:DbContext
    {
        public EDContext(): base("name=EDMODEL"){ }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }

        //1.Deafult names along with the entityname
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().MapToStoredProcedures();
        }

        //2. user names to stored procedure
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>().MapToStoredProcedures(sp => sp.Insert(
        //        s => s.HasName("InsertEmployee_Proc", "dbo")).Update(s => s.HasName("UpdateemployeeProc", "dbo")).Delete(
        //        s => s.HasName("DeleteEmployeeProc", "dbo")));
        //}

        //3. stored procedures for all entities
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
        //}

        //4.with parameter collection

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>().MapToStoredProcedures(sp => sp.Insert(
        //        s => s.HasName("AddEmployee").Parameter(pm => pm.EmployeeName, "EmpName").
        //        Parameter(pm => pm.Salary, "Salary")).Delete(
        //        s => s.HasName("DeleteEmployee").Parameter(pm => pm.EmployeeId, "Id")));
        //}

    }
}