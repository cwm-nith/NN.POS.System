using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NN.POS.System.Infrastructure.Tables.User;

namespace NN.POS.System.Infrastructure.Tables;

public static class Extensions
{
    public static IServiceCollection AddDataDbRepositories(this IServiceCollection services)
    {
        services.AddPostgresRepository<UserTable>();

        services.AddScoped(typeof(DataDbContext),
          sp =>
          {
              var options = sp.CreateScope().ServiceProvider.GetRequiredService<DbContextOptions<DataDbContext>>();
              return new DataDbContext(options);
          });

        return services;
    }

    private static IServiceCollection AddPostgresRepository<TTable>(this IServiceCollection services)
      where TTable : BaseTable
    {
        services.AddTransient<IReadDbRepository<TTable>>(sp =>
        {
            var context = services.BuildServiceProvider().GetRequiredService<DataDbContext>();
            return new ReadDbRepository<TTable>(context);
        });
        services.AddTransient<IWriteDbRepository<TTable>>(sp =>
        {
            var context = services.BuildServiceProvider().GetRequiredService<DataDbContext>();
            return new WriteDbRepository<TTable>(context);
        });

        return services;
    }
}