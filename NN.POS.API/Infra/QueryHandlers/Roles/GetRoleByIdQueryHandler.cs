using MediatR;
using NN.POS.API.App.Queries.Roles;
using NN.POS.API.Core.IRepositories.Roles;
using NN.POS.API.Infra.Tables.Roles;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.Infra.QueryHandlers.Roles;

public class GetRoleByIdQueryHandler(IRoleRepository repository) : IRequestHandler<GetRoleByIdQuery, RoleDto?>
{
    public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetRoleByIdAsync(request.Id, cancellationToken);
        return data?.ToDto();
    }
}