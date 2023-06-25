using MediatR;
using NN.POS.System.API.Core.Dtos.BusinessPartners;
using NN.POS.System.API.Core.Entities.BusinessPartners;
using NN.POS.System.API.Core.IRepositories.BusinessPartners;
using NN.POS.System.API.Infra.Tables.BusinessPartners;

namespace NN.POS.System.API.App.Commands.BusinessPartners.Handlers;

public class UpdateBusinessPartnerCommandHandler : IRequestHandler<UpdateBusinessPartnerCommand, BusinessPartnerDto>
{
    private readonly IBusinessPartnerRepository _businessPartnerRepository;

    public UpdateBusinessPartnerCommandHandler(IBusinessPartnerRepository businessPartnerRepository)
    {
        _businessPartnerRepository = businessPartnerRepository;
    }

    public async Task<BusinessPartnerDto> Handle(UpdateBusinessPartnerCommand r, CancellationToken cancellationToken)
    {
        var busEntity = await _businessPartnerRepository.GetByIdAsync(r.Id, cancellationToken);

        var entity = new BusinessPartnerEntity(
            id: r.Id,
            firstName: r.FirstName ?? busEntity.FirstName,
            lastName: r.LastName ?? busEntity.LastName,
            phoneNumber:r.PhoneNumber ?? busEntity.PhoneNumber,
            contactType: r.ContactType ?? busEntity.ContactType,
            businessType: r.BusinessType ?? busEntity.BusinessType,
            createdAt: busEntity.CreatedAt,
            updatedAt: DateTime.UtcNow
            )
        {
            Address = r.Address ?? busEntity.Address,
            Email = r.Email ?? busEntity.Email,
        };
        await _businessPartnerRepository.UpdateAsync(entity, cancellationToken);
        return entity.ToDto();
    }
}