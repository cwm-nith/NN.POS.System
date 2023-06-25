using MediatR;
using NN.POS.System.API.Core.Dtos.BusinessPartners;
using NN.POS.System.API.Core.Entities.BusinessPartners;
using NN.POS.System.API.Core.IRepositories.BusinessPartners;
using NN.POS.System.API.Infra.Tables.BusinessPartners;

namespace NN.POS.System.API.App.Commands.BusinessPartners.Handlers;

public class CreateBusinessPartnerCommandHandler : IRequestHandler<CreateBusinessPartnerCommand, BusinessPartnerDto>
{
    private readonly IBusinessPartnerRepository _businessPartnerRepository;

    public CreateBusinessPartnerCommandHandler(IBusinessPartnerRepository businessPartnerRepository)
    {
        _businessPartnerRepository = businessPartnerRepository;
    }

    public async Task<BusinessPartnerDto> Handle(CreateBusinessPartnerCommand r, CancellationToken cancellationToken)
    {
        var entity = new BusinessPartnerEntity(id: 0, firstName: r.FirstName, lastName: r.LastName,
            phoneNumber: r.PhoneNumber, contactType: r.ContactType, businessType: r.BusinessType, DateTime.UtcNow,
            DateTime.UtcNow)
        {
            Email = r.Email,
            Address = r.Address,
        };
        var data = await _businessPartnerRepository.CreateAsync(entity, cancellationToken);
        return data.ToDto();
    }
}