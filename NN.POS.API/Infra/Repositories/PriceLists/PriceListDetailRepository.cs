using NN.POS.API.App.Queries.PriceLists;
using NN.POS.API.Core.Exceptions.PriceLists;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.PriceLists;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.Infra.Repositories.PriceLists;

public class PriceListDetailRepository(
    IReadDbRepository<PriceListDetailTable> readDbRepository,
    IWriteDbRepository<PriceListDetailTable> writeDbRepository) : IPriceListDetailRepository
{
    public async Task CreateAsync(List<PriceListDetailDto> plDetails, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddManyAsync(plDetails.Select(i => i.ToTable()).ToList(), cancellationToken);
    }

    public async Task UpdateAsync(PriceListDetailDto plDetail, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.UpdateAsync(plDetail.ToTable(), cancellationToken);
    }

    public async Task<PagedResult<PriceListDetailDto>> GetPageAsync(GetPagePriceListDetailQuery q, CancellationToken cancellationToken = default)
    {
        var data = await readDbRepository.BrowseAsync(i => true, q, cancellationToken);
        return data.Map(i => i.ToDto());
    }

    public async Task<PriceListDetailDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var data = await readDbRepository.FirstOrDefaultAsync(i => i.Id == id, cancellationToken) ?? throw new PriceListDetailNotFoundException(id);
        return data.ToDto();
    }
}