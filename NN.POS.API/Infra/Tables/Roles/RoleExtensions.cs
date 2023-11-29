using NN.POS.API.Core.Entities.Roles;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.Infra.Tables.Roles;

public static class RoleExtensions
{
    public static RoleDto ToDto(this RoleEntity t) =>
        new()
        {
            Id = t.Id,
            Name = t.Name,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt,
            Description = t.Description,
            DisplayName = t.DisplayName,
        };

    public static RoleEntity ToEntity(this RoleTable t) =>
        new()
        {
            Id = t.Id,
            Description = t.Description,
            DisplayName = t.DisplayName,
            Name = t.Name,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt
        };

    public static RoleEntity ToEntity(this RoleDto t) =>
        new()
        {
            Id = t.Id,
            Description = t.Description,
            DisplayName = t.DisplayName,
            Name = t.Name,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt
        };

    public static RoleTable ToTable(this RoleEntity t) =>
        new()
        {
            Description = t.Description,
            DisplayName = t.DisplayName,
            CreatedAt = t.CreatedAt,
            Id = t.Id,
            Name = t.Name,
            UpdatedAt = t.UpdatedAt
        };
}