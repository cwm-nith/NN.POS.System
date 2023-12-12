using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables;

public class BaseTable
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("created_at")] 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}