using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;
using NN.POS.Model.Enums;

namespace NN.POS.API.App.Queries.Purchases;

public class GetPurchaseCreditMemoPageQuery : PagedQuery, IRequest<PagedResult<PurchaseCreditMemoDto>>
{
    public string? Search { get; set; }
    public PurchaseStatus? PurchaseStatus { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
}