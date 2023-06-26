using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NN.POS.System.Common.Pagination;

namespace NN.POS.System.API.Infra.Tables;

public class ReadDbRepository<TTable> : IReadDbRepository<TTable> where TTable : BaseTable
{
    public ReadDbRepository(DataDbContext context)
    {
        Context = context;
    }

    public DataDbContext Context { get; }
    public Task<TTable?> FirstOrDefaultAsync(Guid id, CancellationToken cancellation = default)
    {
        return Context.Set<TTable>()
            .FindAsync(new object?[] { id, cancellation }, cancellationToken: cancellation)
            .AsTask();
    }

    public Task<TTable?> FirstOrDefaultAsync(Expression<Func<TTable, bool>> predicate, CancellationToken cancellation = default)
    {
        return Context.Set<TTable>().Where(predicate).AsNoTracking().FirstOrDefaultAsync(cancellation);
    }

    public async Task<IEnumerable<TTable>> WhereAsync(Expression<Func<TTable, bool>> predicate,
        CancellationToken cancellation = default)
    {
        return await Context.Set<TTable>().Where(predicate).AsNoTracking().ToListAsync(cancellation);
    }

    public Task<int> CountAsync(Expression<Func<TTable, bool>> predicate, CancellationToken cancellation = default)
    {
        return Context.Set<TTable>().Where(predicate).CountAsync(cancellation);
    }

    public Task<PagedResult<TTable>> BrowseAsync<TQuery>(Expression<Func<TTable, bool>> predicate, TQuery query,
        CancellationToken cancellation = default) where TQuery : IPagedQuery
    {
        return Context.Set<TTable>().AsQueryable().Where(predicate).AsNoTracking().PaginateAsync(query, cancellation);
    }

    public Task<PagedResult<TTable>> BrowseAsync<TQuery>(Expression<Func<TTable, bool>> predicate,
        Expression<Func<TTable, object>> order, TQuery query, CancellationToken cancellation = default) where TQuery : IPagedQuery
    {
        return Context.Set<TTable>().AsQueryable().Where(predicate).OrderByDescending(order).AsNoTracking()
            .PaginateAsync(query, cancellation);
    }

    public Task<PagedResult<TTable>> BrowseDescAsync<TQuery>(Expression<Func<TTable, bool>> predicate,
        Expression<Func<TTable, object>> order, TQuery query, CancellationToken cancellation = default) where TQuery : IPagedQuery
    {
        return Context.Set<TTable>().AsQueryable().Where(predicate).OrderBy(order).AsNoTracking().PaginateAsync(query, cancellation);
    }

    public Task<bool> ExistsAsync(Expression<Func<TTable, bool>> predicate, CancellationToken cancellation = default)
    {
        return Context.Set<TTable>().AnyAsync(predicate, cancellation);
    }
}