using System.Diagnostics;
using DotnetMVCProject.Models;
using DotnetMVCProject.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMVCProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            AppDbContext context = new AppDbContext();
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