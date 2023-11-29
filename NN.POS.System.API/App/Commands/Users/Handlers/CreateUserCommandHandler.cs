﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using NN.POS.System.API.Core.Entities.Users;
using NN.POS.System.API.Core.IRepositories.Users;
using NN.POS.System.API.Infra.Tables.User;
using NN.POS.System.Model.Dtos.Users;

namespace NN.POS.System.API.App.Commands.Users.Handlers;

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