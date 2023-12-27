using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.API.Infra.Tables.Company;

[Table("companies")]
public class CompanyTable : BaseTable
{
    [Column("name"), StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Column("price_list_id")]
    public int PriceListId { get; set; }

    [Column("sys_ccy_id")]
    public int SysCcyId { get; set; }

    [Column("local_ccy_id")]
    public int LocalCcyId { get; set; }

    [StringLength(200), Column("location")]
    public string? Location { get; set; }

    [StringLength(220), Column("address")]
    public string? Address { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("logo"), StringLength(250)]
    public string? Logo { get; set; }
}

public static class CompanyExtensions
{
    public static CompanyDto ToDto(
        this CompanyTable c,
        string? localCcyName = null,
        string? priceListName = null,
        string? sysCcyName = null) => new()
        {
            Address = c.Address,
            CreatedAt = c.CreatedAt,
            Id = c.Id,
            IsDeleted = c.IsDeleted,
            LocalCcyId = c.LocalCcyId,
            LocalCcyName = localCcyName,
            Location = c.Location,
            Logo = c.Logo,
            Name = c.Name,
            PriceListId = c.PriceListId,
            PriceListName = priceListName,
            SysCcyId = c.SysCcyId,
            SysCcyName = sysCcyName
        };

    public static CompanyTable ToTable(this CompanyDto c) => new()
    {
        Address = c.Address,
        CreatedAt = c.CreatedAt,
        Id = c.Id,
        IsDeleted = c.IsDeleted,
        LocalCcyId = c.LocalCcyId,
        Location = c.Location,
        Logo = c.Logo,
        Name = c.Name,
        PriceListId = c.PriceListId,
        SysCcyId = c.SysCcyId
    };
}