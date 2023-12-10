using NN.POS.API.App.Queries.UnitOfMeasures;
using NN.POS.API.Core.Exceptions.UnitOfMeasures;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.UnitOfMeasures;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Infra.Repositories.UnitOfMeasures;

public class UnitOfMeasureGroupRepository(
    IReadDbRepository<UnitOfMeasureGroupTable> readDbRepository,
    IWriteDbRepository<UnitOfMeasureGroupTable> writeDbRepository) : IUnitOfMeasureGroupRepository
{
    public async Task CreateAsync(UnitOfMeasureGroupDto dto, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(dto.ToTable(), cancellationToken);
    }

    public async Task UpdateAsync(string? name, int id, CancellationToken cancellationToken = default)
    {
        var uomGroup = await GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
        uomGroup.Name = name ?? uomGroup.Name;
        await writeDbRepository.UpdateAsync(uomGroup.ToTable(), cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var uomGroup = await GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
        uomGroup.IsDeleted = true;
        await writeDbRepository.UpdateAsync(uomGroup.ToTable(), cancellationToken);
    }

    public async Task<PagedResult<UnitOfMeasureGroupDto>> GetPageAsync(GetUomPageGroupQuery q, CancellationToken cancellationToken = default)
    {
        var data = await readDbRepository.BrowseAsync(i => !i.IsDeleted, o => o.Name, q, cancellationToken);
        return data.Map(i => i.ToDto());
    }

    public async Task<UnitOfMeasureGroupDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var uom = await readDbRepository.FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted, cancellationToken) ?? throw new UnitOfMeasureGroupNotFoundException(id);
        return uom.ToDto();
    }
}