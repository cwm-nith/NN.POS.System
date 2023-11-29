using MediatR;
using NN.POS.System.API.App.Queries.Users;
using NN.POS.System.API.Core.Exceptions.Users;
using NN.POS.System.API.Core.IRepositories.Users;
using NN.POS.System.API.Infra.Tables.User;
using NN.POS.System.Model.Dtos.Users;

namespace NN.POS.System.API.Infra.QueryHandlers.Users;

public class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id, cancellationToken);
        return user == null ? throw new UserNotFoundException(request.Id) : user.ToDto();
    }
}