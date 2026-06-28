namespace Tackify.Models;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public Roles Role { get; set; }

    public User(string name, string email, Roles role)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Role = role;
    }
}