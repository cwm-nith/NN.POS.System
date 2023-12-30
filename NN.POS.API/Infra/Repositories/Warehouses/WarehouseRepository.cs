using Microsoft.EntityFrameworkCore;
using NN.POS.API.App.Queries.Warehouses;
using NN.POS.API.Core.Exceptions.Warehouses;
using NN.POS.API.Core.IRepositories.Warehouses;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Warehouses;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.Infra.Repositories.Warehouses;

public class WarehouseRepository(
    IReadDbRepository<WarehouseTable> readDbRepository,
    IWriteDbRepository<WarehouseTable> writeDbRepository) : IWarehouseRepository
{
    public async Task CreateAsync(WarehouseDto ws, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(ws.ToTable(), cancellationToken);
    }

    public async Task UpdateAsync(WarehouseDto ws, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.UpdateAsync(ws.ToTable(), cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var ws = await GetByIdAsync(id, cancellationToken);
        ws.IsDeleted = true;
        await writeDbRepository.UpdateAsync(ws.ToTable(), cancellationToken);
    }

    public async Task<WarehouseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var ws = await readDbRepository.FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == id, cancellationToken) ??
                 throw new WarehouseNotFoundException(id);
        return ws.ToDto();
    }

    public async Task<PagedResult<WarehouseDto>> GetPageAsync(GetPageWarehouseQuery query, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;

        var data = await (from ws in context.Warehouses!.Where(i =>
                !i.IsDeleted && (
                    EF.Functions.Like(i.Name, $"%{query.Search}%") ||
                    EF.Functions.Like(i.Code, $"%{query.Search}%") ||
                    EF.Functions.Like(i.Address, $"%{query.Search}%") ||
                    EF.Functions.Like(i.Location, $"%{query.Search}%")
                ))
                          join br in context.Branches! on ws.BranchId equals br.Id
                          select ws.ToDto(br.Name)).PaginateAsync(query, cancellationToken);

        return data;
    }
}