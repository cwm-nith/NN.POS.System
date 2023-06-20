namespace NN.POS.System.Core.Dtos.Users;

public class UserDto : BaseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string? Token { get; set; }
    public DateTime? LastLogin { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public UserDto(Guid id, string name, string username, string email, DateTime? lastLogin,
        DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Username = username;
        Email = email;
        LastLogin = lastLogin;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}