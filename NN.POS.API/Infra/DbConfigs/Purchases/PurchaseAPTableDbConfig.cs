using Microsoft.EntityFrameworkCore;
using NN.POS.API.Infra.Tables.Purchases.PurchaseAP;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.DbConfigs.Purchases;

public static class PurchaseAPTableDbConfig
{
    public static ModelBuilder PurchaseAPTableConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchaseAPTable>()
            .HasMany(i => i.PurchaseAPDetails)
            .WithOne(i => i.PurchaseAP)
            .HasForeignKey(i => i.PurchaseAPId);

        modelBuilder.Entity<PurchaseAPTable>()
            .Property(x => x.Status)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<PurchaseStatus>(false));

        modelBuilder.Entity<PurchaseAPTable>()
            .Property(x => x.DiscountType)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<DiscountType>(false));

        modelBuilder.Entity<PurchaseAPDetailTable>()
            .Property(x => x.DiscountType)
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .HasConversion(
                v => v.ToEnumString(),
                v => v.ToEnum<DiscountType>(false));

        return modelBuilder;
    }
}