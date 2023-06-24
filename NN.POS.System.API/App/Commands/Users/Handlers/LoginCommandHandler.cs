using MediatR;
using NN.POS.System.API.Core.Dtos.Users;
using NN.POS.System.API.Core.IRepositories.Users;
using NN.POS.System.API.Infra.Tables.User;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using NN.POS.System.API.Core.Entities.Users;
using NN.POS.System.API.Core.Exceptions.Users;
using NN.POS.System.API.Core.IRepositories.Roles;
using System.Collections.Generic;

namespace NN.POS.System.API.App.Commands.Users.Handlers;

public class LoginCommandHandler : IRequestHandler<LoginCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenProvider _tokenProvider;
    private readonly IPasswordHasher<UserEntity> _passwordHasher;

    public LoginCommandHandler(IUserRepository userRepository, ITokenProvider tokenProvider,
        IPasswordHasher<UserEntity> passwordHasher)
    {
        _userRepository = userRepository;
        _tokenProvider = tokenProvider;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUserNameAsync(request.Username, cancellationToken) ?? throw new InvalidCredentialException();
        if (!user.ValidatePassword(request.Password, _passwordHasher)) throw new InvalidCredentialException();
        
        var token = await _tokenProvider.CreateTokenAsync(user, cancellationToken);
        return user.ToDto(token);
    }
}