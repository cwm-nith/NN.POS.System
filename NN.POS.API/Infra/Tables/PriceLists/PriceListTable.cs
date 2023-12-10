using System.ComponentModel.DataAnnotations.Schema;

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

    [Column("created_at")] 
    public DateTime CreatedAt { get; set; }
}