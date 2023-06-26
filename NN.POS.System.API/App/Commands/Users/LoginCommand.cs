using MediatR;
using NN.POS.System.Model.Dtos.Users;

namespace NN.POS.System.API.App.Commands.Users;

public class LoginCommand : IRequest<UserDto>
{
    public string Username { get; set; }
    
    public string Password { get; set; }

    public LoginCommand(string username, string password)
    {
        Username = username;
        Password = password;
    }
}