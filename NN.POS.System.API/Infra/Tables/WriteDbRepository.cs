using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace NN.POS.System.API.Infra.Tables;

public class WriteDbRepository<TTable> : IWriteDbRepository<TTable> where TTable : BaseTable
{
    private readonly ILogger<WriteDbRepository<TTable>>? _logger;
    public WriteDbRepository(DataDbContext context, ILogger<WriteDbRepository<TTable>>? logger)
    {
        Context = context;
        _logger = logger;
    }

    public DataDbContext Context { get; }
    public async Task<TTable> AddAsync(TTable entity, CancellationToken cancellation = default)
    {
        Context.Set<TTable>().Add(entity);
        await Context.SaveChangesAsync(cancellation);

        return entity;
    }

    public async Task<bool> AddManyAsync(List<TTable> entities, CancellationToken cancellation = default)
    {
        await Context.Set<TTable>().AddRangeAsync(entities, cancellation);
        await Context.SaveChangesAsync(cancellation);
        return true;
    }

    public Task UpdateAsync(TTable entity, CancellationToken cancellation = default)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.Set<TTable>().Update(entity);
        return Context.SaveChangesAsync(cancellation);
    }

    public async Task<bool> UpdateManyAsync(List<TTable> entities, CancellationToken cancellation = default)
    {
        try
        {
            Context.Entry(entities).State = EntityState.Modified;
            Context.Set<TTable>().UpdateRange(entities);
            await Context.SaveChangesAsync(cancellation);
        }
        catch (Exception ex)
        {
            _logger?.LogDebug(ex.Message);
        }
        return false;
    }

    public Task<int> DeleteAsync(int id, CancellationToken cancellation = default)
    {
        return DeleteAsync(x => x.Id == id, cancellation);
    }

    public Task<int> DeleteAsync(TTable entity, CancellationToken cancellation = default)
    {
        Context.Set<TTable>().Remove(entity);
        return Context.SaveChangesAsync(cancellation);
    }

    public Task<int> DeleteAsync(Expression<Func<TTable, bool>> predicate, CancellationToken cancellation = default)
    {
        var collection = Context.Set<TTable>().Where(predicate);
        Context.Set<TTable>().RemoveRange(collection);

        return Context.SaveChangesAsync(cancellation);
    }
}