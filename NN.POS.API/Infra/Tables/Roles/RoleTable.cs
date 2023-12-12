using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.Roles;

[Table("roles")]
public class RoleTable : BaseTable
{
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("display_name")]
    public string? DisplayName { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

}