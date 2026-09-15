namespace DotnetMVCProject.Models;

public class Instructor
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public decimal Salary { get; set; }
    public string Address { get; set; } = null!;

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }

    public int? CourseId { get; set; }
    public Course? Course { get; set; }
}
