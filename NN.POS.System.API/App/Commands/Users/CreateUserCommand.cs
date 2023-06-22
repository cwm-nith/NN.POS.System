using MediatR;
using NN.POS.System.API.Core.Dtos.Users;

namespace NN.POS.System.API.App.Commands.Users;

public class CreateUserCommand: IRequest<UserDto>
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime UpdatedAt { get; set; }

    public CreateUserCommand(string name, string username, string password, string email, DateTime updatedAt)
    {
        Name = name;
        Username = username;
        Password = password;
        Email = email;
        UpdatedAt = updatedAt;
    }
}