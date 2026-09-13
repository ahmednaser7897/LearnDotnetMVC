using LearnDotnetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnDotnetMVC.Controllers;


public class StudentController : Controller
{
    //http://localhost:5190/Student/ShowStudents
    public IActionResult ShowStudents()
    {
        var students = new StudentBL().GetStudents();
        return View("ShowAll", students);
    }
    //http://localhost:5190/Student/ShowStudentById/1
    public IActionResult ShowStudentById(int id)
    {
        var student = new StudentBL().GetStudent(id);
        return View("ShowOne", student);
    }
}
