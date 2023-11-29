using MediatR;
using NN.POS.System.API.Core.IRepositories.Users;
using NN.POS.System.API.Infra.Tables.User;
using Microsoft.AspNetCore.Identity;
using NN.POS.System.API.Core.Entities.Users;
using NN.POS.System.API.Core.Exceptions.Users;
using NN.POS.System.Model.Dtos.Users;

namespace NN.POS.System.API.App.Commands.Users.Handlers;

public class LoginCommandHandler(IUserRepository userRepository, ITokenProvider tokenProvider,
    IPasswordHasher<UserEntity> passwordHasher) : IRequestHandler<LoginCommand, UserDto>
{
    public async Task<UserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUserNameAsync(request.Username, cancellationToken) ?? throw new InvalidCredentialException();
        if (!user.ValidatePassword(request.Password, passwordHasher)) throw new InvalidCredentialException();
        
        var token = await tokenProvider.CreateTokenAsync(user, cancellationToken);
        return user.ToDto(token);
    }
}