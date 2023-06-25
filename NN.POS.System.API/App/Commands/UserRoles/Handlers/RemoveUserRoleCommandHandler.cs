using MediatR;
using NN.POS.System.API.Core.IRepositories.Roles;

namespace NN.POS.System.API.App.Commands.UserRoles.Handlers;

public class RemoveUserRoleCommandHandler : IRequestHandler<RemoveUserRoleCommand, bool>
{
    private readonly IUserRoleRepository _repository;

    public RemoveUserRoleCommandHandler(IUserRoleRepository repository)
    {
        _repository = repository;
    }

    public Task<bool> Handle(RemoveUserRoleCommand request, CancellationToken cancellationToken)
    {
        return _repository.RemoveUserRoleAsync(request.UserId, request.RoleId, cancellationToken);
    }
}