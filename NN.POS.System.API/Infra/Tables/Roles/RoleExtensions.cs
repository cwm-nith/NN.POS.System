using NN.POS.System.API.Core.Entities.Roles;
using NN.POS.System.Model.Dtos.Roles;

namespace NN.POS.System.API.Infra.Tables.Roles;

public static class RoleExtensions
{
    public static RoleDto ToDto(this RoleEntity t) =>
        new(
            id: t.Id,
            name: t.Name,
            createdAt: t.CreatedAt,
            updatedAt: t.UpdatedAt
        )
        {
            Description = t.Description,
            DisplayName = t.DisplayName,
        };

    public static RoleEntity ToEntity(this RoleTable t) =>
        new(
            name: t.Name,
            createdAt: t.CreatedAt,
            updatedAt: t.UpdatedAt
        )
        {
            Id = t.Id,
            Description = t.Description,
            DisplayName = t.DisplayName,
        };

    public static RoleEntity ToEntity(this RoleDto t) =>
        new(
            name: t.Name,
            createdAt: t.CreatedAt,
            updatedAt: t.UpdatedAt
        )
        {
            Id = t.Id,
            Description = t.Description,
            DisplayName = t.DisplayName,
        };

    public static RoleTable ToTable(this RoleEntity t) =>
        new(
            id: t.Id,
            name: t.Name,
            updatedAt: t.UpdatedAt
        )
        {
            Description = t.Description,
            DisplayName = t.DisplayName,
            CreatedAt = t.CreatedAt,
        };
}