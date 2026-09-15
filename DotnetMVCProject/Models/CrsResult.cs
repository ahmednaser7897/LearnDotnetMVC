namespace DotnetMVCProject.Models;

public class CrsResult
{
    public int Id { get; set; }
    public decimal Degree { get; set; }

    public int? CourseId { get; set; }
    public Course? Course { get; set; }

    public int? TraineeId { get; set; }
    public Trainee? Trainee { get; set; }
}
