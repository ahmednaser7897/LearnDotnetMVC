using DotnetMVCProject.Models;
using DotnetMVCProject.Models.Data;
using DotnetMVCProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetMVCProject.Controllers
{
    public class EmployeeController : Controller
    {
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
        readonly AppDbContext context = new();
        // http://localhost:5074/Employee/ViewDataDetails?id=1
        public IActionResult ViewDataDetails(int id)
        {
            Employee? employee = context.Employees.Find(id);
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
            Employee? employee = context.Employees.Find(id);
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
            Employee? employee = context.Employees
            .Include(e => e.Department)
            .FirstOrDefault(e => e.Id == id);
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
            Employee? employee = context.Employees
            .Include(e => e.Department)
            .FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                EmpWithDeptViewModelcs viewModel = new()
                {
                    Employee = employee,
                    Departments = context.Departments.ToList()
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
                    Departments = context.Departments.ToList()
                };
                return View("Edit", viewModel);
            }
            else
            {
                Employee? employee = context.Employees
                .FirstOrDefault(e => e.Id == em.Id);
                if (employee != null)
                {
                    employee.Name = em.Name;
                    employee.Salary = em.Salary;
                    employee.JopTitle = em.JopTitle;
                    employee.Address = em.Address;
                    employee.DepartmentId = em.DepartmentId; context.Update(employee);
                    context.SaveChanges();
                    return RedirectToAction("GetEmployeesOfDepartment", employee.DepartmentId);
                }
                else
                {
                    return NotFound($"Employee with id {em.Id} is not found");
                }

            }

        }
        public IActionResult GetEmployeesOfDepartment(int id)
        {
            List<Employee> employees = context.Departments
            .Include(e => e.Employees)
            .FirstOrDefault(e => e.Id == id)?.Employees ?? [];
            return View("GetEmployeesOfDepartment", employees);
        }

    }
}


