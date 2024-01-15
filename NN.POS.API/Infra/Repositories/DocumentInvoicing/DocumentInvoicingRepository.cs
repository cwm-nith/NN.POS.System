using NN.POS.API.App.Queries.DocumentInvoicing;
using NN.POS.API.Core.IRepositories.DocumentInvoicing;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.DocumentInvoicing;
using NN.POS.Model.Dtos.DocumentInvoicings;

namespace NN.POS.API.Infra.Repositories.DocumentInvoicing;

public class DocumentInvoicingRepository(
    IReadDbRepository<DocumentInvoicingTable> readDbRepository,
    IWriteDbRepository<DocumentInvoicingTable> writeDbRepository,
    IDocumentInvoicePrefixingRepository documentInvoicePrefixingRepository) : IDocumentInvoicingRepository
{
    public async Task<DocumentInvoicingDto> GetNextInvoiceAsync(GetNextInvoiceQuery q, CancellationToken cancellationToken = default)
    {
        var docCount = await readDbRepository.CountAsync(i => i.Type == q.Type, cancellationToken);
        var prefix = await documentInvoicePrefixingRepository.GetAsync(q.Type, cancellationToken);
        var docCountStr = docCount > 0 ? docCount.ToString() : "1";
        var padding = 8 - docCountStr.Length;

        return new DocumentInvoicingDto
        {
            CreatedAt = DateTime.UtcNow,
            DocId = 0,
            DocInvoicing = $"{prefix.Prefix}-{docCountStr.PadLeft(padding, '0')}",
            PreFix = prefix.Prefix,
            Id = 0,
            Type = q.Type,
            InvoiceCount = docCount
        };
    }

    public async Task CreateAsync(DocumentInvoicingDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);
    }
}