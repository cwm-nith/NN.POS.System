using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.Infra.Tables.PriceLists;

[Table("price_lists")]
public class PriceListTable : BaseTable
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("ccy_id")]
    public int CcyId { get; set; }

    public List<PriceListDetailTable> PriceListDetails { get; set; } = new();
}

public static class PriceListTableExtensions
{
    public static PriceListTable ToTable(this PriceListDto p) => new()
    {
        Id = p.Id,
        CcyId = p.CcyId,
        CreatedAt = p.CreatedAt,
        Name = p.Name,
        IsDeleted = p.IsDeleted,
        PriceListDetails = p.PriceListDetails.Select(i => i.ToTable()).ToList()
    };

    public static PriceListDto ToDto(this PriceListTable p) => new()
    {
        Id = p.Id,
        CcyId = p.CcyId,
        CreatedAt = p.CreatedAt,
        Name = p.Name,
        IsDeleted = p.IsDeleted,
        PriceListDetails = p.PriceListDetails.Select(i => i.ToDto()).ToList()
    };
}