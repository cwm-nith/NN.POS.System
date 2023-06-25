using MediatR;
using NN.POS.System.API.Core.IRepositories.Roles;

namespace NN.POS.System.API.App.Commands.UserRoles.Handlers;

public class AddRoleToUserCommandHandler : IRequestHandler<AddRoleToUserCommand, bool>
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly ILogger<AddRoleToUserCommandHandler> _logger;

    public AddRoleToUserCommandHandler(IUserRoleRepository userRoleRepository, ILogger<AddRoleToUserCommandHandler> logger)
    {
        _userRoleRepository = userRoleRepository;
        _logger = logger;
    }

    public Task<bool> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
    {
        return _userRoleRepository.AddRoleToUserAsync(request.UserId, request.RoleId, cancellationToken);
    }
}