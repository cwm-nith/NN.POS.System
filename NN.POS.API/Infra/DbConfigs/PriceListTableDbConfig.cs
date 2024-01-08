using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.Tables.PriceLists;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.DbConfigs;

public static class PriceListTableDbConfig
{
    public static ModelBuilder AddPriceListTableRelationship(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PriceListDetailTable>()
            .HasOne(i => i.PriceList)
            .WithMany(i => i.PriceListDetails)
            .HasForeignKey(i => i.PriceListId);

        modelBuilder.Entity<PriceListTable>()
            .HasMany(i => i.PriceListDetails)
            .WithOne(i => i.PriceList)
            .HasForeignKey(i => i.PriceListId);

       modelBuilder.Entity<PriceListDetailTable>()
            .Property(x => x.DiscountType)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<DiscountType>(false));

        return modelBuilder;
    }
}