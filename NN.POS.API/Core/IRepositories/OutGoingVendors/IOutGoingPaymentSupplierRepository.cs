using NN.POS.Model.Dtos.OutGoingPayments;

namespace NN.POS.API.Core.IRepositories.OutGoingVendors;

public interface IOutGoingPaymentSupplierRepository : IRepository
{
    Task CreateAsync(OutGoingPaymentSupplierDto dto, CancellationToken cancellationToken = default);
}
