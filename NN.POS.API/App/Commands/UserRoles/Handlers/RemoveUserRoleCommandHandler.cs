using MediatR;
using NN.POS.API.Core.IRepositories.Roles;

namespace NN.POS.API.App.Commands.UserRoles.Handlers;

public class RemoveUserRoleCommandHandler(IUserRoleRepository repository) : IRequestHandler<RemoveUserRoleCommand, bool>
{
    public async Task<bool> Handle(RemoveUserRoleCommand request, CancellationToken cancellationToken)
    {
        return await repository.RemoveUserRoleAsync(request.UserId, request.RoleId, cancellationToken);
    }
}