using System.ComponentModel.DataAnnotations.Schema;
using NN.POS.System.Model.Enums;

namespace NN.POS.System.API.Infra.Tables.BusinessPartners;

[Table("business_partners")]
public class BusinessPartnerTable : BaseTable
{
    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("last_name")]
    public string LastName { get; set; }

    [Column("phone_number")]
    public string PhoneNumber { get; set; }

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

    public BusinessPartnerTable(int id, string firstName, string lastName, string phoneNumber,
        BusinessPartnerEnum.ContactType contactType, BusinessPartnerEnum.BusinessType businessType, DateTime updatedAt)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        ContactType = contactType;
        BusinessType = businessType;
        UpdatedAt = updatedAt;
    }
}