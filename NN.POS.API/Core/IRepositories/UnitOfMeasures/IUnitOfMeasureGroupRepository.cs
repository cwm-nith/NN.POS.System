using NN.POS.API.App.Queries.UnitOfMeasures;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Core.IRepositories.UnitOfMeasures;

public interface IUnitOfMeasureGroupRepository : IRepository
{
    Task CreateAsync(UnitOfMeasureGroupDto dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(string? name, int id, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);

    Task<PagedResult<UnitOfMeasureGroupDto>> GetPageAsync(GetUomPageGroupQuery q,
        CancellationToken cancellationToken = default);
    Task<UnitOfMeasureGroupDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}