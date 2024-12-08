using Microsoft.EntityFrameworkCore;

namespace CoiffeurWebsite.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> ooptions) : base(ooptions)
        {

        }
    }
}