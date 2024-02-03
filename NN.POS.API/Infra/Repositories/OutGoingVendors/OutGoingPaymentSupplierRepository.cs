using NN.POS.API.Core.IRepositories.OutGoingVendors;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.OutGoingPayments;
using NN.POS.Model.Dtos.OutGoingPayments;

namespace NN.POS.API.Infra.Repositories.OutGoingVendors;

public class OutGoingPaymentSupplierRepository(
    IWriteDbRepository<OutGoingPaymentSupplierTable> writeDbRepository,
    IReadDbRepository<OutGoingPaymentSupplierTable> readDbRepository) : IOutGoingPaymentSupplierRepository
{
    public async Task CreateAsync(OutGoingPaymentSupplierDto dto, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(dto.ToTable(), cancellationToken);
    }
}
