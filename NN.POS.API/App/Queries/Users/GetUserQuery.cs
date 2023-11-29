using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.App.Queries.Users;

public class GetUserQuery : PagedQuery, IRequest<PagedResult<UserDto>>
{
}