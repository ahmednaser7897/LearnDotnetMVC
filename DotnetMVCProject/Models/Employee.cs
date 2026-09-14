namespace DotnetMVCProject.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Salary { get; set; }
    public string JopTitle { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string Address { get; set; } = null!;
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
}
