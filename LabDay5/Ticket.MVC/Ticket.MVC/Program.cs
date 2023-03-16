using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TicketSystem.BL;
using TicketSystem.BL.Managers.Developers;
using TicketSystem.DAL.Models;
using TicketSystem.DAL.Repos.DepartmentsRepo;
using TicketSystem.DAL.Repos.DevelopersRepo;
using TicketSystem.DAL.Repos.TicketsRepo;

namespace TicketSystem.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Context
            var connectionString = builder.Configuration.GetConnectionString("tickets");
            builder.Services.AddDbContext<TicketContext>(Options => Options.UseSqlServer(connectionString));
            #endregion

            #region Services
            builder.Services.AddScoped<ITicketsManager, TicketsManager>();
            builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
            builder.Services.AddScoped<IDeveloperManager, DeveloperManager>();

            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IDevelopersRepo, DevelopersRepo>();
            #endregion

            var app = builder.Build();

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

            app.Run();
        }
    }
}