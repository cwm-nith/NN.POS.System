using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.PaymentTypes;

namespace NN.POS.API.Infra.Tables.PaymentTypes;

[Table("payment_types")]
public class PaymentTypeTable : BaseTable
{
    [Column("name"), StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [Column("is_deleted")] 
    public bool IsDeleted { get; set; }
}

public static class PaymentTypeExtensions
{
    public static PaymentTypeDto ToDto(this PaymentTypeTable p) => new()
    {
        CreatedAt = p.CreatedAt,
        Id = p.Id,
        IsDeleted = p.IsDeleted,
        Name = p.Name
    };

    public static PaymentTypeTable ToTable(this PaymentTypeDto p) => new()
    {
        CreatedAt = p.CreatedAt,
        Id = p.Id,
        IsDeleted = p.IsDeleted,
        Name = p.Name
    };
}