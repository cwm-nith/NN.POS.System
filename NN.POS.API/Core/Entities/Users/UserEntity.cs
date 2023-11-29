using Microsoft.AspNetCore.Identity;
using NN.POS.API.Core.Exceptions.Users;

namespace NN.POS.API.Core.Entities.Users;

public class UserEntity : IBaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Token { get; set; }
    public DateTime? LastLogin { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public void SetPassword(string pass, IPasswordHasher<UserEntity> passwordHasher)
    {
        if (string.IsNullOrEmpty(pass) || passwordHasher is null)
        {
            throw new InvalidPasswordException();
        }
        Password = passwordHasher.HashPassword(this, pass);
    }

    public bool ValidatePassword(string password, IPasswordHasher<UserEntity> passwordHasher)
    {
        return passwordHasher?.VerifyHashedPassword(this, Password, password) != PasswordVerificationResult.Failed;
    }
}