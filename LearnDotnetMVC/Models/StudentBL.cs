namespace LearnDotnetMVC.Models;

public class StudentBL
{
    private readonly List<Student> Students;
    public StudentBL()
    {
        Students =
        [
            new Student { Id = 1, Name = "Ahmed", ImageUrl = "1.png" },
            new Student { Id = 2, Name = "Osama", ImageUrl = "2.png" },
            new Student { Id = 3, Name = "Kareem", ImageUrl = "3.png" },
            new Student { Id = 4, Name = "Mohamed", ImageUrl = "4.png" },
            new Student { Id = 5, Name = "Ali", ImageUrl = "1.png" },

        ];
    }
    public List<Student> GetStudents()
    {
        return Students;
    }
    public Student? GetStudent(int id)
    {
        return Students.FirstOrDefault(s => s.Id == id);
    }
}
