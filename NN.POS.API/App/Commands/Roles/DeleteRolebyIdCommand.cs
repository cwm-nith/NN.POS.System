using MediatR;

namespace NN.POS.API.App.Commands.Roles;

public class DeleteRoleByIdCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteRoleByIdCommand(int id)
    {
        Id = id;
    }
}