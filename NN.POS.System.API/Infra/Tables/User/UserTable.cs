using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.System.API.Infra.Tables.User;

[Table("users")]
public class UserTable : BaseTable
{

    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("username")] 
    public string Username { get; set; } = string.Empty;

    [Column("password")] 
    public string Password { get; set; } = string.Empty;

    [Column("email")] 
    public string Email { get; set; } = string.Empty;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}