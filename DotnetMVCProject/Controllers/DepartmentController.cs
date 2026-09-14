using DotnetMVCProject.Models.Data;
using DotnetMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetMVCProject.Controllers
{
    public class DepartmentController : Controller
    {
        readonly AppDbContext context = new();

        // http://localhost:5074/Department/Index
        public IActionResult Index()
        {
            List<Department> departments = context.Departments.Include(d => d.Employees).ToList();
            return View("Index", departments);
        }
    }
}
