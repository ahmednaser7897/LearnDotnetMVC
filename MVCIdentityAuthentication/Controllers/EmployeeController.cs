using MVCIdentityAuthentication.Models;
using MVCIdentityAuthentication.Models.Data;
using MVCIdentityAuthentication.Repository;
using MVCIdentityAuthentication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MVCIdentityAuthentication.Controllers;

[Authorize]
public class EmployeeController : Controller
{
    //readonly AppDbContext context = new();
    private readonly IEmployeeRepository EmployeeRepository;
    private readonly IDepartmentRepository DepartmentRepository;
    public EmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)//Injection
    {
        EmployeeRepository = employeeRepository;
        DepartmentRepository = departmentRepository;
    }
    // we can pass data to the view with 2 ways
    // 1- by sending it to View() method 
    // and take it from Model in the view
    // 2- using ViewData dictionary
    // we add the key in ViewData and take it from Model in the view
    // we can add any type of data to the ViewData dictionary
    // we can also pass the Model itself using ViewData.Model 
    // 3- using ViewBag dynamic property
    // we add the key in ViewBag and take it from Model in the view
    // we can add any type of data to the ViewBag dynamic property
    // we can also pass the Model itself using ViewBag.Model 
    // it enable us to not using casting in the view
    //----------------------------------------------
    // 4- using ViewModel 
    // we create a new class that contain the data we want to pass to the view
    // and we pass it to the View() method 
    // and we use it in the view

    // http://localhost:5074/Employee/ViewDataDetails?id=1
    public IActionResult ViewDataDetails(int id)
    {
        Employee? employee = EmployeeRepository.GetById(id);
        if (employee != null)
        {
            string? msg = $"This {employee!.Name} data";
            const int temp = 33;
            List<string> branches = ["Cairo", "Alex", "Aswan"];
            ViewData["msg"] = msg;
            ViewData["temp"] = temp;
            ViewData["branches"] = branches;
            ViewData.Model = employee;
            return View("ViewDataDetails", employee);
        }
        else
        {
            return NotFound($"Employee with id {id} is not found");
        }


    }
    // http://localhost:5074/Employee/ViewBagDetails?id=1
    public IActionResult ViewBagDetails(int id)
    {
        Employee? employee = EmployeeRepository.GetById(id);
        if (employee != null)
        {
            string? msg = $"This {employee!.Name} data";
            const int temp = 33;
            List<string> branches = ["Cairo", "Alex", "Aswan"];
            ViewBag.msg = msg;
            ViewBag.temp = temp;
            ViewBag.branches = branches;
            ViewBag.Model = employee;
            return View("ViewBagDetails", employee);
        }
        else
        {
            return NotFound($"Employee with id {id} is not found");
        }


    }

    // http://localhost:5074/Employee/ViewModelDetails?id=1
    public IActionResult ViewModelDetails(int id)
    {
        Employee? employee = EmployeeRepository.GetById(id);
        if (employee != null)
        {
            EmployeeDataViewModel viewModel = new()
            {
                Employee = employee,
                Message = "This {employee!.Name} data",
                Temperature = 33,
                Branches = ["Cairo", "Alex", "Aswan"],
                Color = "red",
                DeptName = employee?.Department?.Name ?? "Unknown"
            };

            return View("ViewModelDetails", viewModel);
        }
        else
        {
            return NotFound($"Employee with id {id} is not found");
        }


    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        Employee? employee = EmployeeRepository.GetById(id);
        if (employee != null)
        {
            EmpWithDeptViewModelcs viewModel = new()
            {
                Employee = employee,
                Departments = DepartmentRepository.GetAll()
            };
            return View("Edit", viewModel);
        }
        else
        {
            return NotFound($"Employee with id {id} is not found");
        }
    }
    [HttpPost]
    public IActionResult SaveEdit(Employee em)
    {
        if (em.Name == null || em.Salary <= 0 || em.JopTitle == null || em.Address == null)
        {
            EmpWithDeptViewModelcs viewModel = new()
            {
                Employee = em,
                Departments = DepartmentRepository.GetAll()
            };
            return View("Edit", viewModel);
        }
        else
        {
            Employee? employee = EmployeeRepository.GetById(em.Id);
            if (employee != null)
            {
                employee.Id = em.Id;
                employee.Name = em.Name;
                employee.Salary = em.Salary;
                employee.JopTitle = em.JopTitle;
                employee.Address = em.Address;
                employee.DepartmentId = em.DepartmentId;
                EmployeeRepository.Update(employee);
                EmployeeRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound($"Employee with id {em.Id} is not found");
            }

        }

    }
    public IActionResult Add()
    {
        EmpWithDeptViewModelcs viewModel = new()
        {
            Employee = new Employee(),
            Departments = DepartmentRepository.GetAll()
        };
        return View("Add", viewModel);
    }
    [HttpPost]
    public IActionResult SaveAdd([Bind(Prefix = "Employee")] Employee employee)
    {
        //we also can add custom erorrs without using model constraints and ModelState 
        if (string.IsNullOrEmpty(employee.ImageUrl))
        {
            ModelState.AddModelError("Employee.ImageUrl", "Image is required");
        }
        //if (em.Name == null || em.Salary <= 0 || em.JopTitle == null || em.Address == null)
        //ModelState is a dictionary that contains the validation errors
        //so this checks if all constrains in the model are valid
        if (ModelState.IsValid)
        {
            Console.WriteLine("1-employee" + employee);
            EmployeeRepository.Add(employee);
            EmployeeRepository.SaveChanges();
            return RedirectToAction("Index");
        }
        Console.WriteLine("2-employee" + employee);
        EmpWithDeptViewModelcs viewModel = new()
        {
            Employee = employee,
            Departments = DepartmentRepository.GetAll()
        };
        return View("Add", viewModel);
    }
    public IActionResult Index()
    {
        return View("Index", EmployeeRepository.GetAll());
    }
}




