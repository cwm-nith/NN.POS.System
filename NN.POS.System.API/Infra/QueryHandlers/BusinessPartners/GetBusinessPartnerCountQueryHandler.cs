using MediatR;
using NN.POS.System.API.App.Queries.BusinessPartners;
using NN.POS.System.API.Core.IRepositories.BusinessPartners;

namespace NN.POS.System.API.Infra.QueryHandlers.BusinessPartners;

public class GetBusinessPartnerCountQueryHandler(IBusinessPartnerRepository businessPartnerRepository) : IRequestHandler<GetBusinessPartnerCountQuery, int>
{
    public async Task<int> Handle(GetBusinessPartnerCountQuery request, CancellationToken cancellationToken)
    {
        return await businessPartnerRepository.GetCountAsync(cancellationToken);
    }
}