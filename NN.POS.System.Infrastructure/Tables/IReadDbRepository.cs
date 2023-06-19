using System.Linq.Expressions;
using NN.POS.System.Common.Pagination;

namespace NN.POS.System.Infrastructure.Tables;

public interface IReadDbRepository<T> where T : BaseTable
{
    DataDbContext Context { get; }

    Task<T?> FirstOrDefaultAsync(Guid id);

    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate);

    Task<int> CountAsync(Expression<Func<T, bool>> predicate);

    Task<PagedResult<T>> BrowseAsync<TQuery>(Expression<Func<T, bool>> predicate,
        TQuery query) where TQuery : IPagedQuery;
    Task<PagedResult<T>> BrowseAsync<TQuery>(Expression<Func<T, bool>> predicate,
        Expression<Func<T, object>> order,
        TQuery query) where TQuery : IPagedQuery;

    Task<PagedResult<T>> BrowseDescAsync<TQuery>(Expression<Func<T, bool>> predicate,
        Expression<Func<T, object>> order,
        TQuery query) where TQuery : IPagedQuery;
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
}