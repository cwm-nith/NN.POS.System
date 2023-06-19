using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NN.POS.System.Infrastructure.Tables;

public class WriteDbRepository<TTable> : IWriteDbRepository<TTable> where TTable : BaseTable
{
    public WriteDbRepository(DataDbContext context)
    {
        Context = context;
    }

    public DataDbContext Context { get; }
    public async Task<TTable> AddAsync(TTable entity)
    {
        Context.Set<TTable>().Add(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public Task UpdateAsync(TTable entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.Set<TTable>().Update(entity);
        return Context.SaveChangesAsync();
    }

    public Task<int> DeleteAsync(Guid id)
    {
        return DeleteAsync(x => x.Id == id);
    }

    public Task<int> DeleteAsync(TTable entity)
    {
        Context.Set<TTable>().Remove(entity);
        return Context.SaveChangesAsync();
    }

    public Task<int> DeleteAsync(Expression<Func<TTable, bool>> predicate)
    {
        var collection = Context.Set<TTable>().Where(predicate);
        Context.Set<TTable>().RemoveRange(collection);

        return Context.SaveChangesAsync();
    }
}