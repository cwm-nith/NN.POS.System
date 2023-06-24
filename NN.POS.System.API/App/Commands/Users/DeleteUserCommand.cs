using MediatR;

namespace NN.POS.System.API.App.Commands.Users;

public class DeleteUserCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteUserCommand(int id)
    {
        Id = id;
    }
}