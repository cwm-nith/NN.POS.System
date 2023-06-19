using Microsoft.EntityFrameworkCore;
using NN.POS.System.Infrastructure.Tables.User;

namespace NN.POS.System.Infrastructure.Tables;

public class DataDbContext : DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }

    public DbSet<UserTable>? Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}