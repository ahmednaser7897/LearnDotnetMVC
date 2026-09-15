namespace DotnetMVCProject.Models;

public class Trainee
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string Address { get; set; } = null!;
    public decimal Grade { get; set; }

    public List<CrsResult>? CrsResults { get; set; }
}