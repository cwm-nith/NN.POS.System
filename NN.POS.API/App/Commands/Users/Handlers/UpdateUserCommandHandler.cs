using MediatR;
using NN.POS.API.Core.Exceptions.Users;
using NN.POS.API.Core.IRepositories.Users;
using NN.POS.API.Infra.Tables.User;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.App.Commands.Users.Handlers;

public class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new UserNotFoundException(request.Id);
        user.UpdatedAt = DateTime.UtcNow;
        user.Name = request.Name ?? user.Name;
        user.Email = request.Email ?? user.Email;

        var updatedUser = await userRepository.UpdateUserAsync(user, cancellationToken);
        return updatedUser.ToDto();
    }
}