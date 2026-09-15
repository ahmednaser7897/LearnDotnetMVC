using Microsoft.AspNetCore.Mvc;
using DotnetMVCProject.Models.Data;
using DotnetMVCProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetMVCProject.Controllers;

public class InstructorController : Controller
{
    readonly AppDbContext context = new();
    [HttpGet]
    public IActionResult Index()
    {
        List<Instructor> instructors = context.Instructors
        .Include(x => x.Department)
        .Include(x => x.Course).ToList();
        return View("Index", instructors);
    }
}
