using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.UnitOfMeasures;

[Table("unit_of_measures")]
public class UnitOfMeasureTable : BaseTable
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}