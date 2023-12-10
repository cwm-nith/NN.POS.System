using NN.POS.API.Core.Exceptions.UnitOfMeasures;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.UnitOfMeasures;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Infra.Repositories.UnitOfMeasures;

public class UnitOfMeasureDefineRepository(
    IReadDbRepository<UnitOfMeasureDefineTable> readDbRepository,
    IWriteDbRepository<UnitOfMeasureDefineTable> writeDbRepository) : IUnitOfMeasureDefineRepository
{
    public async Task CreateAsync(UnitOfMeasureDefineDto dto, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(dto.ToTable(), cancellationToken);
    }

    public async Task UpdateAsync(CreateUomDefineDto dto, int id, CancellationToken cancellationToken = default)
    {
        var uomDefine = await GetByIdAsync(id, cancellationToken).ConfigureAwait(false);

        uomDefine.AltQty = dto.AltQty;
        uomDefine.Factor = dto.Factor;
        uomDefine.AltUomId = dto.AltUomId;
        uomDefine.BaseQty = dto.BaseQty;
        uomDefine.BaseUomId = dto.BaseUomId;
        uomDefine.GroupUomId = dto.GroupUomId;

        await writeDbRepository.UpdateAsync(uomDefine.ToTable(), cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var uomDefine = await GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
        uomDefine.IsDeleted = true;
        await writeDbRepository.UpdateAsync(uomDefine.ToTable(), cancellationToken);
    }

    public async Task<UnitOfMeasureDefineDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var uom = await readDbRepository.FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted, cancellationToken) ?? throw new UnitOfMeasureDefineNotFoundException(id);
        return uom.ToDto();
    }
}