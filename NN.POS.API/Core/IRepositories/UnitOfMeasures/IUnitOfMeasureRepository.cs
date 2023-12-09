using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Core.IRepositories.UnitOfMeasures;

public interface IUnitOfMeasureRepository
{
    Task CreateAsync(UnitOfMeasureDto dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(string name, int id, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);

    Task<PagedResult<UnitOfMeasureDto>> GetPageAsync(string search, PagedQuery page,
        CancellationToken cancellationToken = default);
    Task<UnitOfMeasureDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}