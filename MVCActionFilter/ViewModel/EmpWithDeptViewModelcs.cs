using MVCActionFilter.Models;
namespace MVCActionFilter.ViewModel;

public class EmpWithDeptViewModelcs
{
    public required Employee Employee { get; set; }
    public required List<Department> Departments { get; set; }
    public override string ToString()
    {
        return "Employee: " + Employee ?? "Null Employee\nDepartments count: " + Departments?.Count ?? "Null Departments";
    }
}
