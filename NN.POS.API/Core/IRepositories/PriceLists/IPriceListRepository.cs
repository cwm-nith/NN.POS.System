using NN.POS.API.App.Queries.PriceLists;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.Core.IRepositories.PriceLists;

public interface IPriceListRepository
{
    Task CreateAsync(PriceListDto dto, CancellationToken token = default);
    Task UpdateAsync(string? name, int id, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<PriceListDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PagedResult<PriceListDto>> GetPageAsync(GetPagePriceListQuery q, CancellationToken cancellationToken = default);
}