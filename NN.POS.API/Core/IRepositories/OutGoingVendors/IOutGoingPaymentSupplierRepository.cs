using NN.POS.Model.Dtos.OutGoingPayments;
using NN.POS.Model.Enums;

namespace NN.POS.API.Core.IRepositories.OutGoingVendors;

public interface IOutGoingPaymentSupplierRepository : IRepository
{
    Task CreateAsync(OutGoingPaymentSupplierDto dto, CancellationToken cancellationToken = default);
    Task<OutGoingPaymentSupplierDto?> GetAsync(string invoice, DocumentInvoicingType type, CancellationToken cancellationToken = default);
}
