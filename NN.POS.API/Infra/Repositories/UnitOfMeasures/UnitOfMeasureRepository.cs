using NN.POS.API.App.Queries.UnitOfMeasures;
using NN.POS.API.Core.Exceptions.UnitOfMeasures;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.UnitOfMeasures;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Infra.Repositories.UnitOfMeasures;

public class UnitOfMeasureRepository(IReadDbRepository<UnitOfMeasureTable> readDbRepository, IWriteDbRepository<UnitOfMeasureTable> writeDbRepository) : IUnitOfMeasureRepository
{
    public async Task CreateAsync(UnitOfMeasureDto dto, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(dto.ToTable(), cancellationToken);
    }

    public async Task UpdateAsync(string name, int id, CancellationToken cancellationToken = default)
    {
        var uom = await GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
        uom.Name = name;
        await writeDbRepository.UpdateAsync(uom.ToTable(), cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var uom = await GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
        uom.IsDeleted = true;
        await writeDbRepository.UpdateAsync(uom.ToTable(), cancellationToken);
    }

    public async Task<PagedResult<UnitOfMeasureDto>> GetPageAsync(GetUomPageQuery q, CancellationToken cancellationToken = default)
    {
        var data = await readDbRepository.BrowseAsync(i => !i.IsDeleted, o => o.Name, q, cancellationToken);
        return data.Map(i => i.ToDto());
    }

    public async Task<UnitOfMeasureDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var uom = await readDbRepository.FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted, cancellationToken) ?? throw new UnitOfMeasureNotFoundException(id);
        return uom.ToDto();
    }
}