using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.DbConfigs;
using NN.POS.API.Infra.Tables.BusinessPartners;
using NN.POS.API.Infra.Tables.PriceLists;
using NN.POS.API.Infra.Tables.Roles;
using NN.POS.API.Infra.Tables.UnitOfMeasures;
using NN.POS.API.Infra.Tables.User;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .AddPriceListTableRelationship();
    }
}