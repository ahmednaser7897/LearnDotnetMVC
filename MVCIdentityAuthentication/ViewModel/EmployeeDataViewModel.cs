using MVCIdentityAuthentication.Models;
namespace MVCIdentityAuthentication.ViewModel;

public class EmployeeDataViewModel
{
    public Employee Employee { get; set; } = null!;
    public string DeptName { get; set; } = null!;
    public string Message { get; set; } = null!;
    public int Temperature { get; set; }
    public List<string> Branches { get; set; } = null!;
    public string Color { get; set; } = null!;
}
