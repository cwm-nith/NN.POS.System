using Microsoft.EntityFrameworkCore;
using NN.POS.System.API.Infra.Tables.User;

namespace NN.POS.System.API.Infra.Tables;

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