using MediatR;
using NN.POS.API.App.Queries.BusinessPartners;
using NN.POS.API.Core.IRepositories.BusinessPartners;
using NN.POS.API.Infra.Tables.BusinessPartners;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.BusinessPartners;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.QueryHandlers.BusinessPartners;

public class GetBusinessPartnerQueryHandler(IBusinessPartnerRepository businessPartnerRepository) : IRequestHandler<GetBusinessPartnerQuery, PagedResult<BusinessPartnerDto>>
{
    public async Task<PagedResult<BusinessPartnerDto>> Handle(GetBusinessPartnerQuery r, CancellationToken cancellationToken)
    {
        var data = r.ContactType switch
        {
            BusinessPartnerEnum.ContactType.Customer => await businessPartnerRepository
                .GetAllAsync(i =>
                    (r.BusinessType == BusinessPartnerEnum.BusinessType.None || i.BusinessType == r.BusinessType) &&
                    (r.ContactType == BusinessPartnerEnum.ContactType.None
                     || i.ContactType == BusinessPartnerEnum.ContactType.Customer
                     || i.ContactType == BusinessPartnerEnum.ContactType.SupplierCustomer), new PagedQuery()
                {
                    Results = r.Results,
                    Page = r.Page
                }, cancellationToken),
            BusinessPartnerEnum.ContactType.Supplier => await businessPartnerRepository
                .GetAllAsync(i =>
                    (r.BusinessType == BusinessPartnerEnum.BusinessType.None || i.BusinessType == r.BusinessType) &&
                    (r.ContactType == BusinessPartnerEnum.ContactType.None
                     || i.ContactType == BusinessPartnerEnum.ContactType.Supplier
                     || i.ContactType == BusinessPartnerEnum.ContactType.SupplierCustomer), new PagedQuery()
                {
                    Results = r.Results,
                    Page = r.Page
                }, cancellationToken),
            _ => await businessPartnerRepository
                .GetAllAsync(i =>
                    (r.BusinessType == BusinessPartnerEnum.BusinessType.None || i.BusinessType == r.BusinessType) &&
                    (r.ContactType == BusinessPartnerEnum.ContactType.None || i.ContactType == r.ContactType), new PagedQuery()
                {
                    Results = r.Results,
                    Page = r.Page
                }, cancellationToken),
        };
        return data.Map(i => i.ToDto());
    }
}