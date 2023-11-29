using MediatR;

namespace NN.POS.API.App.Commands.Roles;

public class DeleteRoleByNameCommand : IRequest<bool>
{
    public string Name { get; set; }

    public DeleteRoleByNameCommand(string name)
    {
        Name = name;
    }
}