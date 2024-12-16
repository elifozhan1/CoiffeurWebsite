using Microsoft.EntityFrameworkCore;
using CoiffeurWebsite.Models;

namespace CoiffeurWebsite.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CoiffeurWebsite.Models.Salon> Salon { get; set; } = default!;
    }
}
