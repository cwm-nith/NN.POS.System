using MediatR;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Dtos.Users;

namespace NN.POS.System.API.App.Queries.Users;

public class GetUserQuery : PagedQuery, IRequest<PagedResult<UserDto>>
{
}