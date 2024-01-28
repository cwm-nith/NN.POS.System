using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.DbConfigs;
using NN.POS.API.Infra.DbConfigs.Purchases;
using NN.POS.API.Infra.Tables.BusinessPartners;
using NN.POS.API.Infra.Tables.Company;
using NN.POS.API.Infra.Tables.Currencies;
using NN.POS.API.Infra.Tables.DocumentInvoicing;
using NN.POS.API.Infra.Tables.ItemMasters;
using NN.POS.API.Infra.Tables.PaymentTypes;
using NN.POS.API.Infra.Tables.PriceLists;
using NN.POS.API.Infra.Tables.Purchases.PurchaseOrders;
using NN.POS.API.Infra.Tables.Purchases.PurchasePO;
using NN.POS.API.Infra.Tables.Roles;
using NN.POS.API.Infra.Tables.Tax;
using NN.POS.API.Infra.Tables.UnitOfMeasures;
using NN.POS.API.Infra.Tables.User;
using NN.POS.API.Infra.Tables.Warehouses;

namespace NN.POS.API.Infra.Tables;

public class DataDbContext(DbContextOptions<DataDbContext> options) : DbContext(options)
{
    public DbSet<UserTable>? Users { get; set; }
    public DbSet<RoleTable>? Roles { get; set; }
    public DbSet<UserRoleTable>? UserRoles { get; set; }
    public DbSet<BusinessPartnerTable>? BusinessPartners { get; set; }
    public DbSet<CustomerGroupTable>? CustomerGroups { get; set; }
    public DbSet<PriceListDetailTable>? PriceListDetails { get; set; }
    public DbSet<PriceListTable>? PriceLists { get; set; }
    public DbSet<UnitOfMeasureDefineTable>? UnitOfMeasureDefines { get; set; }
    public DbSet<UnitOfMeasureGroupTable>? UnitOfMeasureGroups { get; set; }
    public DbSet<UnitOfMeasureTable>? UnitOfMeasures { get; set; }
    public DbSet<ItemMasterDataTable>? ItemMasterData { get; set; }
    public DbSet<CurrencyTable>? Currencies { get; set; }
    public DbSet<WarehouseTable>? Warehouses { get; set; }
    public DbSet<WarehouseSummaryTable>? WarehouseSummaries { get; set; }
    public DbSet<WarehouseDetailTable>? WarehouseDetails { get; set; }
    public DbSet<CompanyTable>? Companies { get; set; }
    public DbSet<BranchTable>? Branches { get; set; }
    public DbSet<TaxTable>? Tax { get; set; }
    public DbSet<ExchangeRateTable>? ExchangeRates { get; set; }
    public DbSet<PaymentTypeTable>? PaymentTypes { get; set; }
    public DbSet<PurchaseOrderTable>? PurchaseOrders { get; set; }
    public DbSet<PurchaseOrderDetailTable>? PurchaseOrderDetails { get; set; }
    public DbSet<DocumentInvoicingTable>? DocumentInvoicing { get; set; }
    public DbSet<DocumentInvoicePrefixingTable>? DocumentInvoicePrefixing { get; set; }
    public DbSet<PurchasePOTable>? PurchasePO { get; set; }
    public DbSet<PurchasePODetailTable>? PurchasePODetail { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .AddPriceListTableRelationship()
            .ItemMasterDataTableDbConfig()
            .BusinessPartnerConfig()
            .TaxTableDbConfig()
            .PurchaseOrderTableConfig()
            .DocumentInvoicingTableConfig()
            .PurchasePOTableConfig();
    }
}