using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.Tables.Currencies;

[Table("currencies")]
public class CurrencyTable : BaseTable
{
    [Column("symbol"), StringLength(10)]
    public string Symbol { get; set; } = string.Empty;

    [Column("name"), StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
}

public static class CurrencyTableExtensions
{
    public static CurrencyDto ToDto(this CurrencyTable c, ExchangeRateTable? exchangeRate = null) => new()
    {
        CreatedAt = c.CreatedAt,
        Id = c.Id,
        IsDeleted = c.IsDeleted,
        Name = c.Name,
        Symbol = c.Symbol,
        ExchangeRate = exchangeRate?.ToDto()
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