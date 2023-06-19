using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.System.Infrastructure.Tables.User;

public class UserTable : BaseTable
{

    [Column("name")]
    public string Name { get; set; }
}