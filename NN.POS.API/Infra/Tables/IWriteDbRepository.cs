using System.Linq.Expressions;

namespace NN.POS.API.Infra.Tables;

public interface IWriteDbRepository<T> where T : BaseTable
{
    DataDbContext Context { get; }

    Task<T> AddAsync(T entity, CancellationToken cancellation = default);
    Task<bool> AddManyAsync(List<T> entities, CancellationToken cancellation = default);

    Task UpdateAsync(T entity, CancellationToken cancellation = default);
    Task<bool> UpdateManyAsync(List<T> entities, CancellationToken cancellation = default);

    Task<int> DeleteAsync(int id, CancellationToken cancellation = default);

    Task<int> DeleteAsync(T entity, CancellationToken cancellation = default);

    Task<int> DeleteAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellation = default);
}