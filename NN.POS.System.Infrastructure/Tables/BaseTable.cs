using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.System.Infrastructure.Tables;

public class BaseTable
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
}