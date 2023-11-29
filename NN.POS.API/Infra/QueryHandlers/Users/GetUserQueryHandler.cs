using MediatR;
using NN.POS.API.App.Queries.Users;
using NN.POS.API.Core.IRepositories.Users;
using NN.POS.API.Infra.Tables.User;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.Infra.QueryHandlers.Users;

public class GetUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, PagedResult<UserDto>>
{
    public async Task<PagedResult<UserDto>> Handle(GetUserQuery r, CancellationToken cancellationToken)
    {
        var users = await userRepository.GetUsersAsync(i => true, r, cancellationToken);
        return users.Map(i => i.ToDto());
    }
}