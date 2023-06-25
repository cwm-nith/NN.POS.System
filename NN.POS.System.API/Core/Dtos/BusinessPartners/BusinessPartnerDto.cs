using NN.POS.System.API.Core.Enums;

namespace NN.POS.System.API.Core.Dtos.BusinessPartners;

public class BusinessPartnerDto : IBaseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public BusinessPartnerEnum.ContactType ContactType { get; set; }

    public BusinessPartnerEnum.BusinessType BusinessType { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public BusinessPartnerDto(int id, string firstName, string lastName, string phoneNumber,
        BusinessPartnerEnum.ContactType contactType, BusinessPartnerEnum.BusinessType businessType, DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        ContactType = contactType;
        BusinessType = businessType;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}