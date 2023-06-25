using MediatR;
using NN.POS.System.API.App.Queries.BusinessPartners;
using NN.POS.System.API.Core.IRepositories.BusinessPartners;

namespace NN.POS.System.API.Infra.QueryHandlers.BusinessPartners;

public class GetBusinessPartnerCountQueryHandler : IRequestHandler<GetBusinessPartnerCountQuery, int>
{
    private readonly IBusinessPartnerRepository _businessPartnerRepository;

    public GetBusinessPartnerCountQueryHandler(IBusinessPartnerRepository businessPartnerRepository)
    {
        _businessPartnerRepository = businessPartnerRepository;
    }

    public Task<int> Handle(GetBusinessPartnerCountQuery request, CancellationToken cancellationToken)
    {
        return _businessPartnerRepository.GetCountAsync(cancellationToken);
    }
}