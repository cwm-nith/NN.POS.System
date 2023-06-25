using MediatR;

namespace NN.POS.System.API.App.Commands.Roles;

public class DeleteRoleByNameCommand : IRequest<bool>
{
    public string Name { get; set; }

    public DeleteRoleByNameCommand(string name)
    {
        Name = name;
    }
}