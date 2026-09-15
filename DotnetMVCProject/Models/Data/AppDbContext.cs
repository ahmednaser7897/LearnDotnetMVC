using Microsoft.EntityFrameworkCore;
namespace DotnetMVCProject.Models.Data;

public class AppDbContext : DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CrsResult> CrsResults { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString.LoadConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

