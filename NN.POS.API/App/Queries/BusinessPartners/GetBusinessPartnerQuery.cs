using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.BusinessPartners;
using NN.POS.Model.Enums;

namespace NN.POS.API.App.Queries.BusinessPartners;

public class GetBusinessPartnerQuery : PagedQuery, IRequest<PagedResult<BusinessPartnerDto>>
{
    public BusinessPartnerEnum.BusinessType BusinessType { get; set; }
    public BusinessPartnerEnum.ContactType ContactType { get; set; }
}