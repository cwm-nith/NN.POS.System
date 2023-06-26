using MediatR;
using NN.POS.System.Common.Pagination;
using NN.POS.System.Model.Dtos.Users;

namespace NN.POS.System.API.App.Queries.Users;

public class GetUserQuery : PagedQuery, IRequest<PagedResult<UserDto>>
{
}