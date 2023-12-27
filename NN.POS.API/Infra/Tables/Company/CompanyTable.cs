using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NN.POS.API.Infra.Tables.Company;

[Table("company")]
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

    [StringLength(50), Column("location")]
    public string? Location { get; set; }

    [StringLength(220), Column("address")] 
    public string? Address { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; set; }

    [Column("logo"), StringLength(250)]
    public string? Logo { get; set; }
}