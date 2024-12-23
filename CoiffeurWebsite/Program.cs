using CoiffeurWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoiffeurWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Veritabanı bağlantısını ayarla
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Identity yapılandırması
            builder.Services.AddIdentity<UserDetails, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true; // E-posta doğrulaması gerekli
                options.Password.RequireNonAlphanumeric = false; // Özel karakter gerekmiyor
                options.Password.RequireDigit = true; // En az bir rakam gerekli
                options.Password.RequireLowercase = true; // Küçük harf gerekli
                options.Password.RequiredLength = 5; // En az 5 karakter
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

            // MVC ve Razor Pages desteği
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Uygulama oluşturma ve yapılandırma
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // HTTP Pipeline ayarları
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}