using MediatR;

namespace NN.POS.System.Application.Commands.Users;

public class CreateUserCommand: IRequest<int>
{
    public string Username { get; set;}
    public int Age { get; set; }

    public CreateUserCommand(string username, int age)
    {
        Username = username;
        Age = age;
    }
}