using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.DocumentInvoicings;
using NN.POS.Model.Enums;

namespace NN.POS.API.App.Queries.DocumentInvoicing;

public class GetDocumentInvoicePrefixingPageQuery : PagedQuery, IRequest<PagedResult<DocumentInvoicePrefixingDto>>
{
    public string? Search { get; set; }
    public DocumentInvoicingType Type { get; set; }
}