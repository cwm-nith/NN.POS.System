using MediatR;
using NN.POS.System.Common.Pagination;
using NN.POS.System.Model.Dtos.Roles;

namespace NN.POS.System.API.App.Queries.Roles;

public class GetRoleQuery : PagedQuery, IRequest<PagedResult<RoleDto>>
{

}