using MediatR;
using NN.POS.System.API.App.Queries.Users;
using NN.POS.System.API.Core.Exceptions.Users;
using NN.POS.System.API.Core.IRepositories.Users;
using NN.POS.System.API.Infra.Tables.User;
using NN.POS.System.Model.Dtos.Users;

namespace NN.POS.System.API.Infra.QueryHandlers.Users;

public class GetUserByEmailQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByEmailQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUserEmailAsync(request.Email, cancellationToken);
        return user != null ? user.ToDto() : throw new UserNotFoundException(request.Email, true);
    }
}