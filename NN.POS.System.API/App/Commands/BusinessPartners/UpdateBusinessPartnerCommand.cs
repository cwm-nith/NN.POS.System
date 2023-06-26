using MediatR;
using NN.POS.System.Model.Dtos.BusinessPartners;
using NN.POS.System.Model.Enums;

namespace NN.POS.System.API.App.Commands.BusinessPartners;

public class UpdateBusinessPartnerCommand : IRequest<BusinessPartnerDto>
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