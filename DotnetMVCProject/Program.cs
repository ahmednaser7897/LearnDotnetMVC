//https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-10.0

using DotnetMVCProject.Models.Data;
using Microsoft.EntityFrameworkCore;
namespace DotnetMVCProject;

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
      //add custom services to the container
      //Custom Servises : not dclared and not registered in the container
      //AddSingleton() => create only one object for the service and share it accross the application 
      //builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
      //AddScoped() => create one object for the service and share it accross the request pipeline 
      //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
      //AddTransient() => create new object for the service for each request 
      builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
      builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();

      var app = builder.Build();
      //    #region Custom Middlewares
      //    //Custom Middlewares .
      //    // Use can be added multiple times and it will be executed in order.
      //    // it tells the request to execute this middleware and then next middleware in the pipeline.
      //    // if we don't call next() then the request will not proceed to the next middleware in the pipeline.
      //    // and when all next ends each middleware will return to the previce middleware
      //    // and execute the code after await next.Invoke();
      //    //this is called middleware pipeline
      //    //the flow of the request is called request pipeline
      //    //the flow of the response is called response pipeline

      //    app.Use(async (context, next) =>
      //    {
      //        await context.Response.WriteAsync("Hello from Custom Middleware 1\n");
      //        await next.Invoke();
      //        await context.Response.WriteAsync("Hello from Custom Middleware 11\n");
      //    });
      //    app.Use(async (context, next) =>
      //    {
      //        await context.Response.WriteAsync("Hello from Custom Middleware 2\n");
      //        await next.Invoke();
      //        await context.Response.WriteAsync("Hello from Custom Middleware 22\n");
      //    });
      //    //Run() don't have a next delegate
      //    //Run() is a terminal middleware
      //    //Any middleware written after app.Run() will not be executed.
      //    app.Run(static async (context) =>
      //    {
      //        await context.Response.WriteAsync("Hello from terminal middleware\n");
      //    });
      //    app.Use(async (context, next) =>
      //   {
      //       await context.Response.WriteAsync("Hello from Custom Middleware 3\n");
      //       await next.Invoke();
      //       await context.Response.WriteAsync("Hello from Custom Middleware 33\n");
      //   });
      //    #endregion


      // Configure the HTTP request pipeline.
      //This is dev only middleware
      if (!app.Environment.IsDevelopment())
      {
         app.UseExceptionHandler("/Home/Error");
      }

      // this middleware is used to handle the session
      app.UseSession();

      // this middleware is used to route the request to the controller and action
      // so it reads the url and based on that it will route the request to the controller and action
      // this middleware is called EndpointRoutingMiddleware
      app.UseRouting();



      // this middleware is used to handle the authentication
      app.UseAuthorization();

      // this middleware helps to get non server requset static files from wwwroot
      // such as html, css, js, images etc. (Static files)
      // so if the request is not an Action+Controller 
      // this will handles those requests
      // this middleware is called StaticFileMiddleware
      app.MapStaticAssets();

      // this middleware maps the request to the controller and action
      // and also handles the static files
      // this middleware is called EndpointMiddleware
      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}")
          .WithStaticAssets();
      app.Run();

   }
}

