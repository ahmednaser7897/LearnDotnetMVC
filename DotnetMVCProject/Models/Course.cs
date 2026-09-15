namespace DotnetMVCProject.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Degree { get; set; }
    public int MinDegree { get; set; }

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }

    public List<Instructor>? Instructors { get; set; }
    public List<CrsResult>? CrsResults { get; set; }
}
