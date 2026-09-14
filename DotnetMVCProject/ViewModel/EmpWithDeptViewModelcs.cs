using DotnetMVCProject.Models;
namespace DotnetMVCProject.ViewModel;

public class EmpWithDeptViewModelcs
{
    public required Employee Employee { get; set; }
    public required List<Department> Departments { get; set; }
}
