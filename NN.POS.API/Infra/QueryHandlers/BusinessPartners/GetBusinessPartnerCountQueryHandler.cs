using MediatR;
using NN.POS.API.App.Queries.BusinessPartners;
using NN.POS.API.Core.IRepositories.BusinessPartners;

namespace NN.POS.API.Infra.QueryHandlers.BusinessPartners;

public class GetBusinessPartnerCountQueryHandler(IBusinessPartnerRepository businessPartnerRepository) : IRequestHandler<GetBusinessPartnerCountQuery, int>
{
    public async Task<int> Handle(GetBusinessPartnerCountQuery request, CancellationToken cancellationToken)
    {
        return await businessPartnerRepository.GetCountAsync(cancellationToken);
    }
}