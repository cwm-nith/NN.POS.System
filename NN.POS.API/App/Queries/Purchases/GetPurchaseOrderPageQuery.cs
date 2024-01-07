using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;
using NN.POS.Model.Enums;

namespace NN.POS.API.App.Queries.Purchases;

public class GetPurchaseOrderPageQuery : PagedQuery, IRequest<PagedResult<PurchaseOrderDto>>
{
    public string? Search { get; set; }
    public PurchaseStatus? PurchaseStatus { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}