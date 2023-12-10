using NN.POS.Model.Dtos.UnitOfMeasures;
using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.UnitOfMeasures;

[Table("unit_of_measure_group")]
public class UnitOfMeasureGroupTable : BaseTable
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}

public static class UnitOfMeasureGroupTableExtensions
{
    public static UnitOfMeasureGroupDto ToDto(this UnitOfMeasureGroupTable u) => new()
    {
        CreatedAt = u.CreatedAt,
        Id = u.Id,
        IsDeleted = u.IsDeleted,
        Name = u.Name
    };
    public static UnitOfMeasureGroupTable ToTable(this UnitOfMeasureGroupDto u) => new()
    {
        CreatedAt = u.CreatedAt,
        Id = u.Id,
        IsDeleted = u.IsDeleted,
        Name = u.Name
    };
}