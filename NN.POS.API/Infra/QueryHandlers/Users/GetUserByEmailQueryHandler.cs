using MediatR;
using NN.POS.API.App.Queries.Users;
using NN.POS.API.Core.Exceptions.Users;
using NN.POS.API.Core.IRepositories.Users;
using NN.POS.API.Infra.Tables.User;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.Infra.QueryHandlers.Users;

public class GetUserByEmailQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByEmailQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUserEmailAsync(request.Email, cancellationToken);
        return user != null ? user.ToDto() : throw new UserNotFoundException(request.Email, true);
    }
}