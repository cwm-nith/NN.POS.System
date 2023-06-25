using NN.POS.System.API.Core.Enums;

namespace NN.POS.System.API.Core.Dtos.BusinessPartners;

public class UpdateBusinessPartnerDto : IBaseDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }
    
    public string? Email { get; set; }

    public string? Address { get; set; }

    public BusinessPartnerEnum.ContactType? ContactType { get; set; }

    public BusinessPartnerEnum.BusinessType? BusinessType { get; set; }
}