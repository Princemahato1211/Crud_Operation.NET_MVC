using CRUD_OPERATION_2.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_OPERATION_2.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employee_table { get; set; }

    }
}
