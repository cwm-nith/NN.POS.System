using NN.POS.API.Core.Entities.Users;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.Infra.Tables.User;

public static class UserExtensions
{
    public static UserDto ToDto(this UserEntity t, string? token = null) =>
        new()
        {
            Token = t.Token ?? token,
            Id = t.Id,
            Name = t.Name,
            Username = t.Username,
            Email = t.Email,
            LastLogin = t.LastLogin,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt
        };

    public static UserEntity ToEntity(this UserTable t, string? token = null) =>
        new()
        {
            Name = t.Name,
            Username = t.Username,
            Email = t.Email,
            LastLogin = null,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            Id = t.Id,
            Password = t.Password,
            Token = token
        };

    public static UserEntity ToEntity(this UserDto t, string? token = null) =>
        new()
        {
            Id = t.Id,
            Token = t.Token ?? token,
            Name = t.Name,
            Username = t.Username,
            Email = t.Email,
            LastLogin = null,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt
        };

    public static UserTable ToTable(this UserEntity t) =>
        new()
        {
            Id = t.Id,
            Name = t.Name,
            Username = t.Username,
            Password = t.Password,
            Email = t.Email,
            UpdatedAt = t.UpdatedAt,
            CreatedAt = t.CreatedAt
        };
}