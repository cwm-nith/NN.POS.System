using NN.POS.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.Tax;

namespace NN.POS.API.Infra.Tables.Tax;

[Table("tax")]
public class TaxTable : BaseTable
{
    [Column("name"), StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Column("rate", TypeName = "decimal(18,2)")]
    public decimal Rate { get; set; }

    [Column("type")]
    public TaxType Type { get; set; }

    [Column("effective_date")]
    public DateTime? EffectiveDate { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
}

public static class TaxExtensions
{
    public static TaxDto ToDto(this TaxTable t) => new()
    {
        Name = t.Name,
        CreatedAt = t.CreatedAt,
        EffectiveDate = t.EffectiveDate,
        Id = t.Id,
        IsDeleted = t.IsDeleted,
        Type = t.Type,
        Rate = t.Rate
    };

    public static TaxTable ToTable(this TaxDto t) => new()
    {
        Name = t.Name,
        CreatedAt = t.CreatedAt,
        EffectiveDate = t.EffectiveDate,
        Id = t.Id,
        IsDeleted = t.IsDeleted,
        Type = t.Type,
        Rate = t.Rate
    };
}