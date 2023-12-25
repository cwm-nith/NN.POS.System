using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.Tables.Currencies;

[Table("currencies")]
public class CurrencyTable : BaseTable
{
    [Column("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [Column("Name")]
    public string Name { get; set; } = string.Empty;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
}

public static class CurrencyTableExtensions
{
    public static CurrencyDto ToDto(this CurrencyTable c) => new()
    {
        CreatedAt = c.CreatedAt,
        Id = c.Id,
        IsDeleted = c.IsDeleted,
        Name = c.Name,
        Symbol = c.Symbol
    };

    public static CurrencyTable ToTable(this CurrencyDto c) => new()
    {
        CreatedAt = c.CreatedAt,
        Id = c.Id,
        IsDeleted = c.IsDeleted,
        Name = c.Name,
        Symbol = c.Symbol
    };
}