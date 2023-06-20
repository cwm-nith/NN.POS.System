using NN.POS.System.Core.Dtos.Users;
using NN.POS.System.Core.Entities.Users;

namespace NN.POS.System.Infrastructure.Tables.User;

public static class UserExtensions
{
    public static UserDto ToDto(this UserEntity t, string? token = null) =>
        new(
            id: t.Id,
            name: t.Name,
            username: t.Username,
            email: t.Email,
            lastLogin: t.LastLogin,
            createdAt: t.CreatedAt,
            updatedAt: t.UpdatedAt
        )
        {
            Token = token
        };

    public static UserEntity ToEntity(this UserTable t, string? token = null) =>
        new(
            id: t.Id,
            name: t.Name,
            username: t.Username,
            email: t.Email,
            lastLogin: null,
            createdAt: t.CreatedAt,
            updatedAt: t.UpdatedAt
        )
        {
            Password = t.Password,
            Token = token
        };

    public static UserEntity ToEntity(this UserDto t, string? token = null) =>
        new(
            id: t.Id,
            name: t.Name,
            username: t.Username,
            email: t.Email,
            lastLogin: null,
            createdAt: t.CreatedAt,
            updatedAt: t.UpdatedAt
        )
        {
            Token = token
        };

    public static UserTable ToTable(this UserEntity t) =>
        new(
            id: t.Id,
            name: t.Name,
            username: t.Username,
            password: t.Password,
            email: t.Email,
            updatedAt: t.UpdatedAt
        );
}