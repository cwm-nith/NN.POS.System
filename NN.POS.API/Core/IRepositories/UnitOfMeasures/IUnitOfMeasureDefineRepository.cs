using NN.POS.API.App.Queries.UnitOfMeasures;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Core.IRepositories.UnitOfMeasures;

public interface IUnitOfMeasureDefineRepository
{
    Task CreateAsync(UnitOfMeasureDefineDto dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(CreateUomDefineDto dto, int id, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<UnitOfMeasureDefineDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}