using MediatR;
using Microsoft.AspNetCore.Identity;
using NN.POS.System.API.Core.Entities.Users;
using NN.POS.System.API.Core.IRepositories.Users;
using NN.POS.System.API.Infra.Tables.User;
using NN.POS.System.Model.Dtos.Users;

namespace NN.POS.System.API.App.Commands.Users.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<UserEntity> _passwordHasher;

    public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher<UserEntity> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    public async Task<UserDto> Handle(CreateUserCommand r, CancellationToken cancellationToken)
    {
        var entity = new UserEntity(name: r.Name, username: r.Username, email: r.Email, lastLogin: null,
            createdAt: DateTime.UtcNow, updatedAt: DateTime.UtcNow);
        entity.SetPassword(r.Password, _passwordHasher);
        var user = await _userRepository.CreateUserAsync(entity);
        return user.ToDto();
    }
}