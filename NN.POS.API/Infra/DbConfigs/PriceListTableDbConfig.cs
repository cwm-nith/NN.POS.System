using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.Tables.PriceLists;

namespace NN.POS.API.Infra.DbConfigs;

public static class PriceListTableDbConfig
{
    public static ModelBuilder AddPriceListTableRelationship(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PriceListTable>()
            .HasMany(i => i.PriceListDetails)
            .WithOne(i => i.PriceList)
            .HasForeignKey(i => i.PriceListId);
        
        return modelBuilder;
    }
}