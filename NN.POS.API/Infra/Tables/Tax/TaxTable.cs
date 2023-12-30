using NN.POS.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public DateTime EffectiveDate { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
}