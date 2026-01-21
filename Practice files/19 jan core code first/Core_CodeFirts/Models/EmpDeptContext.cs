using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;

namespace Core_CodeFirts.Models
{
    public class EmpDeptContext:DbContext
    {
        public EmpDeptContext(DbContextOptions<EmpDeptContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }

        // 2. adding our domain classess

        public DbSet<Deaprtment> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
