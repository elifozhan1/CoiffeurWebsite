using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CoiffeurWebsite.Models
{
    public class ApplicationDbContext : IdentityDbContext<UserDetails>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Salon> Salons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Treatment)
                .WithMany() // Eğer Treatment'a bağlı Appointment'ları erişmek istiyorsanız, burada bir ICollection ekleyebilirsiniz.
                .HasForeignKey(a => a.TreatmentID)
                .OnDelete(DeleteBehavior.Restrict); // CASCADE yerine RESTRICT kullanıyoruz
        }


    }
}