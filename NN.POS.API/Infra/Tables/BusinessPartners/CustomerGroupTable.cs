using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.BusinessPartners;

[Table("customer_groups")]
public class CustomerGroupTable : BaseTable
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// value format is percentage %
    /// </summary>
    [Column("value", TypeName = "decimal(18,4)")]
    public decimal Value { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}