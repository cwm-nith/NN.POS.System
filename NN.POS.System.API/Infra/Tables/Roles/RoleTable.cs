using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.System.API.Infra.Tables.Roles;

public class RoleTable : BaseTable
{
    [Column("name")]
    public string Name { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public RoleTable(string name, DateTime updatedAt)
    {
        Name = name;
        UpdatedAt = updatedAt;
    }
}