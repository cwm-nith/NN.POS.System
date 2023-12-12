using NN.POS.API.App.Queries.ItemMasters;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.Core.IRepositories.ItemMasters;

public interface IItemMasterDataRepository : IRepository
{
    Task CreateAsync(ItemMasterDataDto dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(ItemMasterDataDto dto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<ItemMasterDataDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ItemMasterDataDto> GetByBarcodeAsync(string barcode, CancellationToken cancellationToken = default);
    Task<ItemMasterDataDto> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
    Task<PagedResult<ItemMasterDataDto>> GetPageAsync(GetPageItemMasterDataQuery q, CancellationToken cancellationToken = default);
}