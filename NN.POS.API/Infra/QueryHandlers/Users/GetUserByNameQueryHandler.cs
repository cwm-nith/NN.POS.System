using MediatR;
using NN.POS.API.App.Queries.Users;
using NN.POS.API.Core.Exceptions.Users;
using NN.POS.API.Core.IRepositories.Users;
using NN.POS.API.Infra.Tables.User;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.Infra.QueryHandlers.Users;

public class GetUserByNameQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByNameQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUserNameAsync(request.Username, cancellationToken);
        return user == null ? throw new UserNotFoundException(request.Username) : user.ToDto();
    }
}