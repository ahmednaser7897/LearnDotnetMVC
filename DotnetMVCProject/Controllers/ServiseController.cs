using DotnetMVCProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMVCProject.Controllers;

public class ServiseController : Controller
{
    private readonly IEmployeeRepository EmployeeRepository;
    private readonly IDepartmentRepository DepartmentRepository;
    //Injection in constructor 
    public ServiseController(
        IEmployeeRepository employeeRepository,
        IDepartmentRepository departmentRepository)
    {
        EmployeeRepository = employeeRepository;
        DepartmentRepository = departmentRepository;
    }
    [HttpGet]
    //Injection in action parameter 
    // public IActionResult Index([FromServices] IEmployeeRepository employeeRepository)
    // http://localhost:5074/Servise/Index
    public IActionResult Index()
    {
        ViewBag.EmployeeRepositoryId = EmployeeRepository.Id;
        ViewBag.DepartmentRepositoryId = DepartmentRepository.Id;
        return View("Index");
    }
}
