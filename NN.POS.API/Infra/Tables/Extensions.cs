using Microsoft.EntityFrameworkCore;
using NN.POS.API.Core.IRepositories;
using NN.POS.API.Core.IRepositories.BusinessPartners;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.API.Core.IRepositories.Roles;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.API.Core.IRepositories.Users;
using NN.POS.API.Infra.Repositories.BusinessPartners;
using NN.POS.API.Infra.Repositories.PriceLists;
using NN.POS.API.Infra.Repositories.Roles;
using NN.POS.API.Infra.Repositories.UnitOfMeasures;
using NN.POS.API.Infra.Repositories.Users;
using NN.POS.API.Infra.Tables.BusinessPartners;
using NN.POS.API.Infra.Tables.PriceLists;
using NN.POS.API.Infra.Tables.Roles;
using NN.POS.API.Infra.Tables.UnitOfMeasures;
using NN.POS.API.Infra.Tables.User;

namespace NN.POS.API.Infra.Tables;

public static class Extensions
{
    public static IServiceCollection AddDataDbRepositories(this IServiceCollection services)
    {
        services.AddPostgresRepository<UserTable>();
        services.AddPostgresRepository<RoleTable>();
        services.AddPostgresRepository<UserRoleTable>();
        services.AddPostgresRepository<BusinessPartnerTable>();
        services.AddPostgresRepository<CustomerGroupTable>();
        services.AddPostgresRepository<UnitOfMeasureDefineTable>();
        services.AddPostgresRepository<UnitOfMeasureTable>();
        services.AddPostgresRepository<UnitOfMeasureGroupTable>();
        services.AddPostgresRepository<PriceListTable>();
        services.AddPostgresRepository<PriceListDetailTable>();

        services.AddScoped(typeof(DataDbContext),
          sp =>
          {
              var options = sp.CreateScope().ServiceProvider.GetRequiredService<DbContextOptions<DataDbContext>>();
              return new DataDbContext(options);
          });
        
        services.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IRepository)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return services;
    }

    private static void AddPostgresRepository<TTable>(this IServiceCollection services)
      where TTable : BaseTable
    {
        var logger = services.BuildServiceProvider().GetService<ILogger<WriteDbRepository<TTable>>>();
        services.AddTransient<IReadDbRepository<TTable>>(_ =>
        {
            var context = services.BuildServiceProvider().GetRequiredService<DataDbContext>();
            return new ReadDbRepository<TTable>(context);
        });
        services.AddTransient<IWriteDbRepository<TTable>>(_ =>
        {
            var context = services.BuildServiceProvider().GetRequiredService<DataDbContext>();
            return new WriteDbRepository<TTable>(context, logger);
        });
    }
}