using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.Tables.Purchases.PurchasePO;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.DbConfigs.Purchases;

public static class PurchasePOTableDbConfig
{
    public static ModelBuilder PurchasePOTableConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchasePOTable>()
            .HasMany(i => i.PurchasePODetails)
            .WithOne(i => i.PurchasePO)
            .HasForeignKey(i => i.PurchasePOId);

        modelBuilder.Entity<PurchasePOTable>()
            .Property(x => x.Status)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<PurchaseStatus>(false));

        modelBuilder.Entity<PurchasePOTable>()
            .Property(x => x.DiscountType)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<DiscountType>(false));

        modelBuilder.Entity<PurchasePODetailTable>()
            .Property(x => x.DiscountType)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<DiscountType>(false));

        return modelBuilder;
    }
}