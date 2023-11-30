using MediatR;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.App.Queries.Roles;

public class GetRoleByIdQuery: IRequest<RoleDto?>
{
    public int Id { get; set; }
}