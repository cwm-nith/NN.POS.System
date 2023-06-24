using MediatR;
using NN.POS.System.API.App.Queries.Users;
using NN.POS.System.API.Core.Dtos.Users;
using NN.POS.System.API.Core.Exceptions.Users;
using NN.POS.System.API.Core.IRepositories.Users;
using NN.POS.System.API.Infra.Tables.User;

namespace NN.POS.System.API.Infra.QueryHandlers.Users;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUserEmailAsync(request.Email, cancellationToken);
        return user != null ? user.ToDto() : throw new UserNotFoundException(request.Email, true);
    }
}