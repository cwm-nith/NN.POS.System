using NN.POS.API.App.Queries.DocumentInvoicing;
using NN.POS.API.Core.IRepositories.DocumentInvoicing;
using NN.POS.API.Infra.Tables.DocumentInvoicing;
using NN.POS.API.Infra.Tables;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.DocumentInvoicings;
using NN.POS.Model.Enums;
using NN.POS.API.Core.Exceptions.DocumentInvoicing;

namespace NN.POS.API.Infra.Repositories.DocumentInvoicing;

public class DocumentInvoicePrefixingRepository(
    IReadDbRepository<DocumentInvoicePrefixingTable> readDbRepository,
    IWriteDbRepository<DocumentInvoicePrefixingTable> writeDbRepository) : IDocumentInvoicePrefixingRepository
{
    public async Task<DocumentInvoicePrefixingDto> GetAsync(DocumentInvoicingType type, CancellationToken cancellationToken = default)
    {
        var prefix = await readDbRepository.FirstOrDefaultAsync(i => i.Type == type, cancellationToken) ?? throw new DocumentInvoicePrefixingNotFoundException();
        return prefix.ToDto();
    }

    public async Task<DocumentInvoicePrefixingDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var prefix = await readDbRepository.FirstOrDefaultAsync(id, cancellationToken) ?? throw new DocumentInvoicePrefixingNotFoundException();
        return prefix.ToDto();
    }

    public async Task<PagedResult<DocumentInvoicePrefixingDto>> GetPageAsync(GetDocumentInvoicePrefixingPageQuery q, CancellationToken cancellationToken = default)
    {
        var prefix = await readDbRepository.BrowseAsync(i => true, i => i.Prefix, q, cancellationToken);
        return prefix.Map(i => i.ToDto());
    }

    public async Task CreateAsync(DocumentInvoicePrefixingDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);
    }

    public async Task UpdateAsync(DocumentInvoicePrefixingDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.UpdateAsync(body.ToTable(), cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var prefix = await GetByIdAsync(id, cancellationToken);
        await writeDbRepository.DeleteAsync(prefix.Id, cancellationToken);
    }
}