using Microsoft.EntityFrameworkCore;
using NN.POS.API.Core.IRepositories;
using NN.POS.API.Infra.Tables.BusinessPartners;
using NN.POS.API.Infra.Tables.Company;
using NN.POS.API.Infra.Tables.Currencies;
using NN.POS.API.Infra.Tables.ItemMasters;
using NN.POS.API.Infra.Tables.PaymentTypes;
using NN.POS.API.Infra.Tables.PriceLists;
using NN.POS.API.Infra.Tables.Purchases.PurchaseOrders;
using NN.POS.API.Infra.Tables.Roles;
using NN.POS.API.Infra.Tables.Tax;
using NN.POS.API.Infra.Tables.UnitOfMeasures;
using NN.POS.API.Infra.Tables.User;
using NN.POS.API.Infra.Tables.Warehouses;

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
        services.AddPostgresRepository<ItemMasterDataTable>();
        services.AddPostgresRepository<CurrencyTable>();
        services.AddPostgresRepository<WarehouseTable>();
        services.AddPostgresRepository<WarehouseSummaryTable>();
        services.AddPostgresRepository<WarehouseDetailTable>();
        services.AddPostgresRepository<CompanyTable>();
        services.AddPostgresRepository<BranchTable>();
        services.AddPostgresRepository<TaxTable>();
        services.AddPostgresRepository<ExchangeRateTable>();
        services.AddPostgresRepository<PaymentTypeTable>();
        services.AddPostgresRepository<PurchaseOrderTable>();
        services.AddPostgresRepository<PurchaseOrderDetailTable>();

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