using NN.POS.API.App.Queries.PriceLists;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.Core.IRepositories.PriceLists;

public interface IPriceListDetailRepository : IRepository
{
    Task CreateAsync(List<PriceListDetailDto> plDetails, CancellationToken cancellationToken = default);
    Task UpdateAsync(PriceListDetailDto plDetail, CancellationToken cancellationToken = default);
    Task<PagedResult<PriceListDetailDto>> GetPageAsync(GetPagePriceListDetailQuery q, CancellationToken cancellationToken = default);
    Task<PriceListDetailDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<PriceListDetailDto>> GetCopyAsync(GetPriceListCopyQuery q, CancellationToken cancellationToken = default);
}