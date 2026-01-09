using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace AJAX_POSTING_PRJ.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("name=stdcontext") { }
        public DbSet<Student> Students { get; set; }
    }
}