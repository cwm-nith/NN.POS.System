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

        BusinessPartnerEntity entity = new ()
        {
            Address = r.Address ?? busEntity.Address,
            Email = r.Email ?? busEntity.Email,
            Id = r.Id,
            FirstName = r.FirstName ?? busEntity.FirstName,
            LastName = r.LastName ?? busEntity.LastName,
            PhoneNumber = r.PhoneNumber ?? busEntity.PhoneNumber,
            ContactType = r.ContactType ?? busEntity.ContactType,
            BusinessType = r.BusinessType ?? busEntity.BusinessType,
            CreatedAt = busEntity.CreatedAt,
            UpdatedAt = DateTime.UtcNow
        };
        await businessPartnerRepository.UpdateAsync(entity, cancellationToken);
        return entity.ToDto();
    }
}