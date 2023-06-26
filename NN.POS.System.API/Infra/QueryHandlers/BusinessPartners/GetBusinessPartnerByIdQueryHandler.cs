using MediatR;
using NN.POS.System.API.App.Queries.BusinessPartners;
using NN.POS.System.API.Core.IRepositories.BusinessPartners;
using NN.POS.System.API.Infra.Tables.BusinessPartners;
using NN.POS.System.Model.Dtos.BusinessPartners;

namespace NN.POS.System.API.Infra.QueryHandlers.BusinessPartners;

public class GetBusinessPartnerByIdQueryHandler : IRequestHandler<GetBusinessPartnerByIdQuery, BusinessPartnerDto>
{
    private readonly IBusinessPartnerRepository _businessPartnerRepository;

    public GetBusinessPartnerByIdQueryHandler(IBusinessPartnerRepository businessPartnerRepository)
    {
        _businessPartnerRepository = businessPartnerRepository;
    }

    public async Task<BusinessPartnerDto> Handle(GetBusinessPartnerByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _businessPartnerRepository.GetByIdAsync(request.Id, cancellationToken);
        return data.ToDto();
    }
}