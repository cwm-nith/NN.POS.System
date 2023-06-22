using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NN.POS.System.API.Commons.Pagination;

namespace NN.POS.System.API.Infra.Tables;

public class ReadDbRepository<TTable> : IReadDbRepository<TTable> where TTable : BaseTable
{
    public ReadDbRepository(DataDbContext context)
    {
        Context = context;
    }

    public DataDbContext Context { get; }
    public Task<TTable?> FirstOrDefaultAsync(Guid id)
    {
        return Context.Set<TTable>().FindAsync(id).AsTask();
    }

    public Task<TTable?> FirstOrDefaultAsync(Expression<Func<TTable, bool>> predicate)
    {
        return Context.Set<TTable>().Where(predicate).AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TTable>> WhereAsync(Expression<Func<TTable, bool>> predicate)
    {
        return await Context.Set<TTable>().Where(predicate).AsNoTracking().ToListAsync();
    }

    public Task<int> CountAsync(Expression<Func<TTable, bool>> predicate)
    {
        return Context.Set<TTable>().Where(predicate).CountAsync();
    }

    public Task<PagedResult<TTable>> BrowseAsync<TQuery>(Expression<Func<TTable, bool>> predicate, TQuery query) where TQuery : IPagedQuery
    {
        return Context.Set<TTable>().AsQueryable().Where(predicate).AsNoTracking().PaginateAsync(query);
    }

    public Task<PagedResult<TTable>> BrowseAsync<TQuery>(Expression<Func<TTable, bool>> predicate, Expression<Func<TTable, object>> order, TQuery query) where TQuery : IPagedQuery
    {
        return Context.Set<TTable>().AsQueryable().Where(predicate).OrderByDescending(order).AsNoTracking()
            .PaginateAsync(query);
    }

    public Task<PagedResult<TTable>> BrowseDescAsync<TQuery>(Expression<Func<TTable, bool>> predicate, Expression<Func<TTable, object>> order, TQuery query) where TQuery : IPagedQuery
    {
        return Context.Set<TTable>().AsQueryable().Where(predicate).OrderBy(order).AsNoTracking().PaginateAsync(query);
    }

    public Task<bool> ExistsAsync(Expression<Func<TTable, bool>> predicate)
    {
        return Context.Set<TTable>().AnyAsync(predicate);
    }
}