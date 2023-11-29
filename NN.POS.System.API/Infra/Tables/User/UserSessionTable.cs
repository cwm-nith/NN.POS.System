using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.System.API.Infra.Tables.User;

public class UserSessionTable : BaseTable
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("last_login")]
    public DateTime LastLogin { get; set; }
}