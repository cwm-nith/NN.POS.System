using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.System.API.Infra.Tables.Roles;

[Table("roles")]
public class RoleTable : BaseTable
{
    [Column("name")]
    public string Name { get; set; }

    [Column("display_name")]
    public string? DisplayName { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public RoleTable(int id, string name, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        UpdatedAt = updatedAt;
    }
}