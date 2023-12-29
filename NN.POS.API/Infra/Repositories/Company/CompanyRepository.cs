using Microsoft.EntityFrameworkCore;
using NN.POS.API.App.Queries.Company;
using NN.POS.API.Core.Exceptions.Company;
using NN.POS.API.Core.IRepositories.Company;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Company;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.API.Infra.Repositories.Company;

public class CompanyRepository(
    IWriteDbRepository<CompanyTable> writeDbRepository,
    IReadDbRepository<CompanyTable> readDbRepository) : ICompanyRepository
{
    public async Task CreateAsync(CompanyDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);
    }

    public async Task UpdateAsync(CompanyDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.UpdateAsync(body.ToTable(), cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var com = await GetByIdAsync(id, cancellationToken);
        com.IsDeleted = true;
        await writeDbRepository.UpdateAsync(com.ToTable(), cancellationToken);
    }

    public async Task<CompanyDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;

        var com = await (from c in context.Companies!.Where(i => !i.IsDeleted && i.Id == id)
                         join pl in context.PriceLists! on c.PriceListId equals pl.Id
                         join sysCcy in context.Currencies! on c.SysCcyId equals sysCcy.Id
                         join localCcy in context.Currencies! on c.SysCcyId equals localCcy.Id
                         select c.ToDto(localCcy.Name, pl.Name, sysCcy.Name)).FirstOrDefaultAsync(cancellationToken);
        return com ?? throw new CompanyNotFoundException(id);
    }

    public async Task<PagedResult<CompanyDto>> GetPageAsync(GetCompanyPageQuery query, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;

        var com = await (from c in context.Companies!
                .Where(i => !i.IsDeleted && EF.Functions.Like(i.Name, $"%{query.Search}%"))
                         join pl in context.PriceLists! on c.PriceListId equals pl.Id
                         join sysCcy in context.Currencies! on c.SysCcyId equals sysCcy.Id
                         join localCcy in context.Currencies! on c.SysCcyId equals localCcy.Id
                         select c.ToDto(localCcy.Name, pl.Name, sysCcy.Name)).PaginateAsync(query, cancellationToken);
        return com;
    }
}