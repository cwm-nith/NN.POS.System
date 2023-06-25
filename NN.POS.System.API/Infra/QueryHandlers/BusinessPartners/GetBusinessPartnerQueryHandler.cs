using MediatR;
using NN.POS.System.API.App.Queries.BusinessPartners;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Dtos.BusinessPartners;
using NN.POS.System.API.Core.Enums;
using NN.POS.System.API.Core.IRepositories.BusinessPartners;
using NN.POS.System.API.Infra.Tables.BusinessPartners;

namespace NN.POS.System.API.Infra.QueryHandlers.BusinessPartners;

public class GetBusinessPartnerQueryHandler : IRequestHandler<GetBusinessPartnerQuery, PagedResult<BusinessPartnerDto>>
{
    private readonly IBusinessPartnerRepository _businessPartnerRepository;

    public GetBusinessPartnerQueryHandler(IBusinessPartnerRepository businessPartnerRepository)
    {
        _businessPartnerRepository = businessPartnerRepository;
    }

    public async Task<PagedResult<BusinessPartnerDto>> Handle(GetBusinessPartnerQuery r, CancellationToken cancellationToken)
    {
        var data = await _businessPartnerRepository
            .GetAllAsync(i =>
                (r.BusinessType == BusinessPartnerEnum.BusinessType.None || i.BusinessType == r.BusinessType) &&
                             (r.ContactType == BusinessPartnerEnum.ContactType.None || i.ContactType == r.ContactType), new PagedQuery()
                             {
                                 Results = r.Results,
                                 Page = r.Page
                             }, cancellationToken);
        return data.Map(i => i.ToDto());
    }
}