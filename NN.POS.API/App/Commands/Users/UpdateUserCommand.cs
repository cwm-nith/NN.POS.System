using MediatR;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.App.Commands.Users;

public class UpdateUserCommand : IRequest<UserDto>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public UpdateUserCommand(int id, string? name, string? email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}