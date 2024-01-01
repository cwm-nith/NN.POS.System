using Microsoft.EntityFrameworkCore;
using NN.POS.API.App.Queries.PaymentTypes;
using NN.POS.API.Core.Exceptions.PaymentTypes;
using NN.POS.API.Core.IRepositories;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.PaymentTypes;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PaymentTypes;

namespace NN.POS.API.Infra.Repositories.PaymentTypes;

public class PaymentTypeRepository(
    IReadDbRepository<PaymentTypeTable> readDbRepository,
    IWriteDbRepository<PaymentTypeTable> writeDbRepository) : IPaymentTypeRepository
{
    public async Task CreateAsync(PaymentTypeDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);
    }

    public async Task UpdateAsync(PaymentTypeDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.UpdateAsync(body.ToTable(), cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var pmt = await GetByIdAsync(id, cancellationToken);
        pmt.IsDeleted = true;

        await writeDbRepository.UpdateAsync(pmt.ToTable(), cancellationToken);
    }

    public async Task<PaymentTypeDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var pmt = await readDbRepository.FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == id, cancellationToken) ??
                  throw new PaymentTypeNotFoundException(id);
        return pmt.ToDto();
    }

    public async Task<PagedResult<PaymentTypeDto>> GetPageAsync(GetPaymentTypePageQuery query, CancellationToken cancellationToken = default)
    {
        var pmts = await readDbRepository.BrowseAsync(i => !i.IsDeleted && EF.Functions.Like(i.Name, $"%{query.Search}%"), i => i.CreatedAt, query, cancellationToken);
        return pmts.Map(i => i.ToDto());
    }
}