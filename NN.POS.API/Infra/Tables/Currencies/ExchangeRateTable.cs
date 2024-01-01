using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.Tables.Currencies;

[Table("exchange_rates")]
public class ExchangeRateTable : BaseTable
{
    [Column("ccy_id")]
    public int CcyId { get; set; }

    [Column("rate", TypeName = "decimal(18,7)")]
    public decimal Rate { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("set_rate", TypeName = "decimal(18,7)")]
    public decimal SetRate { get; set; }
}

public static class ExchangeRateExtensions
{
    public static ExchangeRateDto ToDto(this ExchangeRateTable e, string? ccyName = null, string? baseCcy = null) => new()
    {
        CreatedAt = e.CreatedAt,
        CcyId = e.CcyId,
        Id = e.Id,
        IsDeleted = e.IsDeleted,
        Rate = e.Rate,
        SetRate = e.SetRate,
        CcyName = ccyName,
        BaseCcy = baseCcy
    };
    public static ExchangeRateTable ToTable(this ExchangeRateDto e) => new()
    {
        CreatedAt = e.CreatedAt,
        CcyId = e.CcyId,
        Id = e.Id,
        IsDeleted = e.IsDeleted,
        Rate = e.Rate,
        SetRate = e.SetRate
    };
}