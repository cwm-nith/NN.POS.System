using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.System.Model.Enums;

namespace NN.POS.System.API.Infra.Tables.BusinessPartners;

[Table("business_partners")]
public class BusinessPartnerTable : BaseTable
{
    [Column("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [Column("last_name")] 
    public string LastName { get; set; } = string.Empty;

    [Column("phone_number")] 
    public string PhoneNumber { get; set; } = string.Empty;

    [Column("email")]
    public string? Email { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("contact_type")]
    public BusinessPartnerEnum.ContactType ContactType { get; set; }

    [Column("business_type")] 
    public BusinessPartnerEnum.BusinessType BusinessType { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}