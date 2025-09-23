using System;
using System.Collections.Generic;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public User(string name, string email, string role)
    {
        Name = name;
        Email = email;
        Role = role;
    }

    public void Update(string name, string email, string role)
    {
        Name = name;
        Email = email;
        Role = role;
    }

    public override string ToString()
    {
        return $"{Name} ({Email}) - {Role}";
    }
}

public class UserManager
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
        Console.WriteLine($"User added: {user}");
    }

    public void RemoveUser(string email)
    {
        var user = FindUserByEmail(email);
        if (user != null)
        {
            users.Remove(user);
            Console.WriteLine($"User removed: {email}");
        }
        else
        {
            Console.WriteLine($"User with email {email} not found.");
        }
    }

    public void UpdateUser(string email, string newName, string newEmail, string newRole)
    {
        var user = FindUserByEmail(email);
        if (user != null)
        {
            user.Update(newName, newEmail, newRole);
            Console.WriteLine($"User updated: {user}");
        }
        else
        {
            Console.WriteLine($"User with email {email} not found.");
        }
    }

    public void PrintAllUsers()
    {
        Console.WriteLine("All users:");
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }

    private User FindUserByEmail(string email)
    {
        return users.Find(u => u.Email == email);
    }
}

public class Program
{
    public static void Main()
    {
        var userManager = new UserManager();

        var user1 = new User("Alice", "alice@example.com", "Admin");
        var user2 = new User("Bob", "bob@example.com", "User");

        userManager.AddUser(user1);
        userManager.AddUser(user2);

        userManager.PrintAllUsers();

        userManager.UpdateUser("bob@example.com", "Bobby", "bobby@example.com", "Admin");

        userManager.RemoveUser("alice@example.com");

        userManager.PrintAllUsers();
    }
}
