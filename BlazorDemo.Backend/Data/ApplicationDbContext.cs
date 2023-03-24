using BlazorDemo.Backend.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        internal DbSet<Employee> Employees { get; set; }
        internal DbSet<Department> Departments { get; set; }
    }
}
