
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HundeProjekt.Data;
using HundeProjekt.Models;
using MvcMovie.Models;
using HundeProjekt.CustomMiddleware;
using Microsoft.AspNetCore.Builder;
using HundeProjekt.Services;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
namespace HundeProjekt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<HundeProjektContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("HundeProjektContext") ?? throw new InvalidOperationException("Connection string 'HundeProjektContext' not found.")));

            builder.Services.AddDbContext<UserContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("UserContext") ?? throw new InvalidOperationException("Connection string 'HundeProjektContext' not found.")));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UserContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<ICourseViewCounter, CourseViewCounter>();


            var app = builder.Build();

           
            //Add SeedData to services
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();          

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.UseMyMiddleware();

            app.Run();
        }
    }
}
