using Microsoft.EntityFrameworkCore;
using WebApiEmployee.Model;

namespace WebApiEmployee.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op) { }
        
            public DbSet<Employee> Employees { get; set; }
        
    }
}
