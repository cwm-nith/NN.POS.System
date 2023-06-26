using System.ComponentModel.DataAnnotations;
using NN.POS.System.Model.Enums;

namespace NN.POS.System.Model.Dtos.BusinessPartners;

public class CreateBusinessPartnerDto : IBaseDto
{
    [Required(ErrorMessage = "FirstName field is required")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "LastName field is required")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "PhoneNumber field is required")]
    public string PhoneNumber { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? Address { get; set; }
    
    public BusinessPartnerEnum.ContactType ContactType { get; set; }

    public BusinessPartnerEnum.BusinessType BusinessType { get; set; }
}