using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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