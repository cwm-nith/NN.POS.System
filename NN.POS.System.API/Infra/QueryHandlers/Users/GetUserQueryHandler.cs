using MediatR;
using NN.POS.System.API.App.Queries.Users;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Dtos.Users;
using NN.POS.System.API.Core.IRepositories.Users;
using NN.POS.System.API.Infra.Tables.User;

namespace NN.POS.System.API.Infra.QueryHandlers.Users;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, PagedResult<UserDto>>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<PagedResult<UserDto>> Handle(GetUserQuery r, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetUsersAsync(i => true, r, cancellationToken);
        return users.Map(i => i.ToDto());
    }
}