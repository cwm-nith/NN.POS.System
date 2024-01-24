using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NN.POS.API.Core.Commons.Enums;
using NN.POS.Common.Pagination;

namespace NN.POS.API.Infra.Tables;

public class ReadDbRepository<TTable>(DataDbContext context) : IReadDbRepository<TTable> where TTable : BaseTable
{
    public DataDbContext Context => context;

    public async Task<TTable?> FirstOrDefaultAsync(int id, CancellationToken cancellation = default)
    {
        return await Context.Set<TTable>()
            .FindAsync([id, cancellation], cancellationToken: cancellation)
            .AsTask();
    }
    
    public async Task<TTable?> FirstOrDefaultAsync(Expression<Func<TTable, bool>> predicate, CancellationToken cancellation = default)
    {
        return await Context.Set<TTable>().Where(predicate).AsNoTracking().FirstOrDefaultAsync(cancellation);
    }

    public async Task<TTable?> FirstOrDefaultAsync(
        Expression<Func<TTable, bool>> predicate, 
        Expression<Func<TTable, object>> order,
        RecordOrderingType orderingType = RecordOrderingType.None,
        CancellationToken cancellation = default)
    {
        return orderingType switch
        {
            RecordOrderingType.Ascending => await Context.Set<TTable>()
                .Where(predicate)
                .OrderBy(order)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellation),
            RecordOrderingType.Descending => await Context.Set<TTable>()
                .Where(predicate)
                .OrderByDescending(order)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellation),
            _ => await Context.Set<TTable>().Where(predicate).AsNoTracking().FirstOrDefaultAsync(cancellation)
        };
    }

    public async Task<IEnumerable<TTable>> WhereAsync(Expression<Func<TTable, bool>> predicate,
        CancellationToken cancellation = default)
    {
        return await Context.Set<TTable>().Where(predicate).AsNoTracking().ToListAsync(cancellation);
    }

    public async Task<IEnumerable<TTable>> WhereAsync(
        Expression<Func<TTable, bool>> predicate, 
        Expression<Func<TTable, object>> order,
        RecordOrderingType orderingType = RecordOrderingType.None, 
        CancellationToken cancellation = default)
    {
        return orderingType switch
        {
            RecordOrderingType.Ascending => await Context.Set<TTable>()
                .Where(predicate)
                .OrderBy(order)
                .AsNoTracking()
                .ToListAsync(cancellation),
            RecordOrderingType.Descending => await Context.Set<TTable>()
                .Where(predicate)
                .AsNoTracking()
                .OrderByDescending(order)
                .ToListAsync(cancellation),
            _ => await Context.Set<TTable>().Where(predicate).AsNoTracking().ToListAsync(cancellation)
        };
    }

    public async Task<int> CountAsync(Expression<Func<TTable, bool>> predicate, CancellationToken cancellation = default)
    {
        return await Context.Set<TTable>().Where(predicate).CountAsync(cancellation);
    }

    public async Task<PagedResult<TTable>> BrowseAsync<TQuery>(Expression<Func<TTable, bool>> predicate, TQuery query,
        CancellationToken cancellation = default) where TQuery : IPagedQuery
    {
        return await Context.Set<TTable>().AsQueryable().Where(predicate).AsNoTracking().PaginateAsync(query, cancellation);
    }

    public async Task<PagedResult<TTable>> BrowseAsync<TQuery>(Expression<Func<TTable, bool>> predicate,
        Expression<Func<TTable, object>> order, TQuery query, CancellationToken cancellation = default) where TQuery : IPagedQuery
    {
        return await Context.Set<TTable>().AsQueryable().Where(predicate).OrderByDescending(order).AsNoTracking()
            .PaginateAsync(query, cancellation);
    }

    public async Task<PagedResult<TTable>> BrowseDescAsync<TQuery>(Expression<Func<TTable, bool>> predicate,
        Expression<Func<TTable, object>> order, TQuery query, CancellationToken cancellation = default) where TQuery : IPagedQuery
    {
        return await Context.Set<TTable>().AsQueryable().Where(predicate).OrderBy(order).AsNoTracking().PaginateAsync(query, cancellation);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TTable, bool>> predicate, CancellationToken cancellation = default)
    {
        return await Context.Set<TTable>().AnyAsync(predicate, cancellation);
    }
}