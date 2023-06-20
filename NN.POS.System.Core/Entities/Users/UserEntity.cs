using Microsoft.AspNetCore.Identity;
using NN.POS.System.Core.Exceptions.Users;

namespace NN.POS.System.Core.Entities.Users;

public class UserEntity : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; }
    public string? Token { get; set; }
    public DateTime? LastLogin { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public UserEntity(Guid id, string name, string username, string email, DateTime? lastLogin,
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

    public void SetPassword(string password, IPasswordHasher<UserEntity> passwordHasher)
    {
        if (string.IsNullOrWhiteSpace(password) || passwordHasher is null)
        {
            throw new InvalidPasswordException();
        }

        Password = password;
        Password = passwordHasher.HashPassword(this, password);
    }

    public bool ValidatePassword(string password, IPasswordHasher<UserEntity> passwordHasher)
    {
        return passwordHasher?.VerifyHashedPassword(this, Password, password) != PasswordVerificationResult.Failed;
    }
}