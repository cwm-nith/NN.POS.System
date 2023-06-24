using MediatR;
using NN.POS.System.API.App.Queries.Users;
using NN.POS.System.API.Core.Dtos.Users;
using NN.POS.System.API.Core.Exceptions.Users;
using NN.POS.System.API.Core.IRepositories.Users;
using NN.POS.System.API.Infra.Tables.User;

namespace NN.POS.System.API.Infra.QueryHandlers.Users;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        return user == null ? throw new UserNotFoundException(request.Id) : user.ToDto();
    }
}