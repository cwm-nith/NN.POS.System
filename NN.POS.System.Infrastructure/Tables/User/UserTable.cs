using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.System.Infrastructure.Tables.User;

public class UserTable : BaseTable
{

    [Column("name")]
    public string Name { get; set; }
    
    [Column("username")]
    public string Username { get; set; }

    [Column("password")]
    public string Password { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public List<UserSessionTable> UserSessions { get; set; } = new();

    public UserTable(Guid id, string name, string username, string password, string email, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Username = username;
        Password = password;
        Email = email;
        UpdatedAt = updatedAt;
    }
}