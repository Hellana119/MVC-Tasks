using Login_Register.Database.Context;
using Login_Register.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Context
var connectionString = "server=.; Database=UsersDB; Trusted_Connection=true; Encrypt=false;";

builder.Services.AddDbContext<SystemContext>(options =>
    options.UseSqlServer(connectionString)) ;
#endregion

#region Identity
builder.Services.AddIdentity<CustomUser, IdentityRole>(options =>
{
    options.Password.RequireLowercase= false;
    options.Password.RequireUppercase= false;
    options.Password.RequireNonAlphanumeric= true;

    options.User.RequireUniqueEmail= true;
}).AddEntityFrameworkStores<SystemContext>();
#endregion

#region Authentication

builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = "/Users/Login";
    options.Cookie.Name = "AuthCookie";
});

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = "CoolCookie";
//    options.DefaultChallengeScheme = "CoolCookie";

//    options.DefaultSignInScheme = "CoolCookie";

//}).AddCookie("CoolCookie", options =>
//{
//    options.LoginPath = "/Users/Login";
//});
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
