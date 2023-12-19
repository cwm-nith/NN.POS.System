using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Core.IRepositories.UnitOfMeasures;

public interface IUnitOfMeasureDefineRepository : IRepository
{
    Task CreateAsync(UnitOfMeasureDefineDto dto, CancellationToken cancellationToken = default);
    Task CreateManyAsync(List<UnitOfMeasureDefineDto> dto, CancellationToken cancellationToken = default);
    Task UpdateAsync(CreateUomDefineDto dto, int id, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<UnitOfMeasureDefineDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<UnitOfMeasureDefineDto>> GetUomDefineByGroupIdAsync(int groupId);
}