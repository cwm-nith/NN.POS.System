using MediatR;
using NN.POS.System.API.Core.Entities.BusinessPartners;
using NN.POS.System.API.Core.IRepositories.BusinessPartners;
using NN.POS.System.API.Infra.Tables.BusinessPartners;
using NN.POS.System.Model.Dtos.BusinessPartners;

namespace NN.POS.System.API.App.Commands.BusinessPartners.Handlers;

public class CreateBusinessPartnerCommandHandler(IBusinessPartnerRepository businessPartnerRepository) : IRequestHandler<CreateBusinessPartnerCommand, BusinessPartnerDto>
{
    public async Task<BusinessPartnerDto> Handle(CreateBusinessPartnerCommand r, CancellationToken cancellationToken)
    {
        var entity = new BusinessPartnerEntity
        {
            Email = r.Email,
            Address = r.Address,
            BusinessType = r.BusinessType,
            ContactType = r.ContactType,
            CreatedAt = DateTime.UtcNow,
            FirstName = r.FirstName,
            LastName = r.LastName,
            Id = 0,
            PhoneNumber = r.PhoneNumber,
            UpdatedAt = DateTime.UtcNow
        };
        var data = await businessPartnerRepository.CreateAsync(entity, cancellationToken);
        return data.ToDto();
    }
}