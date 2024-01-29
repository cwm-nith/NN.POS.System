using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchasePO;
using NN.POS.Model.Enums;

namespace NN.POS.API.App.Queries.Purchases;

public class GetPurchasePOPageQuery : PagedQuery, IRequest<PagedResult<PurchasePODto>>
{
    public string? Search { get; set; }
    public PurchaseStatus? PurchaseStatus { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}
