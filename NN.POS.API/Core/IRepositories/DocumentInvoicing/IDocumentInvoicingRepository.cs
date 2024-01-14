using NN.POS.API.App.Queries.DocumentInvoicing;
using NN.POS.Model.Dtos.DocumentInvoicings;

namespace NN.POS.API.Core.IRepositories.DocumentInvoicing;

public interface IDocumentInvoicingRepository : IRepository
{
    Task<DocumentInvoicingDto> GetNextInvoiceAsync(GetNextInvoiceQuery q, CancellationToken cancellationToken = default);
    Task CreateAsync(DocumentInvoicingDto body, CancellationToken cancellationToken = default);
}