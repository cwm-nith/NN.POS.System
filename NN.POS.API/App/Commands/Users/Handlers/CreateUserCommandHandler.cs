using MediatR;
using Microsoft.AspNetCore.Identity;
using NN.POS.API.Core.Entities.Users;
using NN.POS.API.Core.IRepositories.Users;
using NN.POS.API.Infra.Tables.User;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.App.Commands.Users.Handlers;

public class CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher<UserEntity> passwordHasher) : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand r, CancellationToken cancellationToken)
    {
        var entity = new UserEntity
        {
            Name = r.Name,
            Username = r.Username,
            Email = r.Email,
            LastLogin = null,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        entity.SetPassword(r.Password, passwordHasher);
        var user = await userRepository.CreateUserAsync(entity, cancellationToken);
        return user.ToDto();
    }
}