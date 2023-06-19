using NN.POS.System.Common.Pagination;
using System.Linq.Expressions;

namespace NN.POS.System.Infrastructure.Tables;

public interface IWriteDbRepository<T> where T : BaseTable
{
    DataDbContext Context { get; }

    Task<T> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task<int> DeleteAsync(Guid id);

    Task<int> DeleteAsync(T entity);

    Task<int> DeleteAsync(Expression<Func<T, bool>> predicate);
}