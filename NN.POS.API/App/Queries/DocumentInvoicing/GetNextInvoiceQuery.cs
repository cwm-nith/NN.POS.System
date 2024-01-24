using MediatR;
using NN.POS.Model.Dtos.DocumentInvoicings;
using NN.POS.Model.Enums;

namespace NN.POS.API.App.Queries.DocumentInvoicing;

public class GetNextInvoiceQuery : IRequest<DocumentInvoicingDto>
{
    public DocumentInvoicingType Type { get; set; }
}