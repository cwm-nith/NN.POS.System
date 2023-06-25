using MediatR;

namespace NN.POS.System.API.App.Commands.Roles;

public class DeleteRoleByIdCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteRoleByIdCommand(int id)
    {
        Id = id;
    }
}