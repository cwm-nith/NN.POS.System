using MediatR;
using NN.POS.System.API.Core.IRepositories.Roles;

namespace NN.POS.System.API.App.Commands.Roles.Handlers;

public class DeleteRoleByIdCommandHandler : IRequestHandler<DeleteRoleByIdCommand, bool>
{
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleByIdCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Task<bool> Handle(DeleteRoleByIdCommand request, CancellationToken cancellationToken)
    {
        return _roleRepository.DeleteRoleAsync(request.Id, cancellationToken);
    }
}