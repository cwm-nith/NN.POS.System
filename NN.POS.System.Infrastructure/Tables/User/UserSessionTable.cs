using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.System.Infrastructure.Tables.User;

public class UserSessionTable : BaseTable
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("last_login")]
    public DateTime LastLogin { get; set; }

    public UserSessionTable(Guid userId, DateTime lastLogin)
    {
        UserId = userId;
        LastLogin = lastLogin;
    }
}