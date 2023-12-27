using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.Company.Branches;

namespace NN.POS.API.Infra.Tables.Company;

[Table("branches")]
public class BranchTable : BaseTable
{
    [Column("name"), StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("location"), StringLength(200)]
    public string Location { get; set; } = string.Empty;

    [Column("address"), StringLength(200)] 
    public string Address { get; set; } = string.Empty;

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }
}

public static class BranchExtensions
{
    public static BranchDto ToDto(this BranchTable b, string? comName = null) => new()
    {
        Address = b.Address,
        CompanyId = b.CompanyId,
        CompanyName = comName,
        CreatedAt = b.CreatedAt,
        Id = b.Id,
        IsDeleted = b.IsDeleted,
        Location = b.Location,
        Name = b.Name
    };

    public static BranchTable ToDto(this BranchDto b) => new()
    {
        Address = b.Address,
        CompanyId = b.CompanyId,
        CreatedAt = b.CreatedAt,
        Id = b.Id,
        IsDeleted = b.IsDeleted,
        Location = b.Location,
        Name = b.Name
    };
}