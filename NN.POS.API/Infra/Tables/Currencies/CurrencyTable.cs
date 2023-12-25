using System.ComponentModel.DataAnnotations.Schema;

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