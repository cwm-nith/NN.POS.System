using MediatR;
using Microsoft.AspNetCore.Identity;
using NN.POS.API.Core.Entities.Users;
using NN.POS.API.Core.Exceptions.Users;
using NN.POS.API.Core.IRepositories.Users;
using NN.POS.API.Infra.Tables.User;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.App.Commands.Users.Handlers;

public class LoginCommandHandler(IUserRepository userRepository, ITokenProvider tokenProvider,
    IPasswordHasher<UserEntity> passwordHasher) : IRequestHandler<LoginCommand, UserDto>
{
    public async Task<UserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUserNameAsync(request.Username, cancellationToken) ?? throw new InvalidCredentialException();
        if (!user.ValidatePassword(request.Password, passwordHasher)) throw new InvalidCredentialException();
        
        var token = await tokenProvider.CreateTokenAsync(user, cancellationToken);

        user.LastLogin = DateTime.UtcNow;

        await userRepository.UpdateUserAsync(user, cancellationToken).ConfigureAwait(false);

        return user.ToDto(token);
    }
}