using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.User;

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

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("last_login")]
    public DateTime? LastLogin { get; set; }
}