using MediatR;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Dtos.BusinessPartners;
using NN.POS.System.API.Core.Enums;

namespace NN.POS.System.API.App.Queries.BusinessPartners;

public class GetBusinessPartnerQuery : PagedQuery, IRequest<PagedResult<BusinessPartnerDto>>
{
    public BusinessPartnerEnum.BusinessType BusinessType { get; set; }
    public BusinessPartnerEnum.ContactType ContactType { get; set; }
}