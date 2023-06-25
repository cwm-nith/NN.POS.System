using MediatR;
using NN.POS.System.API.Core.IRepositories.Roles;

namespace NN.POS.System.API.App.Commands.Roles.Handlers;

public class DeleteRoleByNameCommandHandler : IRequestHandler<DeleteRoleByNameCommand, bool>
{
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleByNameCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Task<bool> Handle(DeleteRoleByNameCommand request, CancellationToken cancellationToken)
    {
        return _roleRepository.DeleteRoleAsync(request.Name, cancellationToken);
    }
}