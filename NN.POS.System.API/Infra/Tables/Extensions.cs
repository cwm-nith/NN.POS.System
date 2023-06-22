using Microsoft.EntityFrameworkCore;
using NN.POS.System.API.Core.IRepositories.Users;
using NN.POS.System.API.Infra.Repositories.Users;
using NN.POS.System.API.Infra.Tables.User;

namespace NN.POS.System.API.Infra.Tables;

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

        services.AddTransient<IUserRepository, UserRepository>();
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