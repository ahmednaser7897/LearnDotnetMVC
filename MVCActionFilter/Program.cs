//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-10.0

using Microsoft.EntityFrameworkCore;
using MVCActionFilter.Models.Data;
namespace MVCActionFilter;

public static class Program
{
   public static void Main(string[] args)
   {
      var builder = WebApplication.CreateBuilder(args);

      // Add servic es to the container.
      //no we will applay this filter on the global level
      //so it will execute for all actions in all controllers if there is an error
      //this is  a good way to handle errors in the application
      builder.Services.AddControllersWithViews(
         options => options.Filters.Add(new HandelErorrAttribute())
      );
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

      app.UseAuthorization();

      app.MapStaticAssets();

      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}")
          .WithStaticAssets();
      app.Run();

   }
}

