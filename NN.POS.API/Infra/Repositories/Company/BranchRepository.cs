using Microsoft.EntityFrameworkCore;
using NN.POS.API.App.Queries.Company;
using NN.POS.API.Core.Exceptions.Company;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Company;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Company.Branches;

namespace NN.POS.API.Infra.Repositories.Company;

public class BranchRepository(
    IReadDbRepository<BranchTable> readDbRepository,
    IWriteDbRepository<BranchTable> writeDbRepository) : IBranchRepository
{
    public async Task CreateAsync(BranchDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);
    }

    public async Task UpdateAsync(BranchDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.UpdateAsync(body.ToTable(), cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var br = await GetByIdAsync(id, cancellationToken);
        br.IsDeleted = true;
        await writeDbRepository.UpdateAsync(br.ToTable(), cancellationToken);
    }

    public async Task<BranchDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var br = await (from b in context.Branches!.Where(i => !i.IsDeleted && i.Id == id)
                        join com in context.Companies on b.CompanyId equals com.Id
                        select b.ToDto(com.Name)).FirstOrDefaultAsync(cancellationToken);
        return br ?? throw new BranchNotFoundException(id);
    }

    public async Task<PagedResult<BranchDto>> GetPageAsync(GetBranchPageQuery query, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var br = await (from b in context.Branches!.Where(i => !i.IsDeleted && EF.Functions.Like(i.Name, $"%{query.Search}%"))
            join com in context.Companies on b.CompanyId equals com.Id
            select b.ToDto(com.Name)).PaginateAsync(query, cancellationToken);
        return br;
    }
}