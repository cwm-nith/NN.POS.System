using MediatR;
using NN.POS.System.API.Core.Entities.BusinessPartners;
using NN.POS.System.API.Core.IRepositories.BusinessPartners;
using NN.POS.System.API.Infra.Tables.BusinessPartners;
using NN.POS.System.Model.Dtos.BusinessPartners;

namespace NN.POS.System.API.App.Commands.BusinessPartners.Handlers;

public class UpdateBusinessPartnerCommandHandler(IBusinessPartnerRepository businessPartnerRepository) : IRequestHandler<UpdateBusinessPartnerCommand, BusinessPartnerDto>
{
    public async Task<BusinessPartnerDto> Handle(UpdateBusinessPartnerCommand r, CancellationToken cancellationToken)
    {
        var busEntity = await businessPartnerRepository.GetByIdAsync(r.Id, cancellationToken);

        BusinessPartnerEntity entity = new (
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
        await businessPartnerRepository.UpdateAsync(entity, cancellationToken);
        return entity.ToDto();
    }
}