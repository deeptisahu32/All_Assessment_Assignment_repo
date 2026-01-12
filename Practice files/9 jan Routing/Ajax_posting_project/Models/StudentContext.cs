using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Ajax_posting_project.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("name=StdContext") { }

        public DbSet<Student> Students { get; set; }
    }
}