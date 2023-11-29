using MediatR;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.App.Commands.Users;

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