using MediatR;
using NN.POS.API.Core.IRepositories.Roles;

namespace NN.POS.API.App.Commands.Roles.Handlers;

public class DeleteRoleByNameCommandHandler(IRoleRepository roleRepository) : IRequestHandler<DeleteRoleByNameCommand, bool>
{
    public async Task<bool> Handle(DeleteRoleByNameCommand request, CancellationToken cancellationToken)
    {
        return await roleRepository.DeleteRoleAsync(request.Name, cancellationToken);
    }
}