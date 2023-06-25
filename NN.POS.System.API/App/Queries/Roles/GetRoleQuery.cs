using System.ComponentModel.DataAnnotations;
using MediatR;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Dtos;
using NN.POS.System.API.Core.Dtos.Roles;

namespace NN.POS.System.API.App.Queries.Roles;

public class GetRoleQuery : PagedQuery, IRequest<PagedResult<RoleDto>>
{

}