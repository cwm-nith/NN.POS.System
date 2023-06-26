using NN.POS.System.API.Core.Entities.Users;
using NN.POS.System.Model.Dtos.Users;

namespace NN.POS.System.API.Infra.Tables.User;

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
            Token = t.Token ?? token
        };

    public static UserEntity ToEntity(this UserTable t, string? token = null) =>
        new(
            name: t.Name,
            username: t.Username,
            email: t.Email,
            lastLogin: null,
            createdAt: t.CreatedAt,
            updatedAt: t.UpdatedAt
        )
        {

            Id = t.Id,
            Password = t.Password,
            Token = token
        };

    public static UserEntity ToEntity(this UserDto t, string? token = null) =>
        new(
            name: t.Name,
            username: t.Username,
            email: t.Email,
            lastLogin: null,
            createdAt: t.CreatedAt,
            updatedAt: t.UpdatedAt
        )
        {
            Id = t.Id,
            Token = t.Token ?? token
        };

    public static UserTable ToTable(this UserEntity t) =>
        new(
            id: t.Id,
            name: t.Name,
            username: t.Username,
            password: t.Password,
            email: t.Email,
            updatedAt: t.UpdatedAt
        )
        {
            CreatedAt = t.CreatedAt,
        };
}