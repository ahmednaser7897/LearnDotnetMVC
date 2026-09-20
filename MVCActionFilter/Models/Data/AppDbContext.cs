using Microsoft.EntityFrameworkCore;
namespace MVCActionFilter.Models.Data;

public class AppDbContext : DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    // public DbSet<Instructor> Instructors { get; set; }
    // public DbSet<Trainee> Trainees { get; set; }
    // public DbSet<Course> Courses { get; set; }
    // public DbSet<CrsResult> CrsResults { get; set; }

    public AppDbContext() : base()
    {
    }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer(ConnectionString.LoadConnectionString());
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}

