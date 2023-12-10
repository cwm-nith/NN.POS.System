using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Infra.Tables.UnitOfMeasures;

[Table("unit_of_measure_define")]
public class UnitOfMeasureDefineTable : BaseTable
{
    [Column("base_uom_id")]
    public int BaseUomId { get; set; }

    [Column("alt_uom_id")]
    public int AltUomId { get; set; }

    [Column("group_uom_id")]
    public int GroupUomId { get; set; }

    [Column("alt_qty")]
    public decimal AltQty { get; set; }

    [Column("base_qty")]
    public decimal BaseQty { get; set; }

    [Column("factor")]
    public decimal Factor { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at")] 
    public DateTime CreatedAt { get; set; }
}

public static class UnitOfMeasureDefineTableExtensions
{
    public static UnitOfMeasureDefineTable ToTable(this UnitOfMeasureDefineDto u) => new()
    {
        Id = u.Id,
        CreatedAt = u.CreatedAt,
        IsDeleted = u.IsDeleted,
        AltQty = u.AltQty,
        BaseQty = u.BaseQty,
        AltUomId = u.AltUomId,
        BaseUomId = u.BaseUomId,
        Factor = u.Factor,
        GroupUomId = u.GroupUomId
    };

    public static UnitOfMeasureDefineDto ToDto(this UnitOfMeasureDefineTable u) => new()
    {
        Id = u.Id,
        CreatedAt = u.CreatedAt,
        IsDeleted = u.IsDeleted,
        AltQty = u.AltQty,
        BaseQty = u.BaseQty,
        AltUomId = u.AltUomId,
        BaseUomId = u.BaseUomId,
        Factor = u.Factor,
        GroupUomId = u.GroupUomId
    };
}