using MediatR;
using NN.POS.API.App.Queries.BusinessPartners;
using NN.POS.API.Core.IRepositories.BusinessPartners;
using NN.POS.API.Infra.Tables.BusinessPartners;
using NN.POS.Model.Dtos.BusinessPartners;

namespace NN.POS.API.Infra.QueryHandlers.BusinessPartners;

public class GetBusinessPartnerByIdQueryHandler(IBusinessPartnerRepository businessPartnerRepository) : IRequestHandler<GetBusinessPartnerByIdQuery, BusinessPartnerDto>
{
    public async Task<BusinessPartnerDto> Handle(GetBusinessPartnerByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await businessPartnerRepository.GetByIdAsync(request.Id, cancellationToken);
        return data.ToDto();
    }
}