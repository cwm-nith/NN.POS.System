using MediatR;
using NN.POS.API.App.Queries.DocumentInvoicing;
using NN.POS.Model.Dtos.DocumentInvoicings;

namespace NN.POS.API.Infra.QueryHandlers.DocumentInvoicing;

public class GetNextInvoiceQueryHandler() : IRequestHandler<GetNextInvoiceQuery, DocumentInvoicingDto>
{
    public async Task<DocumentInvoicingDto> Handle(GetNextInvoiceQuery request, CancellationToken cancellationToken)
    {
        
    }
}