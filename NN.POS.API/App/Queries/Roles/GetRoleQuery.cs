using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.App.Queries.Roles;

public class GetRoleQuery : PagedQuery, IRequest<PagedResult<RoleDto>>
{

}