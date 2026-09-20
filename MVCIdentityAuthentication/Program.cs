//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-10.0

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCIdentityAuthentication.Models;
using MVCIdentityAuthentication.Models.Data;
namespace MVCIdentityAuthentication;

public static class Program
{
   public static void Main(string[] args)
   {
      var builder = WebApplication.CreateBuilder(args);

      // Add servic es to the container.
      builder.Services.AddControllersWithViews();
      builder.Services.AddSession(
      (options) =>
      {
         options.IdleTimeout = TimeSpan.FromMinutes(2);
         options.Cookie.Name = "MySession";
      }
      );

      //add DbContext to the container
      builder.Services.AddDbContext<AppDbContext>(
      options => options.UseSqlServer(ConnectionString.LoadConnectionString())
      );
      // add identity services to the container
      // ApplicationUser is the user model
      // IdentityRole is the role model
      // AddEntityFrameworkStores<AppDbContext>() is used to store the identity data in the database
      builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
        options =>
        {
           //options.Password
           options.Password.RequireDigit = false;
           options.Password.RequireLowercase = true;
           options.Password.RequireUppercase = true;
           options.Password.RequiredLength = 8;
           options.Password.RequireNonAlphanumeric = false;
        }
       ).AddEntityFrameworkStores<AppDbContext>();
      builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
      builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (!app.Environment.IsDevelopment())
      {
         app.UseExceptionHandler("/Home/Error");
      }

      app.UseSession();

      app.UseRouting();
      // it uses the authentication cookie
      // it uses the [Authorize] attribute to check if the user is authenticated
      app.UseAuthentication();
      // it uses the [Authorize(Roles="Admin")] attribute to check if the user is authorized
      app.UseAuthorization();

      app.MapStaticAssets();

      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}")
          .WithStaticAssets();
      app.Run();

   }
}


