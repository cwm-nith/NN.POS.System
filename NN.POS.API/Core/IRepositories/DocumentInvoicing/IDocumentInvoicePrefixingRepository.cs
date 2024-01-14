using NN.POS.API.App.Queries.DocumentInvoicing;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.DocumentInvoicings;
using NN.POS.Model.Enums;

namespace NN.POS.API.Core.IRepositories.DocumentInvoicing;

public interface IDocumentInvoicePrefixingRepository : IRepository
{
    Task<DocumentInvoicePrefixingDto> GetAsync(DocumentInvoicingType type,
        CancellationToken cancellationToken = default);

    Task<DocumentInvoicePrefixingDto> GetByIdAsync(int id,
        CancellationToken cancellationToken = default);

    Task<PagedResult<DocumentInvoicePrefixingDto>> GetPageAsync(GetDocumentInvoicePrefixingPageQuery q,
        CancellationToken cancellationToken = default);

    Task CreateAsync(DocumentInvoicePrefixingDto body, CancellationToken cancellationToken = default);
    Task UpdateAsync(DocumentInvoicePrefixingDto body, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}