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

    public async Task CreateManyAsync(List<UnitOfMeasureDefineDto> dto, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.UpdateManyAsync(dto.Select(i => i.ToTable()).ToList(), cancellationToken);
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

    public async Task<IEnumerable<UnitOfMeasureDefineDto>> GetUomDefineByGroupIdAsync(int groupId)
    {
        var context = readDbRepository.Context;

        var list = (from du in context.UnitOfMeasureDefines!.Where(i => !i.IsDeleted)
                join uomGroup in context.UnitOfMeasureGroups!.Where(i => !i.IsDeleted && i.Id == groupId) on du.GroupUomId equals uomGroup.Id
                join buo in context.UnitOfMeasures!.Where(i => !i.IsDeleted) on du.BaseUomId equals buo.Id
                join auo in context.UnitOfMeasures!.Where(i => !i.IsDeleted) on du.AltUomId equals auo.Id
                select new UnitOfMeasureDefineDto
                {
                    AltQty = du.AltQty,
                    BaseQty = du.BaseQty,
                    Factor = du.Factor,
                    AltUomId = du.AltUomId,
                    AltUomName = auo.Name,
                    BaseUomId = buo.Id,
                    BaseUomName = buo.Name,
                    CreatedAt = du.CreatedAt,
                    GroupUomId = uomGroup.Id,
                    Id = du.Id,
                    IsDeleted = du.IsDeleted
                }
            );
        return await Task.FromResult(list);
    }
}