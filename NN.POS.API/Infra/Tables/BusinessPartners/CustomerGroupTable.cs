using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.BusinessPartners;

[Table("customer_group")]
public class CustomerGroupTable : BaseTable
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// value format is percentage %
    /// </summary>
    [Column("value")]
    public decimal Value { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}