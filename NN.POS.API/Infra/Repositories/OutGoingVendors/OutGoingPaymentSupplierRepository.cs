using NN.POS.API.Core.IRepositories.OutGoingVendors;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.OutGoingPayments;
using NN.POS.Model.Dtos.OutGoingPayments;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.Repositories.OutGoingVendors;

public class OutGoingPaymentSupplierRepository(
    IWriteDbRepository<OutGoingPaymentSupplierTable> writeDbRepository,
    IReadDbRepository<OutGoingPaymentSupplierTable> readDbRepository) : IOutGoingPaymentSupplierRepository
{
    public async Task CreateAsync(OutGoingPaymentSupplierDto dto, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(dto.ToTable(), cancellationToken);
    }

    public async Task<OutGoingPaymentSupplierDto?> GetAsync(string invoice, DocumentInvoicingType type, CancellationToken cancellationToken = default)
    {
        var data = await readDbRepository.FirstOrDefaultAsync(i => i.InvoiceNo == invoice && i.DocumentType == type, cancellationToken);
        return data?.ToDto();
    }
}
