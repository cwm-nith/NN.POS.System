using MediatR;
using NN.POS.System.API.Core.Entities.Roles;
using NN.POS.System.API.Core.IRepositories.Roles;

namespace NN.POS.System.API.App.Commands.Roles.Handlers;

public class CreateRoleManyCommandHandler : IRequestHandler<CreateRoleManyCommand, bool>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleManyCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Task<bool> Handle(CreateRoleManyCommand request, CancellationToken cancellationToken)
    {
        var roleEntities = request.Roles.Select(i =>
            new RoleEntity(i.Name, DateTime.UtcNow, DateTime.UtcNow)
            {
                Description = i.Description,
                DisplayName = i.DisplayName,
            }).ToList();
        return _roleRepository.CreateRoleManyAsync(roleEntities, cancellationToken);
    }
}