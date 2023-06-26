using MediatR;
using NN.POS.System.Common.Pagination;
using NN.POS.System.Model.Dtos.BusinessPartners;
using NN.POS.System.Model.Enums;

namespace NN.POS.System.API.App.Queries.BusinessPartners;

public class GetBusinessPartnerQuery : PagedQuery, IRequest<PagedResult<BusinessPartnerDto>>
{
    public BusinessPartnerEnum.BusinessType BusinessType { get; set; }
    public BusinessPartnerEnum.ContactType ContactType { get; set; }
}