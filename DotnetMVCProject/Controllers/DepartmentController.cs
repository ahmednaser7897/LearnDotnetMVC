using DotnetMVCProject.Models;
using DotnetMVCProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DotnetMVCProject.Controllers;

public class DepartmentController : Controller
{
    //readonly AppDbContext context = new();
    private readonly IDepartmentRepository DepartmentRepository;
    public DepartmentController(IDepartmentRepository departmentRepository)
    {
        DepartmentRepository = departmentRepository;
    }

    // http://localhost:5074/Department/Index
    public IActionResult Index()
    {
        return View("Index", DepartmentRepository.GetAll());
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View("Add");
    }
    // we use this to force  view to send form data as POST
    // so the data will not be in the url(params) it will be in the form data
    // and data will be sent in the request body
    // and it will not be visible in the url
    // so if we use this http://localhost:5074/Bind/SaveAdd?Id=1&Name=John&ManagerName=Doe
    // or we use method GET in the view
    // it will not be found "This localhost page can’t be found"
    [HttpPost]
    public IActionResult SaveAdd(Department department)
    {
        if (!department.Name.IsNullOrEmpty())
        {
            DepartmentRepository.Add(department);
            DepartmentRepository.SaveChanges();
            TempData["message"] = $"Department {department.Name} added successfully";
            //THIS TO CALL THE ACTION NOT THE VIEW
            return RedirectToAction("Index");
        }
        else
        {
            // THIS TO SEND THE OLD OBJECT WITH ERROR
            // so the filds value not empty
            return View("Add", department);
        }

    }
}
