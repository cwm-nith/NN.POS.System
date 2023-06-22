using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.System.API.Infra.Tables.Roles;

public class UserRole : BaseTable
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("role_id")]
    public Guid RoleId { get; set; }

    public UserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}