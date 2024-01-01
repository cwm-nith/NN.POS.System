using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.PaymentTypes;

[Table("payment_types")]
public class PaymentTypeTable : BaseTable
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    [Column("is_deleted")] 
    public bool IsDeleted { get; set; }
}