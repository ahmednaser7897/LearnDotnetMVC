using DotnetMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DotnetMVCProject.Models.Data;

namespace DotnetMVCProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // AppDbContext context = new AppDbContext();
            // if (!context.Departments.Any())
            // {
            //     context.Departments.AddRange(
            //         new Department()
            //         {
            //             Name = "CS",
            //             ManagerName = "Ahmed",
            //             Employees =
            //             [
            //                 new Employee()
            //         {
            //             Name = "John",
            //             Salary = 1000,
            //             Address = "123 Main St",
            //             ImageUrl = "2.png",
            //             JopTitle = "BackEnd Developer",
            //         },
            //         new Employee()
            //         {
            //             Name = "Ahmed",
            //             Salary = 1500,
            //             Address = "456 Second St",
            //             ImageUrl = "1.png",
            //             JopTitle = "FrontEnd Developer",
            //         },
            //         new Employee()
            //         {
            //             Name = "Sara",
            //             Salary = 1200,
            //             Address = "789 Third St",
            //             ImageUrl = "3.png",
            //             JopTitle = "BackEnd Developer",
            //         }
            //             ]
            //         },

            //         new Department()
            //         {
            //             Name = "IT",
            //             ManagerName = "Ali",
            //             Employees =
            //             [
            //                 new Employee()
            //         {
            //             Name = "Omar",
            //             Salary = 1300,
            //             Address = "101 Fourth St",
            //             ImageUrl = "4.png",
            //             JopTitle = "Backend Developer",
            //         },
            //         new Employee()
            //         {
            //             Name = "Mona",
            //             Salary = 1600,
            //             Address = "202 Fifth St",
            //             ImageUrl = "5.png",
            //             JopTitle = "Frontend Developer",
            //         },
            //         new Employee()
            //         {
            //             Name = "Youssef",
            //             Salary = 1400,
            //             Address = "303 Sixth St",
            //             ImageUrl = "6.png",
            //             JopTitle = "DevOps Engineer",
            //         }
            //             ]
            //         }
            //     );

            //     context.SaveChanges();
            // }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
