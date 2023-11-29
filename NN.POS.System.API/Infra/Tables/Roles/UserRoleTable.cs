using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.System.API.Infra.Tables.Roles;

[Table("user_roles")]
public class UserRoleTable : BaseTable
{
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }
}