using MediatR;
using NN.POS.System.API.Core.IRepositories.Roles;

namespace NN.POS.System.API.App.Commands.UserRoles.Handlers;

public class AddRoleToUserCommandHandler(IUserRoleRepository userRoleRepository) : IRequestHandler<AddRoleToUserCommand, bool>
{
    public async Task<bool> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
    {
        return await userRoleRepository.AddRoleToUserAsync(request.UserId, request.RoleId, cancellationToken);
    }
}